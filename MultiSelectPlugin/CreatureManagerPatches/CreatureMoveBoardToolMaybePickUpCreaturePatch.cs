using BepInEx;
using DataModel;
using HarmonyLib;
using LordAshes;
using UnityEngine;

namespace MultiSelect.CreatureManagerPatches
{
    [HarmonyPatch(typeof(CreatureMoveBoardTool), "MaybePickUpCreature")]
    [BepInDependency(StatMessaging.Guid)]
    internal class CreatureMoveBoardToolMaybePickUpCreaturePatch
    {
        internal static bool Prefix(CameraController.CameraClickEvent click)
        {
            CreatureBoardAsset creatureBoardAsset;
            var r = PixelPickingManager.TryGetPicked(out _, out PlaceableRef _, out creatureBoardAsset, out Component _);
            if (r == PixelPickingManager.PickedKind.CreatureBoardAsset && Input.GetKey(KeyCode.LeftControl))
            {
                var current = creatureBoardAsset;
                if (MultiSelectPlugin.SelectedCreatures.Contains(current.Creature))
                {
                    MultiSelectPlugin.ClearMiniFromSelection(current.Creature);
                }
                else
                {
                    MultiSelectPlugin.AddMiniToSelection(current.Creature);
                }
                return false;
            }
            return true;
        }
    }
}