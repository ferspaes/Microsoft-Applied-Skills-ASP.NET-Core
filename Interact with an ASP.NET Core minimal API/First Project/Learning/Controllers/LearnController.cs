using Learning.Domain.Models;
using Learning.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearnController : Controller
    {
        private readonly IPetService _petsInMemoryStore;

        public LearnController(IPetService petService)
        {
            _petsInMemoryStore = petService;
        }

        [HttpPost(Name = "Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Pet pet)
        {
            var result = await _petsInMemoryStore.Create(pet);

            return CreatedAtAction(nameof(_petsInMemoryStore.Create), result);
        }
    }
}
