using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB04
{
    /// <summary>
    /// Service xử lý nghiệp vụ sản phẩm, quản lý Repository và phát các sự kiện (Events/Action events).
    /// </summary>
    public class ProductService
    {
        private readonly Repository<Product> _repo = new Repository<Product>();

        /// <summary>
        /// Sự kiện phát ra khi một sản phẩm được thêm thành công vào kho.
        /// </summary>
        public event Action<Product>? OnProductAdded;

        /// <summary>
        /// Sự kiện phát ra khi một sản phẩm được xóa thành công khỏi kho (truyền mã sản phẩm).
        /// </summary>
        public event Action<string>? OnProductRemoved;

        public ProductService()
        {
        }

        /// <summary>
        /// Nạp dữ liệu mẫu ban đầu để thuận tiện cho việc kiểm thử.
        /// </summary>
        public void SeedSampleData()
        {
            if (_repo.GetAll().Count == 0)
            {
                AddProduct(new Product("SP01", "Chuột Logitech G102", 450000m, 35));
                AddProduct(new Product("SP02", "Bàn phím DareU EK87", 650000m, 20));
                AddProduct(new Product("SP03", "Tai nghe Sony WH-CH520", 1290000m, 15));
                AddProduct(new Product("SP04", "Màn hình LG 24 inch IPS", 2850000m, 10));
                AddProduct(new Product("SP05", "Bàn di chuột Razer", 220000m, 50));
            }
        }

        /// <summary>
        /// Thêm sản phẩm mới và kích hoạt sự kiện OnProductAdded.
        /// </summary>
        public void AddProduct(Product p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p), "Sản phẩm không được null!");
            }

            _repo.Add(p); // Có thể ném DuplicateProductException

            // Phát sự kiện thông báo thêm thành công
            OnProductAdded?.Invoke(p);
        }

        /// <summary>
        /// Xóa sản phẩm theo mã và kích hoạt sự kiện OnProductRemoved.
        /// </summary>
        public void RemoveProduct(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Mã sản phẩm cần xóa không được để trống!", nameof(id));
            }

            _repo.Remove(id); // Có thể ném ProductNotFoundException

            // Phát sự kiện thông báo xóa thành công
            OnProductRemoved?.Invoke(id.Trim());
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo mã chính xác.
        /// </summary>
        public Product? FindById(string id)
        {
            return _repo.FindById(id);
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo tên sử dụng biểu thức điều kiện Func<Product, bool>.
        /// </summary>
        public List<Product> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<Product>();
            }

            Func<Product, bool> predicate = p => p.TenSP.IndexOf(keyword.Trim(), StringComparison.OrdinalIgnoreCase) >= 0;
            return _repo.Find(predicate);
        }

        /// <summary>
        /// Lọc danh sách sản phẩm theo khoảng giá [minPrice, maxPrice] sử dụng Func<Product, bool>.
        /// </summary>
        public List<Product> FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice)
            {
                throw new ArgumentException("Giá nhỏ nhất không được lớn hơn giá lớn nhất!");
            }

            Func<Product, bool> priceFilter = p => p.Price >= minPrice && p.Price <= maxPrice;
            return _repo.Find(priceFilter);
        }

        /// <summary>
        /// Tính tổng giá trị toàn bộ sản phẩm hiện có trong kho: Tổng = sum(Đơn giá * Số lượng).
        /// </summary>
        public decimal GetTotalInventoryValue()
        {
            return _repo.GetAll().Sum(p => p.Price * p.Quantity);
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm.
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }
    }
}
