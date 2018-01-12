using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using space_flight.Models;
using Microsoft.EntityFrameworkCore;

namespace space_flight.Controllers
{
    public class ItemController : Controller
    {
		private IItemRepository itemRepo;

        public ItemController(IItemRepository repo = null)
        {
            if(repo == null)
            {
                this.itemRepo = new EFItemRepository();
            }
            else
            {
                this.itemRepo = repo;
            }
        }

        public ViewResult Index()
        {
            return View(itemRepo.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            CrewReq thisItem = itemRepo.Items.FirstOrDefault(x => x.Id == id);
            return View(thisItem); 
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(CrewReq item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            CrewReq thisItem = itemRepo.Items.FirstOrDefault(x => x.Id == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(CrewReq item)
        {
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            CrewReq thisItem = itemRepo.Items.FirstOrDefault(x =>x.Id == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            CrewReq thisItem = itemRepo.Items.FirstOrDefault(x => x.Id == id);
            itemRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }
    }
}
