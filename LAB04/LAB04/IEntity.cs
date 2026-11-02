namespace LAB04
{
    /// <summary>
    /// Interface định nghĩa thuộc tính định danh Id cho các thực thể.
    /// Dùng làm ràng buộc kiểu (Generic Constraint) cho Repository<T>.
    /// </summary>
    public interface IEntity
    {
        string Id { get; }
    }
}
