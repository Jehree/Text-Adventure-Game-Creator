using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework
{
    internal class Node
    {
        public string Name { get; private set; }
        public bool RespectParentEnabled { get; private set; }
        public List<Command> Commands { get; private set; }

        public Node(JObject configJson, string nodeName)
        {
            Name = nodeName;
            RespectParentEnabled = (bool)configJson["respect_parent_enabled"];
            Commands = new List<Command>();
        }

        public Node(JObject configJson, string nodeName, List<Command> commands)
        {
            Name = nodeName;
            RespectParentEnabled = (bool)(configJson["respect_parent_enabled"] ?? true);
            Commands = commands ?? new List<Command>();
        }

        public void AddCommands(List<Command> commands)
        {
            Commands.Concat(commands);
        }
    }
}
