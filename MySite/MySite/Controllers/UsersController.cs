﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySite.Models
{
    public class UsersController : Controller
    {
        // GET: UsersController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
