using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EE.KapsalonX.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using static EE.KapsalonX.Web.Models.BoekenIndexVm;

namespace EE.KapsalonX.Web.Controllers
{
    public class BoekenController : Controller
    {
        //const string STATEKEY = "SessionOpties";

        List<BehandelingVm> BehandelingenDames = new List<BehandelingVm>
        {
            new BehandelingVm {Coupe = "Kort haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingVm {Coupe = "Kort haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(00,45,00)},
            new BehandelingVm {Coupe = "Kort haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingVm {Coupe = "Kort haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,15,00)},
            new BehandelingVm {Coupe = "Kort haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(01,45,00)},

            new BehandelingVm {Coupe = "Lang haar", Optie = "Knippen", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingVm {Coupe = "Lang haar", Optie = "Kleuren", Tijdsduur = new TimeSpan(01,00,00)},
            new BehandelingVm {Coupe = "Lang haar", Optie = "Brushing", Tijdsduur = new TimeSpan(00,40,00)},
            new BehandelingVm {Coupe = "Lang haar", Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,40,00)},
            new BehandelingVm {Coupe = "Lang haar", Optie = "Knippen + kleuren + brushing", Tijdsduur = new TimeSpan(02,20,00)}
        };
        List<BehandelingVm> BehandelingenHeren = new List<BehandelingVm>
        {
            new BehandelingVm { Optie = "Snit", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingVm { Optie = "Tondeuse", Tijdsduur = new TimeSpan(00,30,00) },
            new BehandelingVm { Optie = "Knippen + kleuren", Tijdsduur = new TimeSpan(01,00,00)}
        };
        List<BehandelingVm> BehandelingenKinderen = new List<BehandelingVm>
        {
            new BehandelingVm { Optie = "Snit meisjes", Tijdsduur = new TimeSpan(00,30,00)},
            new BehandelingVm { Optie = "Snit jongens", Tijdsduur = new TimeSpan(00,30,00)}
        };

        List<BehandelingVm> Behandelingen { get; set; }


        public IActionResult Index()
        {
            var viewModel = new BoekenIndexVm();
            viewModel.BehandelingenDames = BehandelingenDames;
            //viewModel.BehandelingenHeren = BehandelingenHeren;
            //viewModel.BehandelingenKinderen = BehandelingenKinderen;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(BoekenIndexVm vm)
        {
            vm.BehandelingenDames = BehandelingenDames;
            return View(vm);
        }


        public IActionResult Submit(BoekenIndexVm viewModel)
        {
            var submitVm = new BoekenIndexVm
            {
                Geslacht = viewModel.Geslacht,
                BehandelingenDames = viewModel.BehandelingenDames,
                BehandelingenHeren = viewModel.BehandelingenHeren,
                BehandelingenKinderen = viewModel.BehandelingenKinderen             
            };
            return View(viewModel);
           
        }

     
        //public IActionResult Kalender(BoekenIndexVm viewModel)
        //{

        //    BehandelingVm selectedBehandeling = BehandelingenDames.FirstOrDefault();
        //    if (selectedBehandeling == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    //string serialized = HttpContext.Session.GetString(STATEKEY);
        //    List<BehandelingVm> behandelingList = new List<BehandelingVm>();
        //    //if (serialized != null)
        //    //{
        //    //    behandelingList = JsonConvert.DeserializeObject<List<BehandelingVm>>(serialized);
        //    //}
        //    behandelingList.Add(selectedBehandeling);
        //    viewModel.Cart = behandelingList;
        //    //serialized = JsonConvert.SerializeObject(behandelingList);
        //    //HttpContext.Session.SetString(STATEKEY, serialized);
        //    return View(viewModel);
        //}
    }

}