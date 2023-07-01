using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Dtos;
using WorkHubBackEndServices.Helpers;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Order> _orderRepo;

        public OrdersController(IOrderService orderService, IMapper mapper, IGenericRepository<Order> orderRepo)
        {
            _orderService = orderService;
            _mapper = mapper;
            _orderRepo = orderRepo;
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

        public async Task<ActionResult<Pagination<OrderToReturnDto>>> GetAllOrderForEmployee([FromQuery]OrderSpecParams? pageParams)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var orders = await _orderService.GetOrdersForEmployeeAsync(email, pageParams);

            var countSpec = new OrdersCountSpecifications(email);

            var totalItems = await _orderRepo.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(orders);

            return Ok(new Pagination<OrderToReturnDto>(pageParams.PageIndex, pageParams.PageSize, totalItems, data));
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

        [HttpGet("OrderTypes/{id}")]

        public async Task<ActionResult<IReadOnlyList<OrderType>>> GetOrderTypes(int id)
        {
            return Ok(await _orderService.GetOrderTypeByIdAsync(id));
        }


    }
}

