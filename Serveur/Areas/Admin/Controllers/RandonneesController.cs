using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using arsoudServeur.Data;
using arsoudeServeur.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using arsoudeServeur.Controllers;
using arsoudeServeur.Services;

namespace arsoudeServeur.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Area("Admin")]
    public class RandonneesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private UtilisateursService _utilisateursService;

        public RandonneesController(ApplicationDbContext context, UtilisateursService utilisateursService) : base(utilisateursService)
        {
            _context = context;
            _utilisateursService = utilisateursService;
        }


       
    }
}
