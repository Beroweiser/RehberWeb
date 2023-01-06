using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehberWeb.Models.Context;
using RehberWeb.Models.Entities;

namespace RehberWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporController : ControllerBase
    {
        private readonly RehberDbContext _context;


        public RaporController(RehberDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var konumlar = _context.IletisimBilgileris.GroupBy(p => p.Konum).Select(s => s.Key).ToList();

            var data = from konum in konumlar
                       select new RaporData
                       {
                           Konum = konum,
                           KisiSayisi = _context.IletisimBilgileris.Where(p => p.Konum == konum).Count(),
                           TelefonSayisi = _context.IletisimBilgileris.Where(p => p.Konum == konum && p.TelefonNumarasi != "").Count(),
                       };

          
            var rapor = new Rapor
            {
                Raporun_Talep_Edildiği_Tarih = DateTime.Now.ToString("dd/MM/yyyy"),
                Raporun_Durumu = "Tamamlandı",
                Data = data.OrderBy(p => p.KisiSayisi).ToList()
            };
            _context.Rapors.Add(rapor);
            await _context.SaveChangesAsync();
            var rapors = await _context.Rapors.Include(p => p.Data).ToListAsync();
            return Ok(rapors);
        }
    }
}
