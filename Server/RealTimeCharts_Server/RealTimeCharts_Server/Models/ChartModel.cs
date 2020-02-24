using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeCharts_Server.Models
{
    public class ChartModel
    {
        public List<int> Data { get; set; } = new List<int>();
        public string Label { get; set; }
    }
}
