using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1._2.Attribute
{
    internal class BinarySearchTree
    {
        private class Node
        {
            public Assets Asset;
            public Node Left, Right;

            public Node(Assets asset)
            {
                Asset = asset;
                Left = Right = null;
            }
        }

        private Node root;

        public void Add(Assets asset)
        {
            root = AddRecursive(root, asset);
        }


        // đảy dữ liệu vào cây để cho nó tạo ra cây tương ứng với điều kiện đã cho
        private Node AddRecursive(Node node, Assets asset)
        {
            if (node == null)
                return new Node(asset);

            if (string.Compare(asset.assetId, node.Asset.assetId) < 0)
                node.Left = AddRecursive(node.Left, asset);
            else if (string.Compare(asset.assetId, node.Asset.assetId) > 0)
                node.Right = AddRecursive(node.Right, asset);

            return node;
        }

        public Assets Search(string assetId)
        {
            return SearchRecursive(root, assetId);
        }

        private Assets SearchRecursive(Node node, string assetId)
        {
            if (node == null)
                return null;

            if (assetId == node.Asset.assetId)
                return node.Asset;
            else if (string.Compare(assetId, node.Asset.assetId) < 0)
                return SearchRecursive(node.Left, assetId);
            else
                return SearchRecursive(node.Right, assetId);
        }

        public Assets SearchRecursiveName(string assetName)
        {
            return SearchRecursive(root, assetName);
        }

        private Assets SearchRecursiveName(Node node, string assetName)
        {
            if (node == null)
                return null;

            if (assetName == node.Asset.assetName)
                return node.Asset;
            else if (string.Compare(assetName, node.Asset.assetName) < 0)
                return SearchRecursiveName(node.Left, assetName);
            else
                return SearchRecursiveName(node.Right, assetName);
        }

        public void Update(Assets updatedAsset)
        {
            root = UpdateNode(root, updatedAsset);
        }

        private Node UpdateNode(Node node, Assets updatedAsset)
        {
            if (node == null)
            {
                return null;
            }

            // Tìm tài sản trong cây bằng ID
            if (node.Asset.assetId == updatedAsset.assetId)
            {
                node.Asset = updatedAsset;  
            }
            else if (string.Compare(updatedAsset.assetId, node.Asset.assetId) < 0)
            {
                node.Left = UpdateNode(node.Left, updatedAsset);
            }
            else
            {
                node.Right = UpdateNode(node.Right, updatedAsset);
            }

            return node;
        }
        // Tìm phần tử nhỏ nhất trong cây (dùng cho trường hợp xóa nút có hai con)
        private Node FindMinNode(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }


        // Xóa nút trong cây nhị phân
        private Node DeleteNode(Node node, string assetId)
        {
            if (node == null)
            {
                return null;
            }

            // Tìm nút cần xóa
            if (string.Compare(assetId, node.Asset.assetId) < 0)
            {
                node.Left = DeleteNode(node.Left, assetId);
            }
            else if (string.Compare(assetId, node.Asset.assetId) > 0)
            {
                node.Right = DeleteNode(node.Right, assetId);
            }
            else
            {
                // Nút cần xóa đã được tìm thấy
                if (node.Left == null && node.Right == null) 
                {
                    return null;
                }
                else if (node.Left == null) 
                {
                    return node.Right;
                }
                else if (node.Right == null) 
                {
                    return node.Left;
                }
                else 
                {
                    Node minNode = FindMinNode(node.Right);
                    node.Asset = minNode.Asset;  
                    node.Right = DeleteNode(node.Right, minNode.Asset.assetId); 
                }
            }

            return node;
        }


        private Node DeleteNodeType(Node node, string assetType)
        {
            if (node == null)
            {
                return null;
            }

            // Tìm nút cần xóa
            if (string.Compare(assetType, node.Asset.assetType) < 0)
            {
                node.Left = DeleteNode(node.Left, assetType);
            }
            else if (string.Compare(assetType, node.Asset.assetType) > 0)
            {
                node.Right = DeleteNode(node.Right, assetType);
            }
            else
            {
                // Nút cần xóa đã được tìm thấy
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    return node.Left;
                }
                else
                {
                    Node minNode = FindMinNode(node.Right);
                    node.Asset = minNode.Asset;
                    node.Right = DeleteNode(node.Right, minNode.Asset.assetType);
                }
            }

            return node;
        }


        public bool Delete(string assetId)
        {
            root = DeleteNode(root, assetId);
            return root != null;
        }


        public bool DeleteType(string assetType)
        {
            root = DeleteNodeType(root, assetType);
            return root != null;
        }
    }
}