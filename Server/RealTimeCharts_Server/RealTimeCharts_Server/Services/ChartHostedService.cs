using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealTimeCharts_Server.DataStorage;
using RealTimeCharts_Server.Hubs;
using RealTimeCharts_Server.TimerFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.Services
{
    public class ChartHostedService: IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public ChartHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var chartHub = scope.ServiceProvider.GetRequiredService<IHubContext<ChartHub>>();
                var timerManager = new TimerManager(() => chartHub.Clients.All.SendAsync("recieveChartData", DataManager.GetData()));
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
