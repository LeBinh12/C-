using DoAn1._2.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1.Attribute
{
    internal class AssetType
    {
        public string AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }

        public List<Assets> AssetAtType { get; set; } = new List<Assets>();

        public AssetType(string assetTypeId, string assetTypeName)
        {
            AssetTypeId = assetTypeId;
            AssetTypeName = assetTypeName;
        }

        public void AddAssetType(Assets asset)
        {
            AssetAtType.Add(asset);
        }

        public override string ToString()
        {
            return $"ID: {AssetTypeId} || Name: {AssetTypeName}";
        }

    }
}
