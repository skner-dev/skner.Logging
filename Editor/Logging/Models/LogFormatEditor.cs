using skner.Logging.Models;
using skner.Logging.Settings;
using skner.Logging.Tags;
using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{

    [CustomPropertyDrawer(typeof(LogFormat))]
    internal class LogFormatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            SerializedProperty formatProperty = property.FindPropertyRelative("Format");

            GUI.enabled = false;
            Rect formatRect = new Rect(position.x, position.y, position.width - 22, position.height);
            EditorStyles.textField.wordWrap = true;
            EditorGUI.TextArea(formatRect, formatProperty.stringValue);
            GUI.enabled = true;

            Rect buttonRect = new Rect(position.x + position.width - 20, position.y, 20, 20);
            if (GUI.Button(buttonRect, "⋮"))
            {
                LogFormatEditorWindow.Init(formatProperty);
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) * 3;
        }
    }

    internal class LogFormatEditorWindow : EditorWindow
    {
        private SerializedProperty _formatProperty;
        private string _formatText;

        private PropertyInfo[] _properties;

        private Vector2 scrollPosition;

        private LogTagHolder _previewTagValues;

        public static void Init(SerializedProperty formatProperty)
        {
            LogFormatEditorWindow window = GetWindow<LogFormatEditorWindow>();
            window.titleContent = new GUIContent("Log Format Editor");
            window._formatProperty = formatProperty;
            window._formatText = formatProperty.stringValue;

            window.Show();
        }

        private void CreateGUI()
        {
            _properties = new LogTagHolder().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            _previewTagValues = new LogTagHolder()
            {
                ClassName = "SomeClass",
                LineNumber = 35,
                LogLevelName = LoggingSettingsProvider.LogLevelSettings.LogLevelDictionary["Warning"].LogLevelName,
                LogLevelHexColor = ColorUtility.ToHtmlStringRGB(LoggingSettingsProvider.LogLevelSettings.LogLevelDictionary["Warning"].DisplayColor),
                SourceLogger = "Global",
                MethodName = "SomeMethod",
                Timestamp = new DateTime(2020, 01, 01, 12, 30, 15).ToString(),
                Message = "This is an example of a log message.",
                StackTrace = "\n   at Namespace.SomeClass.SomeMethod() in NameSpace.SomeClass:35\r\n   at Namespace.AnotherClass.AnotherMethod() in NameSpace.AnotherClass:15"
            };
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            // Left Panel (Tags)
            GUILayout.BeginVertical(GUILayout.Width(130));
            GUILayout.Label("Available Tags", EditorStyles.boldLabel);
            GUILayout.Space(10);

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Height(position.height - 30));

            for (int i = 0; i < _properties.Length; i++)
            {
                string tagName = $"{_properties[i].Name}";

                if (GUILayout.Button(tagName, "Button"))
                {
                    GUI.FocusControl(null);
                    _formatText += $"{{{tagName}}}";
                }
            }

            EditorGUILayout.EndScrollView();
            GUILayout.EndVertical();

            // Right Panel (Text Field, Save, Cancel)
            GUILayout.BeginVertical();
            GUILayout.Label("Edit Log Format", EditorStyles.boldLabel);
            GUILayout.Space(10);
            _formatText = EditorGUILayout.TextArea(_formatText, GUILayout.MinHeight(EditorGUIUtility.singleLineHeight * 3));

            GUILayout.Label("Preview", EditorStyles.boldLabel);
            GUILayout.Space(5);
            GUILayout.BeginVertical("Box");
            string formattedLog = LogTagInterpreter.FormatLog(_previewTagValues, _formatText);
            GUIStyle style = new()
            {
                richText = true
            };
            EditorGUILayout.LabelField(formattedLog, style);
            GUILayout.Space((formattedLog.Count(x => x == '\n')) * EditorGUIUtility.singleLineHeight);
            GUILayout.EndVertical();

            GUILayout.Label("Instructions: \n" +
                "- Click on the tags to add them to your format. \n" +
                "- Click on the text area to manually edit the format. \n" +
                "- Supports <b>Rich Text</b>. \n" +
                "- StackTrace will only display if the LogLevel allows it.", EditorStyles.miniLabel);

            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Save"))
            {
                _formatProperty.stringValue = _formatText; // Update the serialized field with changes
                _formatProperty.serializedObject.ApplyModifiedProperties();
                Close();
            }

            if (GUILayout.Button("Cancel"))
            {
                Close();
            }

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
    }
}
