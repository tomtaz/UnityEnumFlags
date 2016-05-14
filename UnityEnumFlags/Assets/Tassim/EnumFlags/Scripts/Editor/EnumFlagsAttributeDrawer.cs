// from http://www.sharkbombs.com/2015/02/17/unity-editor-enum-flags-as-toggle-buttons/
// Extended by Tassim to handle GUIContent.none // mailto : thomas.tabbaza@gmail.com
// Also, flags should always start with a default value of 0, this was not considered

using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
public class EnumFlagsAttributeDrawer : PropertyDrawer {
    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label) {
        // -1 accounts for the Default value wich should always be 0, thus not displayed
        bool[] buttons = new bool[prop.enumNames.Length - 1]; 
        float buttonWidth = (pos.width - (label == GUIContent.none ? 0 : EditorGUIUtility.labelWidth)) / buttons.Length;

        if (label != GUIContent.none) {
            EditorGUI.LabelField(new Rect(pos.x, pos.y, EditorGUIUtility.labelWidth, pos.height), label);
        }

        // Handle button value
        EditorGUI.BeginChangeCheck();

        int buttonsValue = 0;
        for (int i = 0; i < buttons.Length; i++) {

            // Check if the button is/was pressed 
            if ((prop.intValue & (1 << i)) == (1 << i)) {
                buttons[i] = true;
            }

            // Display the button
            Rect buttonPos = new Rect(pos.x + (label == GUIContent.none ? 0 : EditorGUIUtility.labelWidth) + buttonWidth * i, pos.y, buttonWidth, pos.height);
            buttons[i] = GUI.Toggle(buttonPos, buttons[i], prop.enumNames[i + 1], "Button");

            if (buttons[i]) {
                buttonsValue += 1 << i;
            }
        }

        // This is set to true if a control changed in the previous BeginChangeCheck block
        if (EditorGUI.EndChangeCheck()) {
            prop.intValue = buttonsValue;
        }
    }
}