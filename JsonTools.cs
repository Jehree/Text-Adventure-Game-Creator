using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework
{
    public static class JsonTools
    {
        // Get the directory path of the current executable (.dll)
        public static string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "";

        public static void Write(string relativePath, JObject jsonObject)
        {
            // Combine the directory path with the relative path to get the full file path
            string fullPath = Path.Combine(assemblyPath, relativePath);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(fullPath))
            using (JsonTextWriter writer = new JsonTextWriter(file)) {
                jsonObject.WriteTo(writer);
            }
        }

        public static JObject Read(string relativePath)
        {
            // Combine the directory path with the relative path to get the full file path
            string fullPath = Path.Combine(assemblyPath, relativePath);

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(fullPath))
            using (JsonTextReader reader = new JsonTextReader(file)) {
                return (JObject)JToken.ReadFrom(reader);
            }
        }
    }
}
