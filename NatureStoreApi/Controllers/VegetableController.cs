using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatureStoreApi.DTOs;
using NatureStoreApi.Models;
using NatureStoreApi.Data;

namespace NatureStoreApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class VegetableController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VegetableController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vegetable?name=tomato&origin=local&minPrice=10&maxPrice=100
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VegetableDto>>> GetVegetables(
            [FromQuery] string? name,
            [FromQuery] string? origin,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice)
        {
            var query = _context.Vegetables.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(v => v.Name != null && v.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(origin))
            {
                query = query.Where(v => v.Origin != null && v.Origin.Contains(origin));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(v => v.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(v => v.Price <= maxPrice.Value);
            }

            var vegetables = await query.ToListAsync();

            var dtoList = vegetables.Select(v => new VegetableDto(
                v.Id,
                v.Name,
                v.Description,
                v.Origin,
                v.RipeOrNot,
                v.DateAvailable,
                v.Price
            ));

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VegetableDto>> GetVegetableById(int id)
        {
            var vegetable = await _context.Vegetables.FindAsync(id);

            if (vegetable == null)
            {
                return NotFound();
            }

            var dto = new VegetableDto(
                vegetable.Id,
                vegetable.Name,
                vegetable.Description,
                vegetable.Origin,
                vegetable.RipeOrNot,
                vegetable.DateAvailable,
                vegetable.Price
            );

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<VegetableDto>> CreateVegetable(VegetableDto dto)
        {

            var newVegetable = new Vegetable
            {
                Name = dto.Name,
                Description = dto.Description,
                Origin = dto.Origin,
                RipeOrNot = dto.RipeOrNot,
                DateAvailable = dto.DateAvailable,
                Price = dto.Price
            };

            _context.Vegetables.Add(newVegetable);
            await _context.SaveChangesAsync();

            var createdDto = new VegetableDto(
                newVegetable.Id,
                newVegetable.Name,
                newVegetable.Description,
                newVegetable.Origin,
                newVegetable.RipeOrNot,
                newVegetable.DateAvailable,
                newVegetable.Price
            );

            return CreatedAtAction(nameof(GetVegetableById), new { id = newVegetable.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVegetable(int id, [FromBody] UpdateVegetableDto updateDto)
        {
            // 1. Fetch the existing entity tracking from the database
            var vegetable = await _context.Vegetables.FindAsync(id);

            // 2. Return a 404 if the vegetable doesn't exist
            if (vegetable == null)
            {
                return NotFound();
            }

            // 3. Map the updated record properties onto the tracked entity
            vegetable.Name = updateDto.Name;
            vegetable.Origin = updateDto.Origin;
            vegetable.Price = updateDto.Price;
            vegetable.RipeOrNot = updateDto.RipeOrNot;
            vegetable.DateAvailable = updateDto.DateAvailable;

            // 4. Persist changes to the database
            await _context.SaveChangesAsync();

            // 5. Return 204 No Content as the update succeeded without needing a return body
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVegetable(int id)
        {
            // Step 1: Look up the vegetable entity in the database
            var vegetable = await _context.Vegetables.FindAsync(id);

            // Step 2: Return 404 Not Found if the record doesn't exist
            if (vegetable == null)
            {
                return NotFound();
            }

            // Step 3: Remove the record and commit changes asynchronously
            _context.Vegetables.Remove(vegetable);
            await _context.SaveChangesAsync();

            // Step 4: Return 204 No Content on success
            return NoContent();
        }


    }
}

