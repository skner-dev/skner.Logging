using skner.Logging.Settings;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomEditor(typeof(LoggerSettings))]
    internal class LoggerSettingsEditor : UnityEditor.Editor
    {

        private SerializedProperty _selectedLogLevelsProperty;
        private string[] _availableLogLevels;

        private void OnEnable()
        {
            // Initialize the SerializedProperty for the selected log levels
            _selectedLogLevelsProperty = serializedObject.FindProperty("SelectedLogLevels");

            LogLevelSettings logLevelSettings = LoggingSettingsProvider.LogLevelSettings;
            _availableLogLevels = logLevelSettings.LogLevels.Select(x => x.LogLevelName).ToArray();
        }

        public override void OnInspectorGUI()
        {
            LoggerSettings loggerSettings = (LoggerSettings)target;

            serializedObject.Update();

            // Display the General section
            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
            loggerSettings.Enabled = EditorGUILayout.Toggle("Enabled", loggerSettings.Enabled);
            GUI.enabled = loggerSettings.Enabled;
            loggerSettings.Name = EditorGUILayout.TextField("Name", loggerSettings.Name);

            // Display the Logging types section
            EditorGUILayout.LabelField("Output Options", EditorStyles.boldLabel);
            loggerSettings.LogToUnityConsole = EditorGUILayout.Toggle("Log To Unity Console", loggerSettings.LogToUnityConsole);

            if (loggerSettings.LogToUnityConsole)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityConsoleLogFormat"), new GUIContent("Console Log Format"));
            }

            loggerSettings.LogToExternal = EditorGUILayout.Toggle("Log To External", loggerSettings.LogToExternal);

            if (loggerSettings.LogToExternal)
            {
                SerializedProperty assignedLogOutputsProperty = serializedObject.FindProperty("AssignedLogOutputs");

                EditorGUILayout.LabelField("External Logging Settings", EditorStyles.boldLabel);

                // Display and manage the list of format providers manually
                for (int i = 0; i < assignedLogOutputsProperty.arraySize; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PropertyField(assignedLogOutputsProperty.GetArrayElementAtIndex(i), GUIContent.none);
                    if (GUILayout.Button("-", GUILayout.Width(20)))
                    {
                        assignedLogOutputsProperty.DeleteArrayElementAtIndex(i);
                    }
                    EditorGUILayout.EndHorizontal();
                }

                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                // Add a button to add new format providers
                if (GUILayout.Button("Add Log Output Entry", GUILayout.Width(150)))
                {
                    assignedLogOutputsProperty.InsertArrayElementAtIndex(assignedLogOutputsProperty.arraySize);
                }
                GUILayout.EndHorizontal();
            }

            loggerSettings.LogToCallbacks = EditorGUILayout.Toggle("Log To Callbacks", loggerSettings.LogToCallbacks);

            // Display the Log Level Filtering section
            EditorGUILayout.LabelField("Log Level Filtering", EditorStyles.boldLabel);

            // Use MaskField for selecting log levels
            _selectedLogLevelsProperty.intValue = EditorGUILayout.MaskField("Select Log Levels", _selectedLogLevelsProperty.intValue, _availableLogLevels);

            GUI.enabled = true;

            serializedObject.ApplyModifiedProperties();
        }
    }
}