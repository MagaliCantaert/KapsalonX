using EE.KapsalonX.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Components
{
    [ViewComponent(Name = "Afspraak")]
    public class AfspraakComponent : ViewComponent
    {
        private IAfspraakService _afspraakService;

        public AfspraakComponent(IAfspraakService afspraakService)
        {
            this._afspraakService = afspraakService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var behandelingen = await _afspraakService.AlleBehandelingen();
            return View(behandelingen);
        }
    }
}
