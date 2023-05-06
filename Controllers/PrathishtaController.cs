using Microsoft.AspNetCore.Mvc;
using project_kshetham.Models;
using project_kshetham.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_kshetham.Controllers
{
    public class PrathishtaController : Controller
    {
        PrathishtaRepository repo = new PrathishtaRepository();
        public IActionResult Create()
        {
            ////List<PrathishtaVM> lstprathishta = new List<PrathishtaVM>();
            ////lstprathishta = repo.lstprathishta(0);
            return View();
        }

        public IActionResult Listprathishta()
         {
            List<PrathishtaVM> lst = repo.lstprathishta(0);
            return View(lst);
        }

        public IActionResult editprathishta(int prathishtacode)
        {
            List<PrathishtaVM> lstprathishta = new List<PrathishtaVM>();
            lstprathishta = repo.lstprathishta(prathishtacode);
            if (lstprathishta.Count > 0)
            {
                return View(lstprathishta[0]);
            }
            return View();
        }

        [HttpPost]

        public IActionResult Create(PrathishtaVM model)
        {
            Prathishta objprathishta = new Prathishta()
            {
               
                prathishta_name = model.prathishta_name

            };
            repo.insertprathishta(objprathishta);
            return View();

        }
        [HttpPost]
        public IActionResult editprathishta(PrathishtaVM model)
        {
            Prathishta objprathishta = new Prathishta()
            {
              prathishta_code=model.prathishta_code,
                prathishta_name = model.prathishta_name 

            };
            repo.editprathishta(objprathishta);
            return View(model);
        }
    }
}