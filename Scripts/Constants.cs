namespace Infrastructure.Common
{
    public static partial class Constants
    {
#if UNITY_EDITOR
        public static class Configuration
        {
            public const string MetaConfiguration = "_Configuration";
        }

        public static class Tools
        {
            public const string ClearMetaFiles = "Tools/Clear *.meta Files";
            public const string AssignMetaScripts = "Tools/Assign Meta Scripts To Configs";
            public const string CollectMetaConfiguration = "Tools/Collect Meta Configuration Settings";
            public const string BuildMetaLogic = "Tools/Build Meta Logic";
        }

        public static class Screens
        {
            public const string Loading = "loading";
            public const string Start = "start";
            public const string Menu = "menu";
            public const string Policy = "policy";
            public const string Options = "options";
            public const string Levels = "level";
            public const string Game = "game";
            public const string Win = "win";
            public const string Lose = "lose";
            public const string Exit = "exit";
            public const string Rules = "rules";
        }
#endif
    }
}