using System;
using System.Data.Entity; // <-- 1. Nhớ chèn thêm dòng này ở ĐẦU FILE luôn nhé!
using System.Linq;
using System.Web.Http;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly AppDbContext _context = new AppDbContext();

        
        [HttpPost]
        [Route("checkout")]
        public IHttpActionResult Checkout([FromBody] Order order)
        {
            // ... nội dung hàm checkout giữ nguyên ...
            _context.SaveChanges();
            return Ok(new { success = true, message = "..." });
        } // <-- Dấu ngoặc nhọn kết thúc hàm Checkout cũ

        
        [HttpGet]
        [Route("admin/list")]
        public IHttpActionResult GetAllOrders()
        {
            try
            {
                var orders = _context.Orders
                                     .Include(o => o.OrderItems)
                                     .OrderByDescending(o => o.CreatedAt)
                                     .ToList();

                return Ok(new { success = true, data = orders });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing) { _context.Dispose(); }
            base.Dispose(disposing);
        }

    }
}
