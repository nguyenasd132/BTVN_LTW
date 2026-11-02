using System;

namespace LAB04
{
    /// <summary>
    /// Ngoại lệ phát sinh khi cố gắng thêm một sản phẩm có mã đã tồn tại trong kho.
    /// </summary>
    public class DuplicateProductException : Exception
    {
        public string ProductId { get; }

        public DuplicateProductException(string productId)
            : base($"Sản phẩm với mã '{productId}' đã tồn tại trong hệ thống!")
        {
            ProductId = productId;
        }

        public DuplicateProductException(string productId, string message)
            : base(message)
        {
            ProductId = productId;
        }
    }

    /// <summary>
    /// Ngoại lệ phát sinh khi tìm kiếm, xóa hoặc sửa một sản phẩm không tồn tại trong kho.
    /// </summary>
    public class ProductNotFoundException : Exception
    {
        public string ProductId { get; }

        public ProductNotFoundException(string productId)
            : base($"Không tìm thấy sản phẩm có mã '{productId}' trong hệ thống!")
        {
            ProductId = productId;
        }

        public ProductNotFoundException(string productId, string message)
            : base(message)
        {
            ProductId = productId;
        }
    }
}
