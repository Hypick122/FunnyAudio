using HarmonyLib;
using UnityEngine;

namespace Hypick.Patches;

[HarmonyPatch(typeof(SpringManAI))]
internal class SpringManAIPatch
{
    // public AudioClip[] springNoises;

    [HarmonyPatch("Update")]
    [HarmonyPostfix]
    static void Update(ref AudioClip[] ___springNoises)
    {
        if (Plugin.Config.SpringNoises)
            ___springNoises = Plugin.VineBoomSFX;
    }
}
