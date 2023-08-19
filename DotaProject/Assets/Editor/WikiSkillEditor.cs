using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WikiSkill))]
public class WikiSkillEditor : Editor
{
    public override void OnInspectorGUI()
    {
        WikiSkill skill = (WikiSkill)target;

        DrawDefaultInspector(); // Отобразить обычные свойства

        if(skill.IsHasSomeSkills)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("otherSkills"), new GUIContent("Other Skills"));
        }

        if(skill.IsHasSummons)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("summon"), new GUIContent("Summons"));
        }

        if(skill.IsDamaging)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("damageType"), new GUIContent("Damage Type"));
        }

        // Применить изменения
        serializedObject.ApplyModifiedProperties();
    }

   
}
