using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using MVC.Managers;
using MVC.Models;

namespace MVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        public CurrencyController()
        {

        }


        [HttpGet]
        public IEnumerable<CurrencyModel> Get()
        {
            return new CurrencyManager().GetCurrencies();
        }
    }
}
