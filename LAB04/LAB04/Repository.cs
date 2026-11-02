using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB04
{
    /// <summary>
    /// Lớp Generic Repository quản lý tập hợp các thực thể có ràng buộc IEntity.
    /// </summary>
    /// <typeparam name="T">Kiểu thực thể kế thừa IEntity</typeparam>
    public class Repository<T> where T : class, IEntity
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Thêm mới một thực thể. Ném ra DuplicateProductException nếu Id đã tồn tại.
        /// </summary>
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Thực thể cần thêm không được null!");
            }

            if (FindById(entity.Id) != null)
            {
                throw new DuplicateProductException(entity.Id);
            }

            _items.Add(entity);
        }

        /// <summary>
        /// Xóa một thực thể theo Id. Ném ra ProductNotFoundException nếu không tìm thấy.
        /// </summary>
        public bool Remove(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Mã định danh không được để trống!", nameof(id));
            }

            var item = FindById(id);
            if (item == null)
            {
                throw new ProductNotFoundException(id);
            }

            return _items.Remove(item);
        }

        /// <summary>
        /// Tìm kiếm một thực thể theo Id chính xác.
        /// </summary>
        public T? FindById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;

            return _items.FirstOrDefault(x => x.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Tìm kiếm danh sách các thực thể thỏa mãn biểu thức điều kiện Func<T, bool>.
        /// </summary>
        public List<T> Find(Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Biểu thức điều kiện không được null!");
            }

            return _items.Where(predicate).ToList();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách thực thể.
        /// </summary>
        public List<T> GetAll()
        {
            return new List<T>(_items);
        }
    }
}
