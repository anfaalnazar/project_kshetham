using Microsoft.AspNetCore.Mvc;
using project_kshetham.Models;
using project_kshetham.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_kshetham.Controllers
{
    public class NakshathramController : Controller
    {
        NakshathramRepository repo = new NakshathramRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListNakshathram()
        {
            List<NakshathramVM> lst = repo.lstnakshathram(0);
            return View(lst);
        }

        public IActionResult editnakshathram(int nakshathramcode)
        {
            List<NakshathramVM> lstnakshathram = new List<NakshathramVM>();
            lstnakshathram = repo.lstnakshathram(nakshathramcode);
            if (lstnakshathram.Count > 0)
            {
                return View(lstnakshathram[0]);
            }
            return View();
        }

        [HttpPost]

        public IActionResult Index(NakshathramVM model)
        {
            Nakshathram objstar = new Nakshathram()
            {

                nakshathram_name = model.nakshathram_name

            };
            repo.insertnakshathram(objstar);
            return View();

        }

        
    }
}
