using System;

namespace Lab02_QuanLyMang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] arr = null;
            int luaChon;

            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chọn chức năng: ");

                // Kiểm tra ràng buộc: phải nhập mảng trước khi dùng các chức năng kh
                if (arr == null && luaChon >= 2 && luaChon <= 7)
                {
                    Console.WriteLine("\n Chưa khởi tạo Mảng. Vui lòng nhập mảng trước!");
                    DungManHinh();
                    continue;
                }

                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("\n--- NHẬP MẢNG ---");
                        arr = NhapMang();
                        Console.WriteLine("Nhập mảng thành công!");
                        break;

                    case 2:
                        Console.WriteLine("\n--- XUẤT MẢNG ---");
                        XuatMang(arr);
                        break;

                    case 3:
                        Console.WriteLine("\n--- TÍNH TỔNG ---");
                        Console.WriteLine($"Tổng các phần tử trong mảng = {TinhTong(arr)}");
                        break;

                    case 4:
                        Console.WriteLine("\n--- TÌM MAX / MIN ---");
                        Console.WriteLine($"Giá trị lớn nhất (Max) = {TimMax(arr)}");
                        Console.WriteLine($"Giá trị nhỏ nhất (Min) = {TimMin(arr)}");
                        break;

                    case 5:
                        Console.WriteLine("\n--- ĐẾM CHẴN / LẺ ---");
                        Console.WriteLine($"Số lượng phần tử chẵn = {DemChan(arr)}");
                        Console.WriteLine($"Số lượng phần tử lẻ = {DemLe(arr)}");
                        break;

                    case 6:
                        Console.WriteLine("\n--- SẮP XẾP TĂNG DẦN ---");
                        SapXepTangDan(arr);
                        Console.WriteLine("Mảng sau khi sắp xếp tăng dần:");
                        XuatMang(arr);
                        break;

                    case 7:
                        Console.WriteLine("\n--- TÌM KIẾM ---");
                        int x = NhapSoNguyen("Nhập giá trị x cần tìm: ");
                        int viTri = TimKiem(arr, x);
                        if (viTri != -1)
                        {
                            Console.WriteLine($"Tìm thấy {x} tại vị trí đầu tiên là chỉ số: {viTri}");
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy giá trị {x} trong mảng.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("\nChương trình kết thúc. Tạm biệt!");
                        break;

                    default:
                        Console.WriteLine("\n[!] Lựa chọn không hợp lệ. Vui lòng chọn từ 0 đến 7!");
                        break;
                }

                if (luaChon != 0)
                {
                    DungManHinh();
                }

            } while (luaChon != 0);
        }

        // CÁC PHƯƠNG THỨC XỬ LÝ 

        static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("***** MENU *****");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
        }

        static int NhapSoNguyen(string message)
        {
            int giaTri;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out giaTri))
                {
                    return giaTri;
                }
                Console.WriteLine("[!] Dữ liệu nhập vào phải là số nguyên. Vui lòng thử lại!");
            }
        }

        static int NhapSoNguyenDuong(string message)
        {
            int giaTri;
            while (true)
            {
                giaTri = NhapSoNguyen(message);
                if (giaTri > 0)
                {
                    return giaTri;
                }
                Console.WriteLine("[!] Giá trị phải là số nguyên dương (> 0). Vui lòng nhập lại!");
            }
        }

        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhập số lượng phần tử n: ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen($"Nhập phần tử thứ {i+1}: ");
            }
            return a;
        }

        static void XuatMang(int[] a)
        {
            Console.Write("Các phần tử trong mảng: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + (i == a.Length - 1 ? "" : ", "));
            }
            Console.WriteLine();
        }

        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach (int item in a)
            {
                tong += item;
            }
            return tong;
        }

        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
            }
            return max;
        }

        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min) min = a[i];
            }
            return min;
        }

        static int DemChan(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 == 0) count++;
            }
            return count;
        }

        static int DemLe(int[] a)
        {
            int count = 0;
            foreach (int item in a)
            {
                if (item % 2 != 0) count++;
            }
            return count;
        }

        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x) return i;
            }
            return -1;
        }

        static void DungManHinh()
        {
            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    }
}