using DoAn1._2.Attribute;
using DoAn1.Attribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2.Manager
{
    internal class AssetTypeManager
    {
        List<AssetType> assetTypes = new List<AssetType>();
        private BinarySearchTree assetsTree = new BinarySearchTree();
        public AssetTypeManager()
        {
            assetTypes.Add(new AssetType("Laptop", "Lap top"));
            assetTypes.Add(new AssetType("Computer", "Máy tính bàn"));
            assetTypes.Add(new AssetType("TV", "Màn hình TV"));
            assetTypes.Add(new AssetType("Printer", "Máy in"));
            assetTypes.Add(new AssetType("Projector", "Máy chiếu"));
            assetTypes.Add(new AssetType("Phone", "Điện thoại"));
            assetTypes.Add(new AssetType("Appliance", "Thiết bị"));
            assetTypes.Add(new AssetType("Wearable", "Đồ đeo"));
            assetTypes.Add(new AssetType("Drone", "Máy bay không người lái"));
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
            }
            else
            {
                Console.WriteLine("Hiện Dữ liệu loại tài sản đang rỗng!");
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

            if (assetTypeUpdate != null)
            {
                assetTypeUpdate.AssetTypeName = assetTypeName;
                Console.WriteLine($"Loại tài sản với ID {assetTypeId} đã được cập nhật thành công.");
            }
        }

        public void DeleteAssetType(string assetTypeId)
        {
            var assetTypeDelete = assetTypes.FirstOrDefault(item => item.AssetTypeId == assetTypeId);

            if (assetTypeDelete != null)
            {
                assetTypes.Remove(assetTypeDelete);
                assetsTree.DeleteType(assetTypeId);
                Console.WriteLine($"Loại tài sản với ID {assetTypeId} đã được xóa thành công.");
            }
            else
                Console.WriteLine($"Không tìm thấy loại tài sản với ID {assetTypeId}.");
        }

        public string NameAssetType(string assetTypeId)
        {
            var assetTypeName = assetTypes.FirstOrDefault(item => item.AssetTypeId == assetTypeId);
            if (assetTypeName == null)
                return $"Không tìm thấy loại tài sản với ID {assetTypeId}.";
            else
                return assetTypeName.AssetTypeName; 
        }
    }
}
