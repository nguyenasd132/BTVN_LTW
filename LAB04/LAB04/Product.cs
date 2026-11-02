using System;

namespace LAB04
{
    /// <summary>
    /// Lớp Product đại diện cho một sản phẩm trong hệ thống, thực thi IEntity.
    /// </summary>
    public class Product : IEntity
    {
        private decimal _price;
        private int _quantity;

        public string MaSP { get; set; } = string.Empty;

        // Triển khai thuộc tính Id từ IEntity
        public string Id => MaSP;

        public string TenSP { get; set; } = string.Empty;

        /// <summary>
        /// Đơn giá sản phẩm: không được mang giá trị âm (< 0).
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Đơn giá sản phẩm không được mang giá trị âm (< 0)!");
                }
                _price = value;
            }
        }

        /// <summary>
        /// Số lượng tồn kho: không được mang giá trị âm (< 0).
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số lượng tồn kho không được nhỏ hơn 0!");
                }
                _quantity = value;
            }
        }

        public Product()
        {
        }

        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                throw new ArgumentException("Mã sản phẩm không được để trống!", nameof(maSP));
            }
            if (string.IsNullOrWhiteSpace(tenSP))
            {
                throw new ArgumentException("Tên sản phẩm không được để trống!", nameof(tenSP));
            }

            MaSP = maSP.Trim();
            TenSP = tenSP.Trim();
            Price = price;       // Kích hoạt setter validation
            Quantity = quantity; // Kích hoạt setter validation
        }

        public override string ToString()
        {
            return $"Mã: {MaSP,-8} | Tên: {TenSP,-22} | Đơn giá: {Price,12:N0} VNĐ | Số lượng: {Quantity,4} | Thành tiền: {(Price * Quantity),14:N0} VNĐ";
        }
    }
}
