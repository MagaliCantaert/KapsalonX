using EE.KapsalonX.Web.Models;
using EE.KapsalonX.Web.Services;
using EE.KapsalonX.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Services
{
    public class AfspraakBehandelingenService : IAfspraakService
    {
        public async Task<IEnumerable<Behandeling>> AlleBehandelingen()
        {
            await Task.Delay(0);
            return new List<Behandeling>
            {
                new Behandeling
                {
                    Geslacht = "Vrouw",
                    Coupe = "Kort haar",
                    Optie = "Knippen"
                }
            };
        }
    }
}
