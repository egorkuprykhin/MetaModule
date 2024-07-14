namespace Infrastructure.Common
{
    public static partial class Constants
    {
#if UNITY_EDITOR
        
        public const string MetaConfiguration = "_Configuration";

        public static class Tools
        {
            public const string ClearMetaFiles = "Tools/Clear *.meta Files";
            public const string AssignMetaScripts = "Tools/Assign Meta Scripts To Configs";
            public const string BuildMetaConfiguration = "Tools/Build Meta Configuration";
            public const string BuildMetaLogic = "Tools/Build Meta Logic";
            public const string BuildScreens = "Tools/Build Screens";
            public const string CreateButtonsBinder = "Tools/Create Buttons Binder";
            public const string AssignButtonBindings = "Tools/Assign Button Bindings";
            public const string BuildButtons = "Tools/Build Buttons";
        }

        public static class Screens
        {
            public const string Loading = "loading";
            public const string Start = "start";
            public const string Menu = "menu";
            public const string Policy = "policy";
            public const string Options = "options";
            public const string Settings = "settings";
            public const string Level = "level";
            public const string Levels = "levels";
            public const string Game = "game";
            public const string Win = "win";
            public const string Lose = "lose";
            public const string Exit = "exit";
            public const string Rules = "rules";
        }

        public static class Buttons
        {
            public const string Back = "back";
            public const string Ok = "ok";
            public const string Yes = "yes";
            public const string No = "no";
            public const string Play = "play";
            public const string Start = "start";
            public const string Stop = "stop";
            public const string Next = "next";
            public const string TryAgain = "try";
        }
#endif
    }
}