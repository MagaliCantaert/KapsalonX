using EE.KapsalonX.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Components
{
    [ViewComponent(Name = "MainNavigationAdmin")]
    public class MainNavAdminComponent : ViewComponent
    {
        private IEnumerable<MainNavLinkVm> adminLinks { get; set; }

        public MainNavAdminComponent()
        {
            adminLinks = new List<MainNavLinkVm>
            {
                new MainNavLinkVm { Area = null, Controller = "Home", Action = "Index", Text = "Home" },
                new MainNavLinkVm { Area = null, Controller = "Home", Action = "About", Text = "About" },
                new MainNavLinkVm { Area = null, Controller = "Contact", Action = "Index", Text = "Contact" },
                new MainNavLinkVm { Area = null, Controller = "Afspraak", Action = "Index", Text = "Afspraak maken" },
                new MainNavLinkVm { Area = null, Controller = "Admin", Action = "Index", Text = "Dashboard" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navLinks = adminLinks;

            foreach (var link in navLinks)
            {
                if (this.RouteData.Values["area"]?.ToString().ToLower() == link.Area?.ToLower()
                    &&
                    this.RouteData.Values["controller"]?.ToString().ToLower() == link.Controller.ToLower()
                    &&
                    this.RouteData.Values["action"]?.ToString().ToLower() == link.Action.ToLower())
                {
                    link.IsActive = true;
                }
            }
            return await Task.FromResult<IViewComponentResult>(View(navLinks));
        }
    }
}
