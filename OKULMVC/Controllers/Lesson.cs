using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OKULMVC.Models;

namespace OKULMVC.Controllers
{
    public class Lesson : Controller
    {
        public IActionResult Index()
        {
            List<Ders> lst = null;
            using (var ctx = new OkulDbcontext())
            {
                lst = ctx.Dersler.ToList();
            }
            return View(lst);
        }
        [HttpGet]
        public IActionResult AddLesson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddLesson(Ders der)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new OkulDbcontext())
                {
                    ctx.Dersler.Add(der);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult EditLesson(int id)
        {
            Ders der = null;
            using (var ctx = new OkulDbcontext())
            {
                der = ctx.Dersler.Find(id);

            }
            return View(der);
        }
        [HttpPost]
        public IActionResult EditLesson(Ders der)
        {
            using (var ctx = new OkulDbcontext())
            {
                ctx.Entry(der).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteLesson(int id)
        {
            using (var ctx = new OkulDbcontext())
            {
                ctx.Dersler.Remove(ctx.Dersler.Find(id));
                ctx.SaveChanges();

            }
            return RedirectToAction("Index");

        }
    }
}
