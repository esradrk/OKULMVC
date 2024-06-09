using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OKULMVC.Models;

namespace OKULMVC.Controllers
{
    public class StudentLesson : Controller
    {
        public IActionResult Index()
        {
            List<DersOgrenci> lst = null;
            using (var ctx = new OkulDbcontext())
            {
                lst = ctx.StudentCourses
                          .Include(sc => sc.Student)
                          .Include(sc => sc.Course)
                          .ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public IActionResult Dersatama()
        {
            using (var ctx = new OkulDbcontext())
            {
                ViewBag.Ogrenciler = ctx.Ogrenciler.ToList();
                ViewBag.Dersler = ctx.Dersler.ToList();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Dersatama(int ogrenciId, int dersId)
        {
            using (var ctx = new OkulDbcontext())
            {
                bool dersZatenAtanmis = ctx.StudentCourses
                    .Any(sc => sc.Ogrenciid == ogrenciId && sc.Dersid == dersId);

                if (!dersZatenAtanmis)
                {
                    var dersogr = new DersOgrenci
                    {
                        Ogrenciid = ogrenciId,
                        Dersid = dersId
                    };

                    ctx.StudentCourses.Add(dersogr);
                    ctx.SaveChanges();
                }
                else
                {
                    ViewBag.ErrorMessage = "Bu ders zaten atanmış.";
                }
            }
            return RedirectToAction("Index");
        }
    }
}