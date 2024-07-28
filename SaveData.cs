using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextAdventureFramework.Types;

namespace TextAdventureFramework
{
    internal class SaveData
    {
        public static void CreateNewSaveData(Node gameData)
        {
            Dictionary<string, SaveDataNode> saveData = new Dictionary<string, SaveDataNode>();

            AddSaveDataNodes(saveData, gameData);

            var json = JObject.FromObject(saveData);
            JsonTools.WriteObject(Path.Combine(Constants.SaveDataPath, "saves.jsonc"), json, true);
        }

        public static void AddSaveDataNodes(Dictionary<string, SaveDataNode> saveData, Node targetNode)
        {
            saveData.Add(targetNode.Name, new SaveDataNode(targetNode));

            foreach (var child in targetNode.Children)
            {
                AddSaveDataNodes(saveData, child.Value);
            }
        }
    }
}
