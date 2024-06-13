using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[CustomEditor(typeof(SkillSO))]
public class SkillSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SkillSO skill = (SkillSO)target;

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
            EditorGUILayout.PropertyField(serializedObject.FindProperty("IsCombinedDamage"), new GUIContent("Combined Damage"));
        }

        if(skill.IsDamaging && skill.damageType.Count > 1)
        {
            skill.IsCombinedDamage = true;
        }
        else
        {
            skill.IsCombinedDamage = false;
        }

        // Применить изменения
        serializedObject.ApplyModifiedProperties();
    }

   
}
