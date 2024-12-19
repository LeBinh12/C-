using DoAn1._2.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1.Attribute
{
    internal class Location
    {
        public int locationId { get; set; }

        public string locationName { get; set; }

        public string locationDescription { get; set; }

        public List<Assets> AssetsAtLocation { get; set; } = new List<Assets>(); // Danh sách tài sản tại địa điểm


        public Location(int locationId, string locationName, string locationDescription)
        {
            this.locationId = locationId;
            this.locationName = locationName;
            this.locationDescription = locationDescription;
        }

        public void AddAsset(Assets asset)
        {
            AssetsAtLocation.Add(asset);
        }

        public override string ToString()
        {
            return $"Location ID: {locationId}|| location Name: {locationName} || Description: {locationDescription}";
        }
    }
}
