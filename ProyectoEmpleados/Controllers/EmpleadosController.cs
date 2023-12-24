using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProyectoEmpleados.Models;

namespace ProyectoEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly DbSegurosPacificoEntities db = new DbSegurosPacificoEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.ToList();
            foreach (var empleado in empleados)
            {
                CalcularSalarios(empleado);
            }

            return View(empleados);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleados = db.Empleados.Find(id);

            if (empleados == null)
            {
                return HttpNotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,HorasNormales,HorasExtras")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                CalcularSalarios(empleados);
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleados = db.Empleados.Find(id);

            if (empleados == null)
            {
                return HttpNotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,HorasNormales,HorasExtras,SalarioBruto,Deducciones,SalarioNeto")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleados empleados = db.Empleados.Find(id);

            if (empleados == null)
            {
                return HttpNotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void CalcularSalarios(Empleados empleados)
        {
            decimal salarioHoraNormal = 1800m;
            decimal salarioHoraExtra = salarioHoraNormal * 1.5m;

            decimal salarioBruto = ((empleados.HorasNormales ?? 0) * salarioHoraNormal) + ((empleados.HorasExtras ?? 0) * salarioHoraExtra);

            if (salarioBruto <= 250000)
            {
                empleados.Deducciones = salarioBruto * 0.09m;
            }
            else if (salarioBruto <= 380000)
            {
                empleados.Deducciones = salarioBruto * 0.12m;
            }
            else
            {
                empleados.Deducciones = salarioBruto * 0.15m;
            }

            empleados.SalarioNeto = salarioBruto - empleados.Deducciones;
            empleados.SalarioBruto = salarioBruto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
