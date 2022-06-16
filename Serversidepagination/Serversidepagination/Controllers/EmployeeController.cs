using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serversidepagination.Models;

namespace Serversidepagination.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        private readonly   DBModels _db =  new DBModels();
        public ActionResult Index( int? page )
        {
            
            var data = (from s in _db.Employees select s);
            if (page > 0)
            {
                page = page; 
            }
            else
            {
                page = 1;
            }
            int limit = 3;  // display show 5 product 
            int start  = (int) (page - 1) * limit;
           int totalProduct = data.Count();
            ViewBag.totalProduct = totalProduct;
            ViewBag.pageCurrent = page;
            int numberpage = (totalProduct / limit);
            ViewBag.numberpage = numberpage;    
            var dataProduct = data.OrderBy(s => s.EmployeeId).Skip(start).Take(limit);
             
                return View(dataProduct.ToList());
        }
    }
}