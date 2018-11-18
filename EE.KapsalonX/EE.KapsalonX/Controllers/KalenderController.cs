using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EE.KapsalonX.Web.Controllers
{
    public class KalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}