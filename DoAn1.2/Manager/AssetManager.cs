using DoAn1._2.Attribute;
using DoAn1._2.Manager;
using DoAn1.Attribute;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoAn1._2
{
    internal class AssetManager
    {
        private BinarySearchTree assetsTree = new BinarySearchTree();
        LocationManager locationManager = new LocationManager();
        List<AssetType> assetTypes = new List<AssetType>();
        List<Location> locations = new List<Location>();

        AssetTypeManager typeManager = new AssetTypeManager();
        private Dictionary<string, List<MaintenanceHistory>> maintenanceRecords = new Dictionary<string, List<MaintenanceHistory>>();

        public bool CheckAsset(string assetId)
        {
            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();
            foreach(var asset in allAssets)
            {
                var item = asset.Value;
                if (item.assetId == assetId)
                    return true;
            }
            return false;
        }

        //thêm tài sản vào bảng băm
        public void AddAsset(Assets asset)
        {
            if (!CheckAsset(asset.assetId))
            {
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


            assetsTree.Add(new Assets("A001", "Laptop Dell XPS 13", "Laptop", new DateTime(2022, 5, 15), 1200.0, "Good", 1));
            assetsTree.Add(new Assets("A002", "iPhone 14 Pro", "Phone", new DateTime(2023, 1, 25), 999.99, "New", 2));
            assetsTree.Add(new Assets("A003", "Projector Epson", "Projector", new DateTime(2021, 11, 10), 450.0, "Operational", 1));
            assetsTree.Add(new Assets("A004", "Desktop PC HP", "Computer", new DateTime(2020, 8, 20), 800.0, "Needs Maintenance", 2));
            assetsTree.Add(new Assets("A005", "Samsung TV 55 inch", "TV", new DateTime(2021, 7, 12), 650.0, "Operational", 3));
            assetsTree.Add(new Assets("A006", "Canon Printer", "Printer", new DateTime(2020, 3, 30), 200.0, "Operational", 4));
            assetsTree.Add(new Assets("A007", "Air Conditioner LG", "Appliance", new DateTime(2022, 6, 5), 800.0, "Operational", 5));
            assetsTree.Add(new Assets("A008", "Smartwatch Garmin", "Wearable", new DateTime(2023, 2, 10), 250.0, "New", 1));
            assetsTree.Add(new Assets("A009", "Kitchen Refrigerator", "Appliance", new DateTime(2019, 9, 30), 500.0, "Operational", 2));
            assetsTree.Add(new Assets("A010", "Drone DJI Mavic", "Drone", new DateTime(2021, 12, 1), 1000.0, "Operational", 3));


            AddMaintenance("A001", new DateTime(2023, 01, 15));
            AddMaintenance("A002", new DateTime(2023, 03, 10));
            AddMaintenance("A003", new DateTime(2023, 05, 20));
            AddMaintenance("A004", new DateTime(2023, 07, 25));
            AddMaintenance("A005", new DateTime(2023, 09, 10));
            AddMaintenance("A006", new DateTime(2023, 11, 15));
            AddMaintenance("A007", new DateTime(2024, 01, 05));

        }



        public void DeleteAsset(string assetId)
        {
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
            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();
            if (allAssets.Count > 0)
            {
                foreach (var asset in allAssets)
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine(asset.ToString());
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
            if (!CheckAsset(assetId))
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

        public void UpdateAsset(string assetId, string newName, string newType, DateTime newPurchase, double newInitialValue, string newStatus, int newLocationId)
        {

            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();

            // Kiểm tra tài sản trong Hashtable
            if (CheckAsset(assetId))
            {
                Assets asset = (Assets)allAssets[assetId];

                asset.assetName = newName;
                asset.assetType = newType;
                asset.purchaseAsset = newPurchase;
                asset.initialValue = newInitialValue;
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
        public int ShowCountHistory(string assetId)
        {
            return maintenanceRecords.Count;
        }

        public void ShowMaintenanceHistory(string assetId)
        {
            if (maintenanceRecords.ContainsKey(assetId))
            {
                Console.WriteLine($"Tổng số lần bảo trì của {assetId}: {ShowCountHistory(assetId)}");
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
            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();

            List<Assets> result = new List<Assets>();
            foreach (var asset in allAssets)
            {
                var item = asset.Value;
                if (item.locationId == location)
                {
                    result.Add(item);
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








        // hiển thị tất cả tài sản theo mã loại

        public void DisplayAssetsTypeId(string Id)
        {
            int count = 0;
            Console.WriteLine($"=================== Dữ liệu theo mã loại ==================");
            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();
            foreach (var asset in allAssets)
            {
                var item = asset.Value;
                if(item.assetType.Contains(Id))
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


        public void DeleteAssetsType(string assetTypeId)
        {
            List<string> keysToRemove = new List<string>();
            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();
            foreach (var asset in allAssets)
            {
                var item = asset.Value;

                if (item.assetType == assetTypeId)
                {
                    // Thêm khóa vào danh sách cần xóa
                    keysToRemove.Add(asset.Key.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
               allAssets.Remove(key);
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


        public void ExportExcelHighPrice()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<Assets> top10Assets = assetsTree.GetTop10MostExpensiveAssets();


            ExcelPackage excel = new ExcelPackage();
            var sheet = excel.Workbook.Worksheets.Add("Sheet1");
            sheet.Cells[1, 1].Value = "Mã tài sản";
            sheet.Cells[1, 2].Value = "Tên tài sản";
            sheet.Cells[1, 3].Value = "Giá tài sản";
            sheet.Cells[1, 4].Value = "Ngày mua tài sản";
            sheet.Cells[1, 5].Value = "Vị trí tài sản";
            sheet.Cells[1, 6].Value = "Loại tài sản";

            int row = 2;
            foreach (var item in top10Assets)
            {
                sheet.Cells[row, 1].Value = item.assetId;
                sheet.Cells[row, 2].Value = item.assetName;
                sheet.Cells[row, 3].Value = item.initialValue;
                sheet.Cells[row, 4].Value = item.purchaseAsset;
                sheet.Cells[row, 5].Value = locationManager.NameLocation(item.locationId);
                sheet.Cells[row, 6].Value = typeManager.NameAssetType(item.assetType);

                row++;
            }

            // Tự động điều chỉnh độ rộng các cột
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadPath, "Top10Assets.xlsx");

            try
            {
                // Lưu file
                File.WriteAllBytes(filePath, excel.GetAsByteArray());
                Console.WriteLine($"Xuất file Excel thành công! File đã được lưu tại: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra khi lưu file: {ex.Message}");
            }

        }

        public void ExportExcelShortPrice()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<Assets> top10Assets = assetsTree.GetTop10LeastExpensiveAssets();


            ExcelPackage excel = new ExcelPackage();
            var sheet = excel.Workbook.Worksheets.Add("Sheet1");
            sheet.Cells[1, 1].Value = "Mã tài sản";
            sheet.Cells[1, 2].Value = "Tên tài sản";
            sheet.Cells[1, 3].Value = "Giá tài sản";
            sheet.Cells[1, 4].Value = "Ngày mua tài sản";
            sheet.Cells[1, 5].Value = "Vị trí tài sản";
            sheet.Cells[1, 6].Value = "Loại tài sản";

            int row = 2;
            foreach (var item in top10Assets)
            {
                sheet.Cells[row, 1].Value = item.assetId;
                sheet.Cells[row, 2].Value = item.assetName;
                sheet.Cells[row, 3].Value = item.initialValue;
                sheet.Cells[row, 4].Value = item.purchaseAsset;
                sheet.Cells[row, 5].Value = locationManager.NameLocation(item.locationId);
                sheet.Cells[row, 6].Value = typeManager.NameAssetType(item.assetType);

                row++;
            }

            // Tự động điều chỉnh độ rộng các cột
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadPath, "Top10AssetsShortPrice.xlsx");

            try
            {
                // Lưu file
                File.WriteAllBytes(filePath, excel.GetAsByteArray());
                Console.WriteLine($"Xuất file Excel thành công! File đã được lưu tại: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra khi lưu file: {ex.Message}");
            }

        }


        public void ExportExcelAll()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Dictionary<string, Assets> allAssets = assetsTree.GetAllAssetsFromTreeAsDictionary();

            ExcelPackage excel = new ExcelPackage();
            var sheet = excel.Workbook.Worksheets.Add("Sheet1");
            sheet.Cells[1, 1].Value = "Mã tài sản";
            sheet.Cells[1, 2].Value = "Tên tài sản";
            sheet.Cells[1, 3].Value = "Giá tài sản";
            sheet.Cells[1, 4].Value = "Ngày mua tài sản";
            sheet.Cells[1, 5].Value = "Vị trí tài sản";
            sheet.Cells[1, 6].Value = "Loại tài sản";
            
            int row = 2;
            foreach (var asset in allAssets)
            {
                var item = asset.Value;
                sheet.Cells[row, 1].Value = item.assetId;
                sheet.Cells[row, 2].Value = item.assetName;
                sheet.Cells[row, 3].Value = item.initialValue;
                sheet.Cells[row, 4].Value = item.purchaseAsset;
                sheet.Cells[row, 5].Value = locationManager.NameLocation(item.locationId);
                sheet.Cells[row, 6].Value = typeManager.NameAssetType(item.assetType);

                row++;
            }

            // Tự động điều chỉnh độ rộng các cột
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadPath, "Top10AssetsShortPrice.xlsx");

            try
            {
                // Lưu file
                File.WriteAllBytes(filePath, excel.GetAsByteArray());
                Console.WriteLine($"Xuất file Excel thành công! File đã được lưu tại: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Có lỗi xảy ra khi lưu file: {ex.Message}");
            }

        }



    }
}
