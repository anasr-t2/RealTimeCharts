using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.Hubs
{
    public class ChartHub: Hub
    {
        static List<string> connecitons = new List<string>();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChartHub(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public override Task OnConnectedAsync()
        {
            var connectionId = _httpContextAccessor.HttpContext.Connection.Id;

            connecitons.Add(connectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {

            var connectionId = _httpContextAccessor.HttpContext.Connection.Id;
            if(connectionId != null && connecitons.Any(x=>x == connectionId))
            {
                connecitons.Remove(connectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
