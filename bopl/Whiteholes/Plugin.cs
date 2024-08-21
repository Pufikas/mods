using BepInEx;
using BepInEx.Logging;
using BoplFixedMath;
using HarmonyLib;

namespace Whiteholes
{
    [BepInPlugin("me.pufikas." + PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private static Harmony harmony;
        private void Awake()
        {
            Log = Logger;

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            
            harmony = new Harmony("me.pufikas." + PluginInfo.PLUGIN_NAME);
            harmony.PatchAll(typeof(Patches));
        }
    }

    public class Patches
    {
        [HarmonyPatch(typeof(BlackHole), "Awake")]
        [HarmonyPrefix]
        public static void Patch(BlackHole __instance)
        {
            __instance.startingMass = (Fix)(-80L);
        }
    }
}
