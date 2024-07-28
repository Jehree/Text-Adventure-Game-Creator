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
        public static void WriteObject(string path, JObject jsonObject, bool rawPath=false)
        {
            // Combine the directory path with the relative path to get the full file path
            string fullPath = rawPath
                ? path
                : Path.Combine(Constants.AssemblyPath, path);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(fullPath))
            using (JsonTextWriter writer = new JsonTextWriter(file)) {
                jsonObject.WriteTo(writer);
            }
        }

        public static JObject ReadObject(string path, bool rawPath = false)
        {
            // Combine the directory path with the relative path to get the full file path
            string fullPath = rawPath
                ? path
                : Path.Combine(Constants.AssemblyPath, path);

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(fullPath))
            using (JsonTextReader reader = new JsonTextReader(file)) {
                return (JObject)JToken.ReadFrom(reader);
            }
        }
        public static void WriteArray(string path, JArray jsonArray, bool rawPath = false)
        {
            // Combine the directory path with the relative path to get the full file path
            string fullPath = rawPath
                ? path
                : Path.Combine(Constants.AssemblyPath, path);

            // write JSON directly to a file
            using (StreamWriter file = File.CreateText(fullPath))
            using (JsonTextWriter writer = new JsonTextWriter(file)) {
                jsonArray.WriteTo(writer);
            }
        }

        public static JArray ReadArray(string path, bool rawPath = false)
        {
            // Combine the directory path with the relative path to get the full file path
            string fullPath = rawPath
                ? path
                : Path.Combine(Constants.AssemblyPath, path);

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(fullPath))
            using (JsonTextReader reader = new JsonTextReader(file)) {
                return (JArray)JToken.ReadFrom(reader);
            }
        }
    }
}
