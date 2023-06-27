using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Dtos;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrderAsync(OrderDto orderDto)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var order = await _orderService.CreateOrderAsync(email, orderDto.OrderForDate, orderDto.OrderTypeId, orderDto.BasketId);

            if (order == null) { return BadRequest(); }


            return Ok(order);
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetAllOrderForEmployee()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var orders = await _orderService.GetOrdersForEmployeeAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(int id)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var order = await _orderService.GetOrderByIdAsync(id, email);

            return Ok(_mapper.Map<OrderToReturnDto>(order));
        }

        [HttpGet("OrderTypes")]

        public async Task<ActionResult<IReadOnlyList<OrderType>>> GetOrderTypes()
        {
            return Ok(await _orderService.GetOrderTypesAsync());
        }


    }
}

