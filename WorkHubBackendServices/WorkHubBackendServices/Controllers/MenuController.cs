using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Dtos;
using WorkHubBackEndServices.Helpers;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Repository;

namespace WorkHubBackEndServices.Controllers
{

    public class MenuController : BaseApiController
    {
        
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Item> _itemRepo;
        private readonly IMapper _mapper;

        public MenuController(IGenericRepository<Category> categoryRepo, IGenericRepository<Item> itemRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _itemRepo = itemRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCatogories()
        {
            IReadOnlyList<Category> catogories = await _categoryRepo.ListAllAsync();

            return Ok(catogories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemToReturnDto>> GetItem(int id)
        {
            var spec = new ItemsWithCategorySpecification(id);
            var Item =  await _itemRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Item, ItemToReturnDto>(Item);
        }

        [HttpGet("items")]
        public async Task<ActionResult<Pagination<ItemToReturnDto>>> GetItems([FromQuery]ItemSpecParams itemParams)
        {
            var spec = new ItemsWithCategorySpecification(itemParams);

            var countSpec = new ItemsWithFilterForCountSpecifications(itemParams);

            var totalItems = await _itemRepo.CountAsync(countSpec);

            var items = await _itemRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Item> ,  IReadOnlyList<ItemToReturnDto>>(items);

            return Ok(new  Pagination<ItemToReturnDto>(itemParams.PageIndex, itemParams.PageSize, totalItems, data));
        }
    }
}
