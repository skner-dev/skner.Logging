using skner.Logging.Models;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace skner.Logging.Editor
{
    [CustomPropertyDrawer(typeof(LogPath))]
    internal class FilePathDrawer : PropertyDrawer
    {

        private const float _buttonWidth = 80f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var labelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height);
            EditorGUI.LabelField(labelRect, label);

            var pathTypeRect = new Rect(position.x + EditorGUIUtility.labelWidth + 2f, position.y, _buttonWidth, position.height);
            var customPathRect = new Rect(pathTypeRect.xMax + 2f, position.y, position.width - pathTypeRect.width - EditorGUIUtility.labelWidth - 5f - 20f, position.height);
            var buttonRect = new Rect(customPathRect.xMax + 2f, position.y, 20f, position.height);

            SerializedProperty pathTypeProperty = property.FindPropertyRelative("LocationType");
            EditorGUI.PropertyField(pathTypeRect, pathTypeProperty, GUIContent.none);

            SerializedProperty customPathProperty = property.FindPropertyRelative("RelativePath");
            customPathProperty.stringValue = EditorGUI.TextField(customPathRect, customPathProperty.stringValue);

            if (GUI.Button(buttonRect, "⋮"))
            {
                var logPath = new LogPath((LogPath.BasePath)pathTypeProperty.enumValueIndex, customPathProperty.stringValue);
                EditorUtility.RevealInFinder(logPath.GetCompletePath());
            }

            EditorGUI.EndProperty();
        }
    }
}