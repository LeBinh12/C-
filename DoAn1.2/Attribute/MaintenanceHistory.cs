using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2.Attribute
{
    public class MaintenanceHistory
    {
        public string assetId { get; set; }

        public DateTime assetMaintenance { get; set; }

        // Constructor mặc định
        public MaintenanceHistory()
        {
            assetId = "Unknown";
            assetMaintenance = DateTime.MinValue;
        }

        public MaintenanceHistory(string assetid, DateTime history)
        {
            assetId= assetid;
            assetMaintenance = history;
        }

        public override string ToString()
        {
            return $"ID: {assetId} | Thời gian bảo trì: {assetMaintenance:dd/MM/yyyy}";
        }
    }
}
