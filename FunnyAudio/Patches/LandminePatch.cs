using HarmonyLib;
using UnityEngine;

namespace Hypick.Patches;

[HarmonyPatch(typeof(Landmine))]
internal class LandminePatch
{
    // public AudioSource mineAudio;
    // public AudioSource mineFarAudio;
    // public AudioClip mineDetonate;
    // public AudioClip mineTrigger;
    // public AudioClip mineDetonateFar;
    // public AudioClip mineDeactivate;
    // public AudioClip minePress;

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    static void Start(ref AudioClip[] ___mineDetonate, ref AudioClip[] ___mineDetonateFar)
    {
        if (Plugin.Config.MineDetonate)
        {
            ___mineDetonate[0] = Plugin.FartsSFX[0];
            ___mineDetonateFar[0] = Plugin.FartsSFX[1];
        }
    }
}
