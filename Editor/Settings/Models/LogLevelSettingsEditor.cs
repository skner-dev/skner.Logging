using skner.Logging.Models;
using skner.Logging.Settings;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomEditor(typeof(LogLevelSettings))]
    internal class LogLevelSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var logLevelSettings = (LogLevelSettings)target;

            if (logLevelSettings != null)
            {
                serializedObject.Update();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Log Level Name", GUILayout.ExpandWidth(true));
                EditorGUILayout.LabelField("Severity", GUILayout.Width(60));
                EditorGUILayout.LabelField("Display Color", GUILayout.Width(100));
                EditorGUILayout.LabelField("Stack Trace", GUILayout.Width(80));
                EditorGUILayout.LabelField("", GUILayout.Width(20));
                EditorGUILayout.EndHorizontal();

                for (int i = 0; i < logLevelSettings.LogLevels.Length; i++)
                {
                    EditorGUILayout.BeginHorizontal();

                    EditorGUI.BeginDisabledGroup(!logLevelSettings.LogLevels[i].IsEditable);
                    logLevelSettings.LogLevels[i].LogLevelName = EditorGUILayout.TextField(logLevelSettings.LogLevels[i].LogLevelName, GUILayout.ExpandWidth(true));
                    EditorGUI.EndDisabledGroup();

                    logLevelSettings.LogLevels[i].Severity = EditorGUILayout.IntField(logLevelSettings.LogLevels[i].Severity, GUILayout.Width(60));
                    logLevelSettings.LogLevels[i].DisplayColor = EditorGUILayout.ColorField(logLevelSettings.LogLevels[i].DisplayColor, GUILayout.Width(100));
                    logLevelSettings.LogLevels[i].IncludeStackTrace = EditorGUILayout.Toggle(logLevelSettings.LogLevels[i].IncludeStackTrace, GUILayout.Width(80));

                    EditorGUI.BeginDisabledGroup(!logLevelSettings.LogLevels[i].IsEditable);
                    if (GUILayout.Button("-", GUILayout.Width(20)))
                    {
                        ArrayUtility.RemoveAt(ref logLevelSettings.LogLevels, i);
                        break;
                    }
                    EditorGUI.EndDisabledGroup();

                    EditorGUILayout.EndHorizontal();
                }

                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Add Log Level", GUILayout.Width(120)))
                {
                    ArrayUtility.Add(ref logLevelSettings.LogLevels, new LogLevelDetail("", logLevelSettings.LogLevels.Last().Severity + 1, new Color(), false));
                }
                GUILayout.EndHorizontal();

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}