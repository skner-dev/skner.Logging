using skner.Logging.OutputSettings.Common;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomPropertyDrawer(typeof(LogOutputSelector))]
    internal class LogOutputSelectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            position.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(position, new GUIContent("Log Output Selector"), EditorStyles.whiteLabel);
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.PropertyField(position, property.FindPropertyRelative("IncludedFields"), new GUIContent("Fields to Include"));

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 3;
        }
    }
}