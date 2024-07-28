using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework.Types
{
    internal class Command
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string[] Aliases { get; private set; }
        public Actions Actions { get; private set; }
        public Dictionary<string, string> Variables { get; private set; }
        public Dictionary<string, string> GlobalVariables { get; private set; }

        public Command(JObject jsonObject)
        {
            Name = jsonObject["name"]?.ToString();
            Type = jsonObject["type"]?.ToString() ?? Constants.DefaultCommandType;
            Aliases = jsonObject["aliases"]?.ToObject<string[]>() ?? [];
            Actions = new Actions((JObject)jsonObject["actions"]);
            Variables = jsonObject["variables"]?.ToObject<Dictionary<string, string>>() ?? new Dictionary<string, string>();
            GlobalVariables = jsonObject["global_variables"]?.ToObject<Dictionary<string, string>>() ?? new Dictionary<string, string>();
        }

    }
    internal class Actions
    {
        public string[] OnEnable { get; private set; }
        public string[] OnExecute { get; private set; }

        public Actions(JObject jsonObject)
        {
            OnEnable = jsonObject["on_enable"]?.ToObject<string[]>() ?? [];
            OnExecute = jsonObject["on_execute"]?.ToObject<string[]>() ?? [];
        }
    }
}
