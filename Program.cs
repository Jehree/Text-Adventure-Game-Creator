using System.Runtime.CompilerServices;
using Spectre.Console;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using TextAdventureFramework;

Main main = new Main();
main.Run();

namespace TextAdventureFramework
{
    class Main
    {
        // Get the directory path of the current executable (.dll)
        public string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "";

        public void Run()
        {
            // Specify the relative path where you want to write the file
            string relativePath = @"../somefolder/myjson.jsonc";

            var dict = new Dictionary<string, object>
            {
                { "name", "John Doe" },
                { "alive", true }
            };

            var json = JObject.FromObject(dict);

            var json2 = JObject.FromObject(new Dictionary<string, object>
            {
                { "name", "John Doe" },
                { "alive", true }
            });

            var json3 = new JObject(
                new JProperty("name", "John Doe"),
                new JProperty("alive", true));

            JObject videogameRatings = new JObject(
                new JProperty("Halo", 25),
                new JProperty("Starcraft", 32),
                new JProperty("Call of Duty", 7.5));


            //JsonTools.Write(relativePath, json);
            var readJson = JsonTools.Read(relativePath);
            JsonTools.Write(relativePath, readJson);

            AnsiConsole.Markup("[underline red]" + readJson.ToString() + "[/]");
            Console.ReadLine();
        }
    }

    class Example
    {
        // Get the directory path of the current executable (.dll)
        public string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "";

        public void Run()
        {
            // Specify the relative path where you want to write the file
            string relativePath = @"../somefolder/myjson.jsonc";

            var dict = new Dictionary<string, object>
            {
                { "name", "John Doe" },
                { "alive", true }
            };

            var json = JObject.FromObject(dict);

            var json2 = JObject.FromObject(new Dictionary<string, object>
            {
                { "name", "John Doe" },
                { "alive", true }
            });

            var json3 = new JObject(
                new JProperty("name", "John Doe"),
                new JProperty("alive", true));

            JObject videogameRatings = new JObject(
                new JProperty("Halo", 25),
                new JProperty("Starcraft", 32),
                new JProperty("Call of Duty", 7.5));


            //JsonTools.Write(relativePath, json);
            var readJson = JsonTools.Read(relativePath);
            JsonTools.Write(relativePath, readJson);

            AnsiConsole.Markup("[underline red]" + readJson.ToString() + "[/]");
            Console.ReadLine();
        }
}






