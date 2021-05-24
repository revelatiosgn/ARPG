using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ARPG.Gear
{
    [CustomEditor(typeof(Customisation))]
    public class CustomisationEditor : Editor
    {
        Customisation customisation;

        void OnEnable()
        {
            customisation = (Customisation) target;
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            base.OnInspectorGUI();
            
            if (EditorGUI.EndChangeCheck())
            {
                Equipment equipment = customisation.GetComponent<Equipment>();
                if (equipment != null)
                {
                    if (customisation.Hair == null)
                        equipment.GetSlot(SlotType.Hair)?.Equipable?.Unequip(equipment);
                    else
                        customisation.Hair.Equip(equipment);

                    if (customisation.Eyebrows == null)
                        equipment.GetSlot(SlotType.Eyebrows)?.Equipable?.Unequip(equipment);
                    else
                        customisation.Eyebrows.Equip(equipment);

                    if (customisation.Beard == null)
                        equipment.GetSlot(SlotType.Beard)?.Equipable?.Unequip(equipment);
                    else
                        customisation.Beard.Equip(equipment);

                    List<EquipmentSlot> slots = equipment.Slots;
                    foreach (EquipmentSlot slot in slots)
                        EditorUtility.SetDirty(slot);
                }
            }
        }
    }
}