﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EE.KapsalonX.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EE.KapsalonX.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult Index()
        //{
        //    ViewBag.AlertMessage = status.Message;

        //    return View();
        //    //if (ModelState.IsValid)
        //    //{
        //    //    TempData[Constants.SuccessMessage] = $@"<p>Bedankt voor uw bericht, heer/mevrouw {viewModel.Achternaam}.<br /><br />
        //    //                                          We trachten u zo snel mogelijk een antwoord terug te sturen.<br /><br />
        //    //                                          Het KapsalonX-team";
        //    //    return new RedirectToActionResult("Index", "Contact", null);
        //    //}
        //    //else
        //    //{
        //    //    return View(viewModel);
        //    //}
        //}
    }
}