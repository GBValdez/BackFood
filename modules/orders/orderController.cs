using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.modules.orders.dto;
using project.modules.orders.models;
using project.utils;

namespace Nuevo.modules.orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class orderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public orderController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Order requestOrder)
        {
            if (requestOrder.Items.Count <= 0)
            {
                return BadRequest("Cart Is Empty!");
            }

            string idUser = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idUser == null)
            {
                return BadRequest("User Not Found!");
            }

            await _context.Orders
                .Where(o => o.userUpdateId == idUser && o.Status == OrderStatus.NEW)
                .ForEachAsync(o => _context.Orders.Remove(o));

            var newOrder = new Order
            {
                userUpdateId = idUser,
                Name = requestOrder.Name,
                Address = requestOrder.Address,
                AddressLatLng = requestOrder.AddressLatLng,
                PaymentId = requestOrder.PaymentId,
                TotalPrice = requestOrder.TotalPrice,
                Items = requestOrder.Items,
                Status = OrderStatus.NEW
            };

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return Ok(newOrder);
        }

        [HttpGet("newOrderForCurrentUser")]
        public async Task<IActionResult> GetNewOrderForCurrentUser()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (userId == null)
            {
                return BadRequest("User Not Found!");
            }

            var order = await _context.Orders
                .Where(o => o.userUpdateId == userId && o.Status == OrderStatus.NEW)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return BadRequest();
            }

            return Ok(order);
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] paymentReq paymentRequest)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (userId == null)
            {
                return NotFound("User Not Found!");
            }

            var order = await _context.Orders
                .Where(o => o.userUpdateId == userId && o.Status == OrderStatus.NEW)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return BadRequest("Order Not Found!");
            }

            order.PaymentId = paymentRequest.PaymentId;
            order.Status = OrderStatus.PAYED;

            await _context.SaveChangesAsync();

            return Ok(order.Id);
        }

        [HttpGet("track/{id}")]
        public async Task<IActionResult> Track(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}