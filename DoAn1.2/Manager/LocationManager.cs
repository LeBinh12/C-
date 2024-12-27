using DoAn1._2.Attribute;
using DoAn1.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2.Manager
{
    internal class LocationManager
    {
        List<Location> locations = new List<Location>();

        private BinarySearchTree assetsTree = new BinarySearchTree();


        public LocationManager()
        {

            locations.Add(new Location(1, "Server Room", "Phòng máy chủ"));
            locations.Add(new Location(2, "Office 105", "Phòng làm việc 105"));
            locations.Add(new Location(3, "Warehouse", "Kho lưu trữ"));
            locations.Add(new Location(4, "Kitchen", "Nhà bếp"));
            locations.Add(new Location(5, "Main Lobby", "Khu vực lễ tân chính"));

        }

        public void DisplayAllLocation()
        {
            if (locations.Count > 0)
            {
                foreach (var location in locations)
                {
                    Console.WriteLine("----------------------------Dữ Liệu Vị trí------------------------------------------");
                    Console.WriteLine(location.ToString());
                }
            }
            else
            {
                Console.WriteLine("Hiện tại không có vị trí nào ở công ty");
            }
        }

        public void AddLocation(int location, string locationName, string description)
        {
            locations.Add(new Location(location, locationName, description));
            Console.WriteLine("Dữ liệu đã thêm thành công!");
        }

        public void UpdateLocation(int location, string locationName, string description)
        {
            var checkLocation = locations.SingleOrDefault(p => p.locationId == location);
            checkLocation.locationName = locationName;
            checkLocation.locationDescription = description;

            assetsTree.UpdateLocation(new Location(location, locationName, description));

            Console.WriteLine("Dữ liệu đã cập nhật thành công");
        }

        public void DeleteLocation(int location)
        {
            var deleteLocation = locations.SingleOrDefault(p => p.locationId == location);

            assetsTree.DeleteLocation(location);

            Console.WriteLine("Dữ liệu đã được xóa thành công");
        }


        public bool CheckLocation(int location)
        {
            foreach (var location1 in locations)
            {
                if (location1.locationId == location)
                    return true;
            }

            return false;
        }

        public string NameLocation(int location)
        {
            var nameLocation = locations.SingleOrDefault(p => p.locationId == location);
            if (nameLocation == null)
                return $"không có dữ liệu thuộc mã {location}";
            else
                return nameLocation.locationName;
        }

    }
}
