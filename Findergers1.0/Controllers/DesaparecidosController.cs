using Findergers1._0.Models;
using Findergers1._0.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Findergers1._0.Controllers
{
    public class DesaparecidosController : Controller
    {
        public IActionResult Index()
        {
            List<ListDesa> lst;
            using (FindergersContext db = new FindergersContext())
            {
                lst = (from d in db.Desaparecidos select new ListDesa
                {
                    Id = d.Id,
                    Nombre = d.Nombre,
                    Edad = d.Edad,
                    Descripcion = d.Descripcion,
                    FechaDesaparicion = d.FechaDesaparicion,
                    Imagen = d.Imagen,


                }).ToList();
                
            }
            return View(lst);
        }
        //Crear
        public ActionResult NewDesa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDesa(Desaparecido model)
        {
            if (ModelState.IsValid)
            {
                using (FindergersContext db = new FindergersContext())
                {
                    var oDesa = new Desaparecido();

                    oDesa.Id = model.Id;
                    oDesa.Nombre = model.Nombre;
                    oDesa.Edad = model.Edad;
                    oDesa.Descripcion = model.Descripcion;
                    oDesa.FechaDesaparicion = model.FechaDesaparicion;
                    oDesa.Imagen = model.Imagen;
                    db.Desaparecidos.Add(oDesa);
                    db.SaveChanges();

                }
                return Redirect("~/Desaparecidos/Index");
            }
            return View(model);
        }


        //Editar

        public ActionResult Edit(int Id)
        {
            Desaparecido model = new Desaparecido();
            using (FindergersContext db = new FindergersContext())
            {
                var oDesa = db.Desaparecidos.Find(Id);
                oDesa.Nombre = model.Nombre;
                oDesa.Edad = model.Edad;    
                oDesa.Descripcion = model.Descripcion;
                oDesa.FechaDesaparicion = model.FechaDesaparicion;
                oDesa.Imagen = model.Imagen;

            }
                return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Desaparecido model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (FindergersContext db = new FindergersContext())
                    {
                        var oDesa = db.Desaparecidos.Find(model.Id);
                        oDesa.Nombre = model.Nombre;
                        oDesa.Edad = model.Edad;
                        oDesa.Descripcion = model.Descripcion;
                        oDesa.FechaDesaparicion = model.FechaDesaparicion;
                        oDesa.Imagen = model.Imagen;

                        db.Entry(oDesa).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Desaparecidos/Index");
                }
                return View(model);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            using (FindergersContext db = new FindergersContext())
            {
                var oDesa = db.Desaparecidos.Find(Id);
                db.Desaparecidos.Remove(oDesa);
                db.SaveChanges();

            }
            return Redirect("~/Desaparecidos/Index");
        }

    }
}
