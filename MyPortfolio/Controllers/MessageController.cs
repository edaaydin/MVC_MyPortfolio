using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var value = context.Messages.ToList();
            return View(value);
        }

        public IActionResult ChangeIsReadToTrue(int id) //okunduya degistir
        {
            var value = context.Messages.Find(id);
            value.IsRead = true; // okundu ise true yap!
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult ChangeIsReadToFalse(int id) // okunmadıya degidtir
        {
            var value = context.Messages.Find(id);
            value.IsRead = false; // okunmadı ise false yap!
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult DeleteMessage(int id) // mesaj silme islemi
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
    }
}
