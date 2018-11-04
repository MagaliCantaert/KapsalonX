using EE.KapsalonX.Web.Models;
using EE.KapsalonX.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Services
{
    public interface IAfspraakService
    {
        Task<IEnumerable<Behandeling>> AlleBehandelingen();

    }
}
