using Newtonsoft.Json.Linq;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureFramework.Types;

namespace TextAdventureFramework
{

    internal class StoryManager
    {
        public enum NodeState
        {
            DISABLED,
            ENABLED,
            SUSPENDED,
            NEIGHBOR
        }

        public static Node GetGameData(string targetNodePath, bool isRoot=true, string parentName=Constants.RootNodeParentName)
        {

            Node parentNode = GetNode(targetNodePath, isRoot, parentName);

            string[] childNodeDirectories = Directory.GetDirectories(targetNodePath);

            foreach (string dir in childNodeDirectories) {
                Node childNode = GetGameData(dir, false, parentNode.Name);
                parentNode.AddChild(childNode);
            }

            return parentNode;
        }

        public static Node GetNode(string nodePath, bool isRoot, string parentName)
        {
            var commands = GetCommands(nodePath);
            var config = JsonTools.ReadObject(Path.Combine(nodePath, Constants.NodeConfigFileName));

            string nodeName = isRoot
                ? Constants.RootNodeName
                : Path.GetFileName(nodePath);

            return new Node(config, nodeName, parentName, commands);
        }

        public static List<Command> GetCommands(string nodePath)
        {
            List<Command> commands = [];

            foreach (string filePath in Directory.GetFiles(nodePath)) { 
                string fileName = Path.GetFileName(filePath);

                if (fileName == Constants.NodeConfigFileName) continue;
                if (Path.GetExtension(fileName) != ".jsonc") continue;
                var json = JsonTools.ReadArray(filePath, true);

                foreach (JObject jsonCommand in json) {
                    commands.Add(new Command(jsonCommand));
                }

            }

            return commands;
        }
    }
}
