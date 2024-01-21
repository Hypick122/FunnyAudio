using HarmonyLib;
using UnityEngine;

namespace Hypick.Patches;

[HarmonyPatch(typeof(Shovel))]
internal class ShovelPatch
{

    // public AudioClip reelUp;
    // public AudioClip swing;
    // public AudioClip[] hitSFX;
    // public AudioSource shovelAudio;

    [HarmonyPatch("HitShovelClientRpc")]
    [HarmonyPatch("HitShovel")]
    [HarmonyPrefix]
    static void HitShovel(ref AudioClip[] ___hitSFX)
    {
        if (Plugin.Config.ShovelHitSFX)
        {
            ___hitSFX = Plugin.BonkSFX;
        }
    }
}