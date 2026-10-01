using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Khóa ngoại kết nối sang bảng Order
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        [JsonIgnore] // Tránh lỗi vòng lặp JSON vô hạn khi Frontend gọi
        public virtual Order Order { get; set; }
    }
}
