using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureFramework
{
    public static class Constants
    {
        public static string AssemblyPath { get; private set; } = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "";
        public const string StoryRelativePath = @"../story";
        public static string StoryPath { get; private set; } = Path.GetFullPath(StoryRelativePath);
        public const string SaveDataRelativePath = @"../saves";
        public static string SaveDataPath { get; private set; } = Path.GetFullPath(SaveDataRelativePath);
        public const string NodeConfigFileName = "node_config.jsonc";
        public const string DefaultCommandType = CommandType.Normal;
        public const string RootNodeName = "root";
        public const string RootNodeParentName = "game";
    }

    public static class CommandType
    {
        public const string Normal = "normal";
        public const string Doorway = "doorway";
    }
}
