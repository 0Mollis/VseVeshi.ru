using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("MakeOrder", Name = "MakeOrder")]

        public async Task<IActionResult> makeOrder(AddToOrderModel model)
        {
            var order = new Orders();
            var userId = _userManager.GetUserId(User);

            order.User = await _userManager.GetUserAsync(User);
            order.Addres = model.Addres;
            order.Status = "Создан";
            order.TotalPrice = model.TotalPrice;
            order.TypeOfOrder = model.TypeOfOrder;
            order.TimeOfOrder = model.Time;

            _context.Orders.Add(order);
            _context.SaveChanges();

            List<OrderItems> orders = new List<OrderItems>();
            List<Cart> cartData = _context.carts.Include(x => x.RentItems).Where(x => x.User.Id == userId).ToList();

            foreach (var cart in cartData) {
                orders.Add(new OrderItems { Orders = order, RentItems = cart.RentItems, Quantity = cart.quantity });
            }
       
            _context.OrderItems.AddRange(orders);
            _context.SaveChanges();

            _context.carts.RemoveRange(_context.carts.Where(x => x.User.Id == userId));
            _context.SaveChanges();

            return Ok();
        }
        
        [HttpGet("orders", Name = "orders")]

        public List<Orders> GetOrders()
        {
            return _context.Orders.Include(x => x.User).ToList();
        }

        [HttpPut]

        public void Put([FromBody] int orderId)
        {
            var order = _context.Orders.Where(x => x.Id == orderId).FirstOrDefault();

            order.Status = "Выполнено";
            _context.Update(order);
            _context.SaveChanges();
        }
    }
}
