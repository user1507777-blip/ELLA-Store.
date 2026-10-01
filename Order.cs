using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        // --- THÔNG TIN KHÁCH ĐẶT HÀNG ---
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        // --- THÔNG TIN TỔNG QUAN ĐƠN HÀNG ---
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Một Đơn hàng chứa danh sách nhiều Sản phẩm
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
