using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nuevo.modules.orders.dto;
using project.modules.orders.dto;
using project.modules.orders.models;
using project.utils;

namespace Nuevo.modules.orders
{
    [ApiController]
    [Route("api/orders")]
    public class orderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public orderController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] orderDto requestOrder)
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

            Order newOrder = _mapper.Map<Order>(requestOrder);
            newOrder.userUpdateId = idUser;
            newOrder.Status = OrderStatus.NEW;

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return Ok(newOrder);
        }

        [HttpGet("newOrderForCurrentUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetNewOrderForCurrentUser()
        {
            string idUser = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            var order = await _context.Orders
                .Where(o => o.userUpdateId == idUser && o.Status == OrderStatus.NEW)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return NotFound("Order Not Found!");
            }

            return Ok(order);
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] paymentReq paymentRequest)
        {
            string idUser = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";

            var order = await _context.Orders
                .Where(o => o.userUpdateId == idUser && o.Status == OrderStatus.NEW)
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
        public async Task<IActionResult> Track(int id)
        {
            var order = await _context.Orders.Include(o => o.AddressLatLng)
            .Include(o => o.Items)
            .ThenInclude(i => i.Food)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}