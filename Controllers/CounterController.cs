using Microsoft.AspNetCore.Mvc;
using project_kshetham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project_kshetham.repositories;

namespace project_kshetham.Controllers
{
    public class CounterController : Controller
    {
        CounterRepository repo = new CounterRepository();
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ListCounters()
        {
            List<CounterVM> lst = repo.listcounter(0);
            return View(lst);
        }
        public IActionResult editcounter(int counter_code)
        {
            List<CounterVM> lstcounter = new List<CounterVM>();
            lstcounter = repo.listcounter(counter_code);
            if (lstcounter.Count > 0)
            {
                return View(lstcounter[0]);
            }
            return View();
        }
        [HttpPost]

        public IActionResult Create(CounterVM model)
        {
            Counter objctr = new Counter()
            {

               counters = model.counters

            };
            repo.insertcounter(objctr);
            return View();

        }
        [HttpPost]
        public IActionResult editcounter(CounterVM model)
        {
            Counter objctr = new Counter()
            {
               counter_code = model.counter_code,
                counters = model.counters

            };
            repo.editcounter(objctr);
            return View(model);
        }
    }
}
