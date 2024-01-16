using FunnyAudio.Core;
using HarmonyLib;
using UnityEngine;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugAIPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void Start(ref AudioClip[] ___chitterSFX, ref AudioClip ___hitPlayerSFX, ref AudioClip ___angryVoiceSFX)
        {
            ___chitterSFX = Plugin.Config.ChitterSFX ? Plugin.newChitterSFX : ___chitterSFX;
            ___hitPlayerSFX = Plugin.Config.HitPlayerSFX ? Plugin.newHitPlayerSFX[0] : ___hitPlayerSFX;
            ___angryVoiceSFX = Plugin.Config.AngryVoiceSFX ? Plugin.newAngryVoiceSFX[0] : ___angryVoiceSFX;
        }
    }
}