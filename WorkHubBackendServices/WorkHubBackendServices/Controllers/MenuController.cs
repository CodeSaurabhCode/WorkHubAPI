using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Repository;

namespace WorkHubBackEndServices.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class MenuController : ControllerBase
    {
        
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Item> _itemRepo;

        public MenuController(IGenericRepository<Category> categoryRepo, IGenericRepository<Item> itemRepo)
        {
            _categoryRepo = categoryRepo;
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCatogories()
        {
            IReadOnlyList<Category> catogories = await _categoryRepo.ListAllAsync();

            return Ok(catogories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var spec = new ItemsWithCategorySpecification(id);
            return await _itemRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("items")]
        public async Task<ActionResult<IReadOnlyList<Item>>> GetItems()
        {
            var spec = new ItemsWithCategorySpecification();
            return Ok(await _itemRepo.ListAsync(spec));
        }
    }
}
