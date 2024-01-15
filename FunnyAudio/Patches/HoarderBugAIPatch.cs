using FunnyAudio.Core;
using HarmonyLib;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugAIPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        // static void Start(ref AudioClip[] __chitterSFX, ref AudioClip __hitPlayerSFX, ref AudioClip __AngryVoiceSFX)
        static void Start(HoarderBugAI __instance)
        {
            if (Plugin.Config.ChitterSFX)
            {
                __instance.chitterSFX = Plugin.newChitterSFX;
            }
            if (Plugin.Config.HitPlayerSFX)
            {
                __instance.hitPlayerSFX = Plugin.newHitPlayerSFX[0];
            }
            // if (Plugin.Config.AngryVoiceSFX)
            // {
            //     __hitPlayerSFX = Plugin.newAngryVoiceSFX;
            // }
        }
    }
}
