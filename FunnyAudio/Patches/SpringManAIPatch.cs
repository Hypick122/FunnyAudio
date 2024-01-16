using FunnyAudio.Core;
using HarmonyLib;
using UnityEngine;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(SpringManAI))]
    internal class SpringManAIPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void Update(ref AudioClip[] ___springNoises)
        {
            if (Plugin.Config.SpringNoises)
            {
                ___springNoises = Plugin.newSpringNoises;
            }
        }
    }
}