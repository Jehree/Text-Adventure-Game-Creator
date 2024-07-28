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
        enum ProcessCommandStatus
        {
            FAIL,
            SUCCESS,
            TERMINATE,
        }

        public void Run()
        {
            var dirs = Directory.GetDirectories(Constants.StoryPath);
            var node = StoryManager.GetNode(dirs[0]);

            Console.WriteLine(node.Commands[0].Type);

            while (true) {
                AnsiConsole.Markup("[underline green]Enter command[/]: ");
                string input = Console.ReadLine() ?? "";

                var processCommandStatus = ProcessCommand(input);
                if (processCommandStatus == ProcessCommandStatus.TERMINATE) break;
            }
        }

        private ProcessCommandStatus ProcessCommand(string command)
        {
            if (command == null || command == "") {
                AnsiConsole.MarkupLine($"[red]Invalid command![/]");
                return ProcessCommandStatus.FAIL;
            }

            if (command == "quit") {
                return ProcessCommandStatus.TERMINATE;
            }

            AnsiConsole.MarkupLine($"[underline green]You entered[/]: {command}");
            return ProcessCommandStatus.SUCCESS;
        }
    }
}






