using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace LAB12.DAL
{
    public class KetQuaDAL
    {
        // 1. Lấy danh sách Lớp
        public DataTable GetAllLop()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Lop_GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 2. Lấy danh sách Môn học
        public DataTable GetAllMonHoc()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_MonHoc_GetAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 3. Lấy danh sách Sinh viên kèm điểm theo Lớp & Môn
        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_KetQua_GetByLopMon", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLop", maLop);
                    cmd.Parameters.AddWithValue("@MaMon", maMon);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // 4. Lưu danh sách điểm bằng Transaction
        public (bool IsSuccess, string Message, int AffectedRows) SaveAllKetQua(string maMon, DataTable dtKetQua)
        {
            int successCount = 0;

            // Validation trước khi bắt đầu Transaction
            for (int i = 0; i < dtKetQua.Rows.Count; i++)
            {
                DataRow row = dtKetQua.Rows[i];
                string maSV = row["MaSV"]?.ToString();
                object rawDiem = row["Diem"];

                if (rawDiem == null || rawDiem == DBNull.Value || string.IsNullOrWhiteSpace(rawDiem.ToString()))
                {
                    return (false, $"Lỗi tại dòng {i + 1} (SV: {maSV}): Điểm không được để trống.", 0);
                }

                if (!double.TryParse(rawDiem.ToString(), out double diem))
                {
                    return (false, $"Lỗi tại dòng {i + 1} (SV: {maSV}): Điểm '{rawDiem}' không phải số hợp lệ.", 0);
                }

                if (diem < 0 || diem > 10)
                {
                    return (false, $"Lỗi tại dòng {i + 1} (SV: {maSV}): Điểm ({diem}) phải nằm trong khoảng từ 0 đến 10.", 0);
                }
            }

            // Thực thi Transaction lưu dữ liệu
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (DataRow row in dtKetQua.Rows)
                        {
                            string maSV = row["MaSV"].ToString();
                            double diem = Convert.ToDouble(row["Diem"]);
                            string ghiChu = row["GhiChu"]?.ToString() ?? "";

                            using (SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@MaSV", maSV);
                                cmd.Parameters.AddWithValue("@MaMon", maMon);
                                cmd.Parameters.AddWithValue("@Diem", diem);
                                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                                cmd.ExecuteNonQuery();
                                successCount++;
                            }
                        }

                        // Không có lỗi -> Commit transaction
                        transaction.Commit();
                        return (true, $"Đã lưu thành công điểm cho {successCount} sinh viên.", successCount);
                    }
                    catch (Exception ex)
                    {
                        // Gặp lỗi -> Rollback transaction
                        transaction.Rollback();
                        return (false, $"Lỗi Database: {ex.Message}. Đã khôi phục trạng thái cũ.", 0);
                    }
                }
            }
        }
    }
}
