using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller // deneyim ekle, sil,guncelle gibi alanla olacak
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult ExperienceList()
        {
            var values = context.Experiences.ToList(); // deneyimleri listeleme
            return View(values);
        }

        [HttpGet] // sayfa ilk acıldıgında/yuklendiginde calısacak.
        public IActionResult CreateExperience()
        {
            return View();

        }

        [HttpPost] //bu sayfada bir butona tıklandıgı zaman calısacak.(tetiklenme oldugunda)
        public IActionResult CreateExperience(Experience experience)
        {
            context.Experiences.Add(experience);
            context.SaveChanges();
            return RedirectToAction("ExperienceList"); // beni tekrardan bu sayfaya gonder
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = context.Experiences.Find(id);
            context.Experiences.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ExperienceList"); // beni tekrardan bu sayfaya gonder
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = context.Experiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            context.Experiences.Update(experience);
            context.SaveChanges();
            return RedirectToAction("ExperienceList"); // beni tekrardan bu sayfaya gonder
        }
    }
}
