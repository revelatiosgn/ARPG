using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ARPG.Gear
{
    [CustomEditor(typeof(Equipment))]
    public class EquipmentEditor : Editor
    {
        Equipment equipment;

        void OnEnable()
        {
            equipment = (Equipment) target;
        }

        public override void OnInspectorGUI()
        {
            Material skinMaterial = equipment.SkinMaterial;
            Material hairMaterial = equipment.HairMaterial;

            EditorGUI.BeginChangeCheck();

            base.OnInspectorGUI();
            
            if (EditorGUI.EndChangeCheck())
            {
                if (skinMaterial != equipment.SkinMaterial || hairMaterial != equipment.HairMaterial)
                    equipment.UpdateMaterials();
            }
        }
    }
}