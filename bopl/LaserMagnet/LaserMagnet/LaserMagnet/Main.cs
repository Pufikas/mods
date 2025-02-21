using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;

namespace LaserMagnet
{
    [BepInPlugin("com.pufikas.LaserMagnet", "Laser Magnet", "0.0.1")]
    public class Main : BaseUnityPlugin
    {
        public void Awake()
        {
            Logger.LogInfo("LaserMagent initialized..");
            var harmony = new Harmony("com.pufikas.LaserMagnet");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(MagnetGun), "OnEnterAbility")]
        static class ShootLaser_Patch
        {
            static void Postfix(MagnetGun __instance)
            {
                AudioManager.Get().Play("beamFire");
  
            }
        }

        [HarmonyPatch(typeof(MagnetGun), "Update")]
        static class MagnetGun_Update_Patch
        {
            static void Postfix(MagnetGun __instance)
            {
                
            }
        }
    }
}
