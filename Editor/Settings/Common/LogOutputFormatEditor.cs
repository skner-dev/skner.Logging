using skner.Logging.OutputSettings.Common;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomPropertyDrawer(typeof(LogOutputFormat))]
    internal class LogOutputFormatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            position.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(position, new GUIContent("Log Output Formatter"), EditorStyles.whiteLabel);
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            SerializedProperty formatProperty = property.FindPropertyRelative("Format");
            position.height = EditorGUIUtility.singleLineHeight * 3;
            EditorGUI.PropertyField(position, formatProperty);

            position.y += EditorGUIUtility.singleLineHeight * 3 + EditorGUIUtility.standardVerticalSpacing;
            position.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(position, property.FindPropertyRelative("KeepRichText"), new GUIContent("Keep Rich Text"));

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 6;
        }
    }
}