using System.Collections.Generic;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace MultiSelect
{
    [BepInPlugin(Guid, "MultiSelectPlugin", Version)]
	public partial class MultiSelectPlugin : BaseUnityPlugin
	{
		// constants
		public const string Guid = "org.hollofox.plugins.MultiSelectPlugin";
		public const string Version = "1.0.0.0";

        public static List<Creature> SelectedCreatures = new List<Creature>();

        public static void ClearMiniFromSelection(Creature c)
        {
            // Enable Indicator
            SelectedCreatures.Remove(c);
        }

        public static void AddMiniToSelection(Creature c)
        {
            // Disable Indicator
            SelectedCreatures.Add(c);
        }

        public static void ClearSelected()
        {
            Parallel.ForEach(SelectedCreatures, ClearMiniFromSelection);
        }

		/// <summary>
		/// Awake plugin
		/// </summary>
		void Awake()
		{
			Logger.LogInfo("In Awake for MultiSelect");
            Debug.Log("MultiSelect Plug-in loaded"); 
            var harmony = new Harmony(Guid);
            harmony.PatchAll();
        }
    }
}