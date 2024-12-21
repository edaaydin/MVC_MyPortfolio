using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        // sayfaları parcalara ayırarak kullanmayı amaclar.
        public IViewComponentResult Invoke()
        {
            // asenkron : aynı anda birden fazla islemin yapılmasını saglayan ifadedir.
            // senkron : elindeki ilk isi bitirdikten sonra diger ise gecmesidir.
            return View();
        }
    }
}
