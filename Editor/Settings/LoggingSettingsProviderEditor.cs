using skner.Logging.Models;
using skner.Logging.Settings;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    public class LoggingSettingsProviderEditor : MonoBehaviour
    {

        private const string SETTINGS_PROVIDER_LABEL = "skner's Logging";

        private const string LOG_LEVEL_SETTINGS_ASSET_PATH = "Assets/Resources/skner's Logging/LogLevelSettings.asset";
        private const string GLOBAL_LOGGER_SETTINGS_ASSET_PATH = "Assets/Resources/skner's Logging/GlobalLoggerSettings.asset";

        [SettingsProvider]
        internal static SettingsProvider CreateLogLevelSettingsProvider()
        {
            var provider = new SettingsProvider("Project/LogLevelSettings", SettingsScope.Project)
            {
                label = SETTINGS_PROVIDER_LABEL,
                guiHandler = (searchContext) =>
                {
                    SetupLogLevelSettings();
                    SetupGlobalLoggerSettings();
                }
            };
            return provider;
        }

        private static void SetupLogLevelSettings()
        {
            var logLevelSettings = AssetDatabase.LoadAssetAtPath<LogLevelSettings>(LOG_LEVEL_SETTINGS_ASSET_PATH);

            EditorGUILayout.BeginVertical("Box");

            if (logLevelSettings != null)
            {
                EditorGUILayout.LabelField("Log Levels", EditorStyles.boldLabel);

                UnityEditor.Editor editor = UnityEditor.Editor.CreateEditor(logLevelSettings);
                if (editor != null)
                {
                    editor.OnInspectorGUI();
                }

                if (GUI.changed)
                {
                    EditorUtility.SetDirty(logLevelSettings);
                }

            }
            else
            {
                EditorGUILayout.LabelField("Log Levels Settings asset was not found.", EditorStyles.boldLabel);
                EditorGUILayout.HelpBox("The LogLevelSettings asset was not found. Click the button below to create it.", MessageType.Warning);

                if (GUILayout.Button("Create LogLevelSettings Asset"))
                {
                    CreateLogLevelSettingsAsset();
                }
            }

            EditorGUILayout.EndVertical();
        }

        private static void SetupGlobalLoggerSettings()
        {
            var globalLoggerSettings = AssetDatabase.LoadAssetAtPath<LoggerSettings>(GLOBAL_LOGGER_SETTINGS_ASSET_PATH);

            if (globalLoggerSettings != null)
            {
                EditorGUILayout.BeginVertical("Box");
                EditorGUILayout.LabelField("Global Logger Settings", EditorStyles.boldLabel);

                UnityEditor.Editor editor = UnityEditor.Editor.CreateEditor(globalLoggerSettings);
                if (editor != null)
                {
                    editor.OnInspectorGUI();
                }

                if (GUI.changed)
                {
                    EditorUtility.SetDirty(globalLoggerSettings);
                }

                EditorGUILayout.EndVertical();
            }
            else
            {
                EditorGUILayout.LabelField("Global Logger Settings asset was not found.", EditorStyles.boldLabel);
                EditorGUILayout.HelpBox("The GlobalLoggerSettings asset was not found. Click the button below to create it.", MessageType.Warning);

                if (GUILayout.Button("Create GlobalLoggerSettings Asset"))
                {
                    CreateGlobalLoggerSettingsAsset();
                }
            }
        }

        private static void CreateLogLevelSettingsAsset()
        {
            LogLevelSettings logLevelSettings = ScriptableObject.CreateInstance<LogLevelSettings>();

            logLevelSettings.LogLevels = new LogLevelDetail[]
            {
                new LogLevelDetail("Error", 0, Color.red, true),
                new LogLevelDetail("Warning", 1, new Color(1, 0.801f, 0, 1), false),
                new LogLevelDetail("Debug", 2, new Color(0.6941f, 0.6941f, 0.6941f, 1), false)
            };

            CreateMissingResourceFolders();
            AssetDatabase.CreateAsset(logLevelSettings, LOG_LEVEL_SETTINGS_ASSET_PATH);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void CreateGlobalLoggerSettingsAsset()
        {
            LoggerSettings globalLoggerSettings = ScriptableObject.CreateInstance<LoggerSettings>();

            globalLoggerSettings.Enabled = true;
            globalLoggerSettings.Name = "Global";
            globalLoggerSettings.LogToUnityConsole = true;
            globalLoggerSettings.LogToExternal = false;
            globalLoggerSettings.LogToCallbacks = false;
            globalLoggerSettings.UnityConsoleLogFormat = new LogFormat("{SourceLogger} - <color=#{LogLevelHexColor}>[{LogLevelName}]</color> - \"{Message}\"");
            globalLoggerSettings.SelectedLogLevels = -1;

            CreateMissingResourceFolders();
            AssetDatabase.CreateAsset(globalLoggerSettings, GLOBAL_LOGGER_SETTINGS_ASSET_PATH);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void CreateMissingResourceFolders()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Resources")) AssetDatabase.CreateFolder("Assets", "Resources");
            if (!AssetDatabase.IsValidFolder("Assets/Resources/skner's Logging")) AssetDatabase.CreateFolder("Assets/Resources", "skner's Logging");
        }
    }
}