using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehberWeb.Models.Context;
using RehberWeb.Models.Dtos;
using RehberWeb.Models.Entities;

namespace RehberWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RehbersController : ControllerBase
    {
        
        private readonly RehberDbContext _context;
        private readonly IMapper _mapper;
        public RehbersController(RehberDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(RehberDto rehberDto)
        {
            Rehber rehber = _mapper.Map<Rehber>(rehberDto);
            await _context.Rehbers.AddAsync(rehber);
            await _context.SaveChangesAsync();
            return Ok("Kayıt işlemi başarılı");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RehberDto rehberDto)
        {
            Rehber rehber = await _context.Rehbers.FindAsync(id);
            rehber.Firma = rehberDto.Firma;
            rehber.Ad = rehberDto.Ad;
            rehber.Soyad = rehberDto.Soyad;
            await _context.SaveChangesAsync();
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Rehber rehber = await _context.Rehbers.FindAsync(id);
            _context.Rehbers.Remove(rehber);
            await _context.SaveChangesAsync();
            return Ok("Silme işlemi başarılı");

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Rehber> rehbers = await _context.Rehbers.Include(p=> p.IletisimBilgileri).ToListAsync();
            return Ok(rehbers); 
        }
    }
}
