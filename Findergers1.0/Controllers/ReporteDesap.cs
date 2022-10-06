using Findergers1._0.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Findergers1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class ReporteDesap : ControllerBase
    {
        private readonly FindergersContext _context;

        public ReporteDesap(FindergersContext context)
        {
            _context = context;
        }
        [HttpGet]
        [EnableCors("permitir")]
        //api/ReporteDesap
        public ActionResult Get()
        {
            using (Models.FindergersContext db = new Models.FindergersContext())
            {
                var lst = (from d in db.Desaparecidos select d).ToList();
                return Ok(lst);
            }
        }
        [HttpPost]
        [EnableCors("permitir")]
        public ActionResult Post([FromBody] Models.Request.ReportarDesapRequest model)
        {
            using (Models.FindergersContext db = new Models.FindergersContext())
            {
                Models.Desaparecido oDesaparecido = new Models.Desaparecido();
                
                oDesaparecido.Nombre = model.name;
                oDesaparecido.Edad = model.age;
                oDesaparecido.Descripcion = model.description;
                oDesaparecido.FechaDesaparicion = model.disappDate;
                oDesaparecido.Imagen = model.image;
                db.Desaparecidos.Add(oDesaparecido);
                db.SaveChanges();
            }
            return Ok();

        }
        [HttpPut]
        [EnableCors("permitir")]
        public ActionResult Put([FromBody] Models.Request.ReportDesapEditRequest model)
        {
            using (Models.FindergersContext db = new Models.FindergersContext())
            {
                Models.Desaparecido oDesaparecido = db.Desaparecidos.Find(model.id);

                oDesaparecido.Nombre = model.name;
                oDesaparecido.Edad = model.age;
                oDesaparecido.Descripcion = model.description;
                oDesaparecido.FechaDesaparicion = model.disappDate;
                oDesaparecido.Imagen = model.image;
                db.Entry(oDesaparecido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        [EnableCors("permitir")]
        public async Task<IActionResult> DeleteDesaparecido(int id)
        {
            var desaparecido = await _context.Desaparecidos.FindAsync(id);
            if (desaparecido == null)
            {
                return NotFound();
            }

            _context.Desaparecidos.Remove(desaparecido);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
