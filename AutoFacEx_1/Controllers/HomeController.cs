using AutoFacEx_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFacEx_1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IClientService _service;

        public HomeController( IClientService clientService )
        {
            _service = clientService;
        }

        public ActionResult Index( ClientService clientServices )
        {
            
            return View( clientServices.GetClients() );
        }

    }
}
