using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]

    public class MenuController : ControllerBase
    {
        
        private readonly ICategoryRepository _repository;

        public MenuController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCatogories()
        {
            IReadOnlyList<Category> catogories = await _repository.GetCategoreiesAsync();

            return Ok(catogories);
        }

        [HttpGet("{id}")]
        public async   Task<ActionResult<Item>> GetItem(int id)
        {
            return await _repository.GetItemByIdAsync(id);
        }

        [HttpGet("items")]
        public async Task<ActionResult<IReadOnlyList<Item>>> GetItems()
        {
            return Ok(await _repository.GetItemsAsync());
        }
    }
}
