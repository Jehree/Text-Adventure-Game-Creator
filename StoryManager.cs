using Newtonsoft.Json.Linq;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework
{

    internal class StoryManager
    {
        public Dictionary<string, object> GetMasterStoryData()
        {
            return null;
        }

        public static Node GetNode(string nodePath)
        {
            var commands = GetCommands(nodePath);
            var config = JsonTools.ReadObject(Path.Combine(nodePath, Constants.NodeConfigFileName));
            return new Node(config, Path.GetFileName(nodePath), commands);
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
