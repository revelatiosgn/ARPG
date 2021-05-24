using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
using System;

using ARPG.Gear;
using ARPG.Combat;
using ARPG.Stats;

namespace ARPG.Spells
{
    [CustomEditor(typeof(Spellbook))]
    public class SpellbookEditor : Editor
    {
        Spellbook spellbook;
        ReorderableList spellbookList;
        int focusedElementIndex = -1;

        void OnEnable()
        {
            spellbook = (Spellbook) target;
            spellbookList = new ReorderableList(serializedObject, serializedObject.FindProperty("spells"), true, true, true, true);

            spellbookList.drawElementCallback = DrawElementCallback;
            spellbookList.onAddCallback = OnAddCallback;
            spellbookList.onRemoveCallback = OnRemoveCallback;
        }

        public override void OnInspectorGUI()
        {
            focusedElementIndex = -1;

            serializedObject.Update();
            spellbookList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (isFocused)
                focusedElementIndex = index;

            SerializedProperty element = spellbookList.serializedProperty.GetArrayElementAtIndex(index);

            float sl = EditorGUIUtility.singleLineHeight;
            float x = rect.x;
            float y = rect.y + EditorGUIUtility.standardVerticalSpacing;
            
            x += 10f;
            Equipment equipment = spellbook.GetComponent<Equipment>();
            if (equipment != null)
            {
                Spell spell = spellbook.Spells[index];
                bool isEquipped = equipment.GetSlot(spell) != null;
                if (isEquipped != GUI.Toggle(new Rect(x, y, sl, sl), isEquipped, GUIContent.none))
                {
                    if (isEquipped)
                        spell.Unequip(equipment);
                    else
                        spell.Equip(equipment);

                    Save();
                }
            }

            x += 30f;
            EditorGUI.PropertyField(
                new Rect(x, y, 200, sl),
                element, GUIContent.none);
        }

        void OnAddCallback(ReorderableList list)
        {
            spellbookList.serializedProperty.arraySize++;
            SerializedProperty newElement = spellbookList.serializedProperty.GetArrayElementAtIndex(spellbookList.serializedProperty.arraySize - 1);
        }

        void OnRemoveCallback(ReorderableList list)
        {
            Delete(focusedElementIndex);
        }

        void Save()
        {
            EditorUtility.SetDirty(target);

            Equipment equipment = spellbook.GetComponent<Equipment>();
            if (equipment != null)
            {
                List<EquipmentSlot> slots = equipment.Slots;
                foreach (EquipmentSlot slot in slots)
                    EditorUtility.SetDirty(slot);
                EditorUtility.SetDirty(equipment);
            }

            BaseCombat baseCombat = spellbook.GetComponent<BaseCombat>();
            if (baseCombat != null)
                EditorUtility.SetDirty(baseCombat);

            CharacterStats characterStats = spellbook.GetComponent<CharacterStats>();
            if (characterStats != null)
                EditorUtility.SetDirty(characterStats);
        }

        void Delete(int index)
        {
            if (0 <= index && index < spellbookList.serializedProperty.arraySize)
            {
                Spell spell = spellbook.Spells[index];
                spellbookList.serializedProperty.DeleteArrayElementAtIndex(index);

                Equipment equipment = spellbook.GetComponent<Equipment>();
                if (equipment != null)
                {
                    EquipmentSlot slot = equipment.GetSlot(spell);
                    if (slot != null)
                        spell.Unequip(equipment);    
                }

                Save();
            }
        }
    }
}