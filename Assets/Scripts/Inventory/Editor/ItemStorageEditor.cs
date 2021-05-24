using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
using System;

using ARPG.Gear;
using ARPG.Combat;
using ARPG.Stats;

namespace ARPG.Inventory
{
    [CustomEditor(typeof(ItemStorage))]
    public class ItemStorageEditor : Editor
    {
        ItemStorage storage;
        ReorderableList storageList;
        int focusedElementIndex = -1;

        void OnEnable()
        {
            storage = (ItemStorage) target;
            storageList = new ReorderableList(serializedObject, serializedObject.FindProperty("itemSlots"), true, true, true, true);

            storageList.drawElementCallback = DrawElementCallback;
            storageList.onAddCallback = OnAddCallback;
            storageList.onRemoveCallback = OnRemoveCallback;
        }

        public override void OnInspectorGUI()
        {
            focusedElementIndex = -1;

            serializedObject.Update();
            storageList.DoLayoutList();

            StackEqualItems();

            serializedObject.ApplyModifiedProperties();
        }

        void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (isFocused)
                focusedElementIndex = index;

            SerializedProperty element = storageList.serializedProperty.GetArrayElementAtIndex(index);

            float sl = EditorGUIUtility.singleLineHeight;
            float x = rect.x;
            float y = rect.y + EditorGUIUtility.standardVerticalSpacing;
            
            x += 10f;
            Equipment equipment = storage.GetComponent<Equipment>();
            if (equipment != null)
            {
                Item item = storage.ItemSlots[index].Item;
                IEquipable equipable = storage.ItemSlots[index].Item as IEquipable;
                if (equipable != null)
                {
                    bool isEquipped = equipment.GetSlot(equipable) != null;
                    if (isEquipped != GUI.Toggle(new Rect(x, y, sl, sl), isEquipped, GUIContent.none))
                    {
                        item.Use(storage.gameObject);
                        Save();
                    }
                }
            }

            x += 30f;
            EditorGUI.PropertyField(
                new Rect(x, y, 200, sl),
                element.FindPropertyRelative("item"), GUIContent.none);

            x += 210f;
            EditorGUI.PropertyField(
                new Rect(x, y, 50, sl),
                element.FindPropertyRelative("count"), GUIContent.none);
        }

        void OnAddCallback(ReorderableList list)
        {
            storageList.serializedProperty.arraySize++;
            SerializedProperty newElement = storageList.serializedProperty.GetArrayElementAtIndex(storageList.serializedProperty.arraySize - 1);
            newElement.FindPropertyRelative("item").objectReferenceValue = null;
            newElement.FindPropertyRelative("count").intValue = 1;
        }

        void OnRemoveCallback(ReorderableList list)
        {
            Delete(focusedElementIndex);
        }

        void StackEqualItems()
        {
            for (int i = 0; i < storageList.serializedProperty.arraySize; i++)
            {
                SerializedProperty elementi = storageList.serializedProperty.GetArrayElementAtIndex(i);
                for (int j = i + 1; j < storageList.serializedProperty.arraySize; j++)
                {
                    SerializedProperty elementj = storageList.serializedProperty.GetArrayElementAtIndex(j);
                    if (elementi.FindPropertyRelative("item").objectReferenceValue == elementj.FindPropertyRelative("item").objectReferenceValue)
                    {
                        Debug.Log("Stacked Items: " + i + "-" + j);
                        elementi.FindPropertyRelative("count").intValue += elementj.FindPropertyRelative("count").intValue;
                        storageList.serializedProperty.DeleteArrayElementAtIndex(j);
                        j--;
                    }
                }
                
            }
        }

        void Save()
        {
            EditorUtility.SetDirty(target);

            Equipment equipment = storage.GetComponent<Equipment>();
            if (equipment != null)
            {
                List<EquipmentSlot> slots = equipment.Slots;
                foreach (EquipmentSlot slot in slots)
                    EditorUtility.SetDirty(slot);
                EditorUtility.SetDirty(equipment);
            }

            BaseCombat baseCombat = storage.GetComponent<BaseCombat>();
            if (baseCombat != null)
                EditorUtility.SetDirty(baseCombat);

            CharacterStats characterStats = storage.GetComponent<CharacterStats>();
            if (characterStats != null)
                EditorUtility.SetDirty(characterStats);
        }

        void Delete(int index)
        {
            if (0 <= index && index < storageList.serializedProperty.arraySize)
            {
                Item item = storage.ItemSlots[index].Item;
                storageList.serializedProperty.DeleteArrayElementAtIndex(index);

                IEquipable equipable = storage.ItemSlots[index].Item as IEquipable;
                if (equipable == null)
                    return;

                Equipment equipment = storage.GetComponent<Equipment>();
                bool isEquipped = equipment.GetSlot(equipable) != null;
                if (isEquipped)
                {
                    equipable.Unequip(equipment);
                    Save();
                }
            }
        }
    }
}