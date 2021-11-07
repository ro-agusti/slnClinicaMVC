using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCClinica.Models;
using MVCClinica.Data;
using System.Data.Entity;
using MVCClinica.Admin;

namespace MVCClinica.Controllers
{
    public class MedicoController : Controller
    {
        private ClinicaDbContext context = new ClinicaDbContext();

        // GET: Medico
        public ActionResult Index()
        {
            return View("Index", AdmMedico.Listar());
        }

        public ActionResult Create() 
        {
            Medico medico = new Medico();
            return View("Create", medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                //context.Medicos.Add(medico);
                //context.SaveChanges();
                AdmMedico.Insertar(medico);
                return RedirectToAction("Index");
            }
            return View("Create", medico);
        }

        public ActionResult Detail ( int id)
        {
            Medico medico = AdmMedico.TraerPorId(id);
            if (medico != null)
            {
                return View("Detail", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete (int id)
        {
            Medico medico = AdmMedico.TraerPorId(id);
            if (medico !=null)
            {
                return View("Delete", medico);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = AdmMedico.TraerPorId(id);
            AdmMedico.Eliminar(medico);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Medico medico = AdmMedico.TraerPorId(id);
            if (medico !=null)
            {
                return View("Edit");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Medico medico)
        {
            AdmMedico.Editar(medico);
            return RedirectToAction("Index");
        }

        public ActionResult DetailBySpeciality(string especialidad)
        {
            //var medicos = (
            //    from m in context.Medicos
            //    where m.Especialidad == especialidad
            //    select m
            //    ).ToList();
            return View("Index", AdmMedico.TraerPorEspecialidad(especialidad));
        }
    }
}