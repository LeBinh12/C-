using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2.Attribute
{
    internal class Assets
    {
        public string assetId { get; set; }
        public string assetName { get; set; }
        public string assetType { get; set; }
        public DateTime purchaseAsset { get; set; }
        public double initialValue { get; set; }

        public string currentStatus { get; set; }
        public int maintenanceTime { get; set; }
        public int locationId { get; set; }

        public Assets(string Id, string name, string type, DateTime purchase, double initial, int maintenance, string status, int locationId)
        {
            assetId= Id;
            assetName= name;
            assetType= type;
            purchaseAsset = purchase;
            initialValue = initial;
            maintenanceTime = maintenance;
            currentStatus = status;
            this.locationId = locationId;
        }

        public override string ToString()
        {
            return $"Id: {assetId} Name: {assetName} Loại: {assetType}" +
                $" Purchase: {purchaseAsset} Initial: {initialValue} Maintenance:" +
                $" {maintenanceTime} Location ID: {locationId} Status: {currentStatus}";

        }
    }
}
