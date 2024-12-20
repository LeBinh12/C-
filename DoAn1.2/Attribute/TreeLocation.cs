using DoAn1.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoAn1._2.Attribute
{
    internal class TreeLocation
    {
        private class NodeLocation
        {
            public Location Location;
            public NodeLocation Left, Right;

            public NodeLocation(Location location)
            {
                Location = location;
                Left = Right = null;
            }
        }

        private NodeLocation root;

        public void Add(Location location)
        {
            root = AddRecursive(root, location);
        }

        private NodeLocation AddRecursive(NodeLocation node, Location location)
        {
            if (node == null)
                return new NodeLocation(location);
            if (location.locationId < node.Location.locationId)
                node.Left = AddRecursive(node.Left, location);
            else if (location.locationId > node.Location.locationId)
                node.Right = AddRecursive(node.Right, location);

            return node;
        }

        public Location Search(int locationId)
        {
            return SearchRecursive(root, locationId);
        }

        private Location SearchRecursive(NodeLocation node, int locationId)
        {
            if (node == null)
                return null;

            if (locationId == node.Location.locationId)
                return node.Location;
            else if (locationId < node.Location.locationId)
                return SearchRecursive(node.Left, locationId);
            else
                return SearchRecursive(node.Right, locationId);
        }




    }
}
