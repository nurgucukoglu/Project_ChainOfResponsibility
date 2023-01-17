using Microsoft.AspNetCore.Mvc;
using Project_ChainOfResponsibility.ChainOfResponsibility;

namespace Project_ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(WithdrawViewModel p)
        {
            Employee treasurer = new Treasurer();//veznedar
            Employee managerAsistant = new ManagerAsistant();
            Employee manager = new BranchManager();
            Employee regionManager = new RegionManager();
            //her biri  bir sonraki adım için yönlendirilecek

            treasurer.SetNextApprover(managerAsistant);//veznenin sonraki adımı şube müdür yardımcısı
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(regionManager);

            treasurer.ProcessRequest(p);//Veznedardan itibaren parametreden gelen işlemi başlatır. 


            return View();
        }
    }
}
