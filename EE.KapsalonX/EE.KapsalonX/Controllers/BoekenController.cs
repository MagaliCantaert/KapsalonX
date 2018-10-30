using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EE.KapsalonX.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace EE.KapsalonX.Web.Controllers
{
    public class BoekenController : Controller
    {
        const string STATEKEY = "SessionOpties";

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

        public IActionResult Index(BoekenIndexVm viewModel)
        {         
            viewModel.BehandelingenDames = BehandelingenDames;
            viewModel.BehandelingenHeren = BehandelingenHeren;
            viewModel.BehandelingenKinderen = BehandelingenKinderen;

            viewModel.Cart = new List<BehandelingVm>();

            string serialized = HttpContext.Session.GetString(STATEKEY);
            if (serialized != null)
            {
                viewModel.Cart = JsonConvert.DeserializeObject<List<BehandelingVm>>(serialized);
            }
            return View("Index", viewModel);
        }
     
        public IActionResult Kalender(BoekenIndexVm viewModel)
        {

            BehandelingVm selectedBehandeling = BehandelingenDames.FirstOrDefault();
            if (selectedBehandeling == null)
            {
                return RedirectToAction("Index");
            }

            string serialized = HttpContext.Session.GetString(STATEKEY);
            List<BehandelingVm> behandelingList = new List<BehandelingVm>();
            if (serialized != null)
            {
                behandelingList = JsonConvert.DeserializeObject<List<BehandelingVm>>(serialized);
            }
            behandelingList.Add(selectedBehandeling);
            viewModel.Cart = behandelingList;
            serialized = JsonConvert.SerializeObject(behandelingList);
            HttpContext.Session.SetString(STATEKEY, serialized);
            return View(viewModel);
        }
    }

}