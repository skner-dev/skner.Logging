using skner.Logging.OutputSettings.Common;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomPropertyDrawer(typeof(LogOutputBuffer))]
    internal class LogOutputBufferDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position.height = EditorGUIUtility.singleLineHeight;
            position.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(position, new GUIContent("Log Output Buffer"), EditorStyles.whiteLabel);
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            var isBufferEnabledProperty = property.FindPropertyRelative("IsBufferEnabled");
            isBufferEnabledProperty.boolValue = EditorGUI.Toggle(position, new GUIContent("Buffer Enabled"), isBufferEnabledProperty.boolValue);
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            if (isBufferEnabledProperty.boolValue)
            {
                var flushIntervalProperty = property.FindPropertyRelative("FlushInterval");
                flushIntervalProperty.floatValue = EditorGUI.FloatField(position, new GUIContent("Flush Interval"), flushIntervalProperty.floatValue);
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

                var bufferLengthIntervalProperty = property.FindPropertyRelative("BufferLengthInterval");
                bufferLengthIntervalProperty.intValue = EditorGUI.IntField(position, new GUIContent("Buffer Length Interval"), bufferLengthIntervalProperty.intValue);
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            bool isBufferEnabled = property.FindPropertyRelative("IsBufferEnabled").boolValue;
            int numberOfLines = isBufferEnabled ? 5 : 3;
            return EditorGUIUtility.singleLineHeight * numberOfLines;
        }
    }
}