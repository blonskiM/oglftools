using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OGTools.Server.Services;
using OGTools.Shared;

namespace OGTools.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipFlightController : Controller
    {
        private readonly IShipFlightTimeService _shipFlightTimeService;

        public ShipFlightController(IShipFlightTimeService shipFlightTimeService)
        {
            _shipFlightTimeService = shipFlightTimeService;
        }

        [HttpPost]
        [Route("GetShipFlightTime")]
        public async Task<JsonResult> GetShipFlightTime(FleetFlightTime uniAndPlayerProperties)
        {
            var basicShipInfo = _shipFlightTimeService.GetDefaultShipFlightParameters(uniAndPlayerProperties.PlayerTechnologies);

            return new JsonResult(basicShipInfo);
        }
    }
}
