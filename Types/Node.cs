using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework.Types
{
    internal class Node
    {
        public string Name { get; private set; }
        public string Parent { get; private set; }
        public bool RespectParentEnabled { get; private set; }
        public List<Command> Commands { get; private set; }
        public Dictionary<string, Node> Children { get; private set; } = new Dictionary<string, Node>();

        public Node(JObject configJson, string nodeName, string parent, List<Command> commands)
        {
            Name = nodeName;
            RespectParentEnabled = (bool)(configJson["respect_parent_enabled"] ?? true);
            Commands = commands ?? new List<Command>();
            Parent = parent;
        }

        public void AddCommands(List<Command> commands)
        {
            Commands.Concat(commands);
        }

        public void AddChild(Node child)
        {
            if (child == null) return;
            Children.Add(child.Name, child);
        }
    }
}
