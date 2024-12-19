using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2.Attribute
{
    internal class AssetLocation
    {
        public string AssetId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateAssigned { get; set; } // Ngày tài sản được chuyển đến địa điểm

        public AssetLocation(string assetId, int locationId, DateTime dateAssigned)
        {
            AssetId = assetId;
            LocationId = locationId;
            DateAssigned = dateAssigned;
        }

        public override string ToString()
        {
            return $"Asset ID: {AssetId} || Location ID: {LocationId} || Date Assigned: {DateAssigned}";
        }
    }
}
