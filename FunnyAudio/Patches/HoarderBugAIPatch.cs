using HarmonyLib;
using UnityEngine;

namespace Hypick.Patches;

[HarmonyPatch(typeof(HoarderBugAI))]
internal class HoarderBugAIPatch
{
    // public AudioClip[] chitterSFX;
    // public AudioClip[] angryScreechSFX;
    // public AudioClip angryVoiceSFX;
    // public AudioClip bugFlySFX;
    // public AudioClip hitPlayerSFX;

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    static void Start(ref AudioClip[] ___chitterSFX, ref AudioClip ___hitPlayerSFX, ref AudioClip ___angryVoiceSFX)
    {
        ___chitterSFX = Plugin.Config.ChitterSFX ? Plugin.YippeeSFX : ___chitterSFX;
        ___hitPlayerSFX = Plugin.Config.HitPlayerSFX ? Plugin.AhhSFX[0] : ___hitPlayerSFX;
        ___angryVoiceSFX = Plugin.Config.AngryVoiceSFX ? Plugin.AngryScreechSFX[0] : ___angryVoiceSFX;
    }
}
