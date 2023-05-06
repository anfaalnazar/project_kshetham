using Microsoft.AspNetCore.Mvc;
using project_kshetham.Models;
using project_kshetham.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_kshetham.Controllers
{
    public class UnitController : Controller
    {
        UnitRepository repo = new UnitRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult createunit()
        {
            return View();
        }
        public IActionResult Listunit()
        {
            List<unitVM> lst = repo.lstunit(0);
            return View(lst);
        }

        public IActionResult editunit(int unitcode)
        {
            List<unitVM> lstunit = new List<unitVM>();
            lstunit = repo.lstunit(unitcode);
            if (lstunit.Count > 0)
            {
                return View(lstunit[0]);
            }
            return View();
        }
        [HttpPost]

        public IActionResult createunit(unitVM model)
        {
            unit objunit = new unit()
            {

                unitname = model.unitname

            };
            repo.insertunit(objunit);
            return View();

        }

        [HttpPost]
        public IActionResult editunit(unitVM model)
        {
            unit objunit = new unit()
            {
                unitcode = model.unitcode,
                unitname = model.unitname

            };
            repo.editunit(objunit);
            return View(model);
        }
    }
}
