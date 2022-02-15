using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using SistemaWebVuelos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        private VueloDbContext context = new VueloDbContext();
        //Trae un listado de los vuelos
        // GET: Vuelo
        //se accede por : /Vuelo/Index
        public ActionResult Index()

        {
            var vuelos = AdminVuelo.TraerVuelos();
            return View(vuelos);
        }

        public ActionResult Home()

        {
            ViewBag.FechaHora = DateTime.Now.ToLongDateString();
            ViewBag.Bienvenido = "Bienvenido a la app";
            return View("Home");
        }

        //TRAER POR MATRICULA
        //GET
        //se accede por : /Vuelo/Matricula/{matricula}

        public ActionResult Detalle(string matricula)
        {
            var vuelo = AdminVuelo.TraerMatricula(matricula);
            if (vuelo != null)
            {
                return View("Detalle", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //AGREGAR VUELO
        //GET
        // SE ACCEDE POR VUELO/AGREGAR

        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }

        //POST AGREGAR

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                AdminVuelo.Agregar(vuelo);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", vuelo);

            }
        }
         
        //ELIMINAR x ID
         
        public ActionResult Delete(int matricula)
        {
            var vuelo = AdminVuelo.TraerId(matricula);
            if (vuelo != null)
            {
                return View("DeleteConfirm", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int matricula)
        {
            var vuelo = AdminVuelo.TraerId(matricula);
            if (vuelo != null)
            {

                AdminVuelo.Eliminar(vuelo);
                return RedirectToAction("Index");
            }
            return View(vuelo);
        }

        //EDITAR x ID

        public ActionResult Edit(int matricula)
        {
            var vuelo = AdminVuelo.TraerId(matricula);
            if (vuelo != null)
            {
                return View("Edit", vuelo);

            }
            else
            {
                return View(vuelo);
            }

        }

        [HttpPost]
        public ActionResult Edit(Vuelo vuelo) { 
           
        
            if (vuelo != null)
            {
                AdminVuelo.Modificar(vuelo);
                return RedirectToAction("Index");

            }
            else
            {
                return View(vuelo);
            }

        }

        public ActionResult TraerPorDestino(string matricula)
        {
            var vuelo = (from v in context.Vuelos where v.Destino == matricula select v).ToList();
            if (vuelo != null)
            {
                
                return View("DetalleDestino", vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }







    }
}
