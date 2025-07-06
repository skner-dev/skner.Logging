using skner.Logging.OutputSettings.Common;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomPropertyDrawer(typeof(LogOutputFileWriter))]
    internal class LogOutputFileWriterDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            position.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(position, new GUIContent("Log Output File Writer"), EditorStyles.whiteLabel);
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.PropertyField(position, property.FindPropertyRelative("OutputPath"), new GUIContent("Output Path"));

            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            EditorGUI.PropertyField(position, property.FindPropertyRelative("OutputFileName"), new GUIContent("Output File Name"));

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 4;
        }
    }
}