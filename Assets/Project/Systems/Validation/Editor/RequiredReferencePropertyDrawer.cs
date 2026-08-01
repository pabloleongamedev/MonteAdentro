using MonteAdentro.Systems.Validation.Runtime;
using UnityEditor;
using UnityEngine;

namespace MonteAdentro.Systems.Validation.Editor
{
    // Resalta en rojo un campo [RequiredReference] serializado si quedó vacío.
    // El bloqueo de build en sí lo hace SceneReferenceValidator.
    [CustomPropertyDrawer(typeof(RequiredReferenceAttribute))]
    public class RequiredReferencePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var isEmpty = property.propertyType == SerializedPropertyType.ObjectReference
                          && property.objectReferenceValue == null;

            var previousColor = GUI.color;
            if (isEmpty)
            {
                GUI.color = Color.red;
            }

            EditorGUI.PropertyField(position, property, label);

            GUI.color = previousColor;
        }
    }
}
