using HenryMod.Survivors.Henry.Achievements;
using RoR2;
using UnityEngine;

namespace HenryMod.Survivors.Henry
{
    public static class GwenUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                GwenMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(GwenMasteryAchievement.identifier),
                GwenSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
