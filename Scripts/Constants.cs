namespace Infrastructure.Common
{
    public static partial class Constants
    {
#if UNITY_EDITOR
        public static partial class Tools
        {
            public const string AssignMetaScripts = "Tools/Assign Meta Scripts To Configs";
            public const string CollectMetaConfiguration = "Tools/Collect Meta Configuration Settings";
        }

        public static partial class Configurations
        {
            public const string MetaConfiguration = "_Configuration";
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