﻿#if UNITY_EDITOR
namespace YG.Insides
{
    public static partial class Langs
    {
#if RU_YG2
        public const string projectSettings = "Настройки проекта";
        public const string t_nameDefining = "Используется для Scripting Define Symbols.";
        public const string applySettingsProject = "Применить настройки проекта";
        public const string addProjectSettings = "Общие настройки";
#else
        public const string projectSettings = "Project settings";
        public const string t_nameDefining = "Used for Scripting Define Symbols.";
        public const string applySettingsProject = "Apply settings project";
        public const string addProjectSettings = "Common options";
#endif
    }
}
#endif