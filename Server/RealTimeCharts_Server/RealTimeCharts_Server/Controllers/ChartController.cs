using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeCharts_Server.DataStorage;
using RealTimeCharts_Server.Hubs;
using RealTimeCharts_Server.TimerFeatures;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeCharts_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IHubContext<ChartHub> _chartHub;

        public ChartController(IHubContext<ChartHub> chartHub)
        {
            _chartHub = chartHub;
        }

        [HttpGet]
        public IActionResult GetChartData() // This is just an invocation , so don't use it as it will create multiple time managers for each client, there's a hosted service 
        {
            var timerManager = new TimerManager(() => _chartHub.Clients.All.SendAsync("recieveChartData",DataManager.GetData()));
            return Ok();
        }
    }
}
