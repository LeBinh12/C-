using DoAn1._2.Attribute;
using DoAn1.Attribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoAn1._2
{
    internal class AssetManager
    {
        private Hashtable assets = new Hashtable();
        private BinarySearchTree assetsTree = new BinarySearchTree();
        List<Location> locations = new List<Location>();
        List<AssetType> assetTypes= new List<AssetType>();
        private Dictionary<string, List<MaintenanceHistory>> maintenanceRecords = new Dictionary<string, List<MaintenanceHistory>>();

        //thêm tài sản vào bảng băm
        public void AddAsset(Assets asset)
        {
            if (!assets.ContainsKey(asset.assetId))
            {
                assets.Add(asset.assetId, asset);
                assetsTree.Add(asset);
                Console.WriteLine("Asset added successfully.");
            }
            else
            {
                Console.WriteLine("Asset ID already exists.");
            }
        }
        // Tạo và thêm 7 tài sản mẫu vào cây
        public AssetManager()
        {
            locations.Add(new Location(1, "Server Room", "Phòng máy chủ"));
            locations.Add(new Location(2, "Office 105", "Phòng làm việc 105"));
            locations.Add(new Location(3, "Warehouse", "Kho lưu trữ"));
            locations.Add(new Location(4, "Kitchen", "Nhà bếp"));
            locations.Add(new Location(5, "Main Lobby", "Khu vực lễ tân chính"));


            assetsTree.Add(new Assets("A001", "Laptop Dell XPS 13", "Laptop", new DateTime(2022, 5, 15), 1200.0, 0, "Good", 1));
            assetsTree.Add(new Assets("A002", "iPhone 14 Pro", "Phone", new DateTime(2023, 1, 25), 999.99, 0, "New", 2));
            assetsTree.Add(new Assets("A003", "Projector Epson", "Projector", new DateTime(2021, 11, 10), 450.0, 0, "Operational", 1));
            assetsTree.Add(new Assets("A004", "Desktop PC HP", "Computer", new DateTime(2020, 8, 20), 800.0, 0, "Needs Maintenance", 2));
            assetsTree.Add(new Assets("A005", "Samsung TV 55 inch", "TV", new DateTime(2021, 7, 12), 650.0, 0, "Operational", 3));
            assetsTree.Add(new Assets("A006", "Canon Printer", "Printer", new DateTime(2020, 3, 30), 200.0, 0, "Operational", 4));
            assetsTree.Add(new Assets("A007", "Air Conditioner LG", "Appliance", new DateTime(2022, 6, 5), 800.0, 0, "Operational", 5));
            assetsTree.Add(new Assets("A008", "Smartwatch Garmin", "Wearable", new DateTime(2023, 2, 10), 250.0, 0, "New", 1));
            assetsTree.Add(new Assets("A009", "Kitchen Refrigerator", "Appliance", new DateTime(2019, 9, 30), 500.0, 0, "Operational", 2));
            assetsTree.Add(new Assets("A010", "Drone DJI Mavic", "Drone", new DateTime(2021, 12, 1), 1000.0, 0, "Operational", 3));
            assets.Add("A001", new Assets("A001", "Laptop Dell XPS 13", "Laptop", new DateTime(2022, 5, 15), 1200.0, 0, "Good", 1));
            assets.Add("A002", new Assets("A002", "iPhone 14 Pro", "Phone", new DateTime(2023, 1, 25), 999.99, 0, "New", 2));
            assets.Add("A003", new Assets("A003", "Projector Epson", "Projector", new DateTime(2021, 11, 10), 450.0, 0, "Operational", 1));
            assets.Add("A004", new Assets("A004", "Desktop PC HP", "Computer", new DateTime(2020, 8, 20), 800.0, 0, "Needs Maintenance", 2));
            assets.Add("A005", new Assets("A005", "Samsung TV 55 inch", "TV", new DateTime(2021, 7, 12), 650.0, 0, "Operational", 3));
            assets.Add("A006", new Assets("A006", "Canon Printer", "Printer", new DateTime(2020, 3, 30), 200.0, 0, "Operational", 4));
            assets.Add("A007", new Assets("A007", "Air Conditioner LG", "Appliance", new DateTime(2022, 6, 5), 800.0, 0, "Operational", 5));
            assets.Add("A008", new Assets("A008", "Smartwatch Garmin", "Wearable", new DateTime(2023, 2, 10), 250.0, 0, "New", 1));
            assets.Add("A009", new Assets("A009", "Kitchen Refrigerator", "Appliance", new DateTime(2019, 9, 30), 500.0, 0, "Operational", 2));
            assets.Add("A010", new Assets("A010", "Drone DJI Mavic", "Drone", new DateTime(2021, 12, 1), 1000.0, 0, "Operational", 3));


            AddMaintenance("A001", new DateTime(2023, 01, 15));
            AddMaintenance("A002", new DateTime(2023, 03, 10));
            AddMaintenance("A003", new DateTime(2023, 05, 20));
            AddMaintenance("A004", new DateTime(2023, 07, 25));
            AddMaintenance("A005", new DateTime(2023, 09, 10));
            AddMaintenance("A006", new DateTime(2023, 11, 15));
            AddMaintenance("A007", new DateTime(2024, 01, 05));

            assetTypes.Add(new AssetType("Laptop","Lap top"));
            assetTypes.Add(new AssetType("Computer", "Máy tính bàn"));
            assetTypes.Add(new AssetType("TV", "Màn hình TV"));
            assetTypes.Add(new AssetType("Printer", "Máy in"));
            assetTypes.Add(new AssetType("Projector", "Máy chiếu"));
            assetTypes.Add(new AssetType("Phone", "Điện thoại"));
            assetTypes.Add(new AssetType("Appliance", "Thiết bị"));
            assetTypes.Add(new AssetType("Wearable", "Đồ đeo"));
            assetTypes.Add(new AssetType("Drone", "Máy bay không người lái"));


        }


        // xuất tất cả dữ liệu của Location


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

        public void DeleteAsset(string assetId)
        {
            // Xóa tài sản từ Hashtable
            if (assets.ContainsKey(assetId))
            {
                assets.Remove(assetId);
                Console.WriteLine($"Asset with ID {assetId} removed from Hashtable.");
            }
            else
            {
                Console.WriteLine("Asset not found in Hashtable.");
            }

            // Xóa tài sản từ BinarySearchTree
            if (assetsTree.Delete(assetId))
            {
                Console.WriteLine($"Asset with ID {assetId} removed from BinarySearchTree.");
            }
            else
            {
                Console.WriteLine("Asset not found in BinarySearchTree.");
            }
        }


        // xuất dữ liệu từ bảng băm
        public void DisplayAllAssets()
        {
            if (assets.Count > 0)
            {
                foreach (DictionaryEntry entry in assets)
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine(entry.Value.ToString());
                }
            }
            else
            {
                Console.WriteLine("No assets found.");
            }
        }

        public void SearchAsset(string assetId)
        {
            Assets asset = assetsTree.Search(assetId);
            if (asset != null)
            {
                Console.WriteLine($"Asset found: {asset}");
            }
            else
            {
                Console.WriteLine("Asset not found.");
            }
        }

        public bool CheckAsset(string assetId)
        {
            Assets asset = assetsTree.Search(assetId);
            if (asset != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SearchAssetName(string assetName)
        {
            Assets asset = assetsTree.SearchRecursiveName(assetName);
            if (asset != null)
            {
                Console.WriteLine($"Asset found: {asset}");
            }
            else
            {
                Console.WriteLine("Asset not found.");
            }
        }
        // thêm vào lịch sử bảo trì
        public void AddMaintenance(string assetId, DateTime History)
        {
            if (!assets.ContainsKey(assetId))
            {
                Console.WriteLine("Mã tài sản không tồn tại!");
            }
            else
            {
                if (!maintenanceRecords.ContainsKey(assetId))
                {
                    maintenanceRecords[assetId] = new List<MaintenanceHistory>();
                }

                maintenanceRecords[assetId].Add(new MaintenanceHistory(assetId, History));
            }
        }

        public void UpdateAsset(string assetId, string newName, string newType, DateTime newPurchase, double newInitialValue, int newMaintenance, string newStatus, int newLocationId)
        {
            // Kiểm tra tài sản trong Hashtable
            if (assets.ContainsKey(assetId))
            {
                Assets asset = (Assets)assets[assetId];

                asset.assetName = newName;
                asset.assetType = newType;
                asset.purchaseAsset = newPurchase;
                asset.initialValue = newInitialValue;
                asset.maintenanceTime = newMaintenance;
                asset.currentStatus = newStatus;
                asset.locationId = newLocationId;

                assetsTree.Update(asset);

                Console.WriteLine($"Asset with ID {assetId} has been updated successfully.");
            }
            else
            {
                Console.WriteLine("Asset not found in Hashtable.");
            }
        }

        // hiển thị tất cả lịch sử bảo trị theo id
        public void ShowMaintenanceHistory(string assetId)
        {
            if (maintenanceRecords.ContainsKey(assetId))
            {
                Console.WriteLine($"Lịch sử bảo trì của tài sản {assetId}:");
                foreach (var record in maintenanceRecords[assetId])
                {
                    Console.WriteLine(record.ToString());
                }
            }
            else
            {
                Console.WriteLine("Không có lịch sử bảo trì nào cho tài sản này.");
            }
        }


        // Lưu tất cả các dữ liệu của tài sản thuộc location nhất định vào 1 danh sách
        public List<Assets> GetAssetsByLocation(int location)
        {
            List<Assets> result = new List<Assets>();
            foreach (DictionaryEntry entry in assets)
            {
                Assets asset = (Assets)entry.Value;

                if (asset.locationId == location)
                {
                    result.Add(asset);
                }
            }
            return result;
        }




        // hiểu thị tất cả các Vị trí thuộc id nhất định
        public void PrintAssetsByLocation(int location)
        {
            List<Assets> matchedAssets = assetsTree.SearchAssetsByLocation(location);

            foreach (var asset in matchedAssets)
            {
                Console.WriteLine($"ID: {asset.assetId}, Name: {asset.assetName}, Location: {asset.assetName}");
            }
        }



        public bool CheckLocation(int location)
        {
            foreach(var location1 in locations)
            {
                if(location1.locationId == location)
                    return true;
            }

            return false;
        }

        public bool CheckType(string type)
        {
            foreach (var item in assetTypes)
            {
                if (item.AssetTypeId == type)
                    return true;
            }

            return false;
        }


        // hiển thị tất cả thông tin loại tài sản
        public void DisplayAssetsType()
        {
            if (assetTypes.Count > 0)
            {
                foreach (var asset in assetTypes)
                {
                    Console.WriteLine(asset.ToString());
                }
            } else
            {
                Console.WriteLine("Hiện Dữ liệu loại tài sản đang rỗng!");
            }

        }

        // hiển thị tất cả tài sản theo mã loại

        public void DisplayAssetsTypeId(string Id)
        {
            int count = 0;
            Console.WriteLine($"=================== Dữ liệu theo mã loại ==================");
            foreach (Assets asset in assets.Values)
            {
                if(asset.assetType.Contains(Id))
                {
                    Console.WriteLine(asset.ToString());
                    count++;
                }
            }
            if(count == 0)
            {
                Console.WriteLine($"Không có dữ liệu thuộc loại {Id}");
            }
        }


        public void AddAssetType(string assetTypeId, string assetTypeName)
        {
            assetTypes.Add(new AssetType(assetTypeId, assetTypeName));
            Console.WriteLine("Dữ liệu đã được thêm thành công");
        }

        public void UpdateAssetType(string assetTypeId, string assetTypeName)
        {

            var assetTypeUpdate = assetTypes.SingleOrDefault(item => item.AssetTypeId == assetTypeId);

            if(assetTypeUpdate != null)
            {
                assetTypeUpdate.AssetTypeName = assetTypeName;
                Console.WriteLine($"Loại tài sản với ID {assetTypeId} đã được cập nhật thành công.");
            }
        }

        public void DeleteAssetsType(string assetTypeId)
        {
            List<string> keysToRemove = new List<string>();

            foreach (DictionaryEntry entry in assets)
            {
                Assets asset = (Assets)entry.Value;

                if (asset.assetType == assetTypeId)
                {
                    // Thêm khóa vào danh sách cần xóa
                    keysToRemove.Add(entry.Key.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
                assets.Remove(key);
            }

            if (keysToRemove.Count > 0)
            {
                Console.WriteLine($"Tất cả tài sản thuộc loại {assetTypeId} đã được xóa.");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy tài sản nào thuộc loại {assetTypeId}.");
            }
        }


        public void DeleteAssetType(string assetTypeId)
        {
            var assetTypeDelete = assetTypes.FirstOrDefault(item => item.AssetTypeId == assetTypeId);
            
            if(assetTypeDelete != null)
            {
                assetTypes.Remove(assetTypeDelete);
                assetsTree.DeleteType(assetTypeId);
                DeleteAssetsType(assetTypeId);
                Console.WriteLine($"Loại tài sản với ID {assetTypeId} đã được xóa thành công.");
            } else
                Console.WriteLine($"Không tìm thấy loại tài sản với ID {assetTypeId}.");
        }


        public bool CheckLocations(int location)
        {
            var checkLocation = locations.SingleOrDefault(p => p.locationId == location);
            if(checkLocation != null)
            {
                return true;
            }
            return false;
        }

        public void AddLocation(int location, string locationName, string description)
        {
            locations.Add(new Location(location,locationName,description));
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

    }
}
