using HarmonyLib;
using FunnyAudio.Core;
using UnityEngine;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(Landmine))]
    internal class LandminePatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void Start(ref AudioClip[] ___mineDetonate, ref AudioClip[] ___mineDetonateFar)
        {
            if (Plugin.Config.MineDetonate)
            {
                ___mineDetonate = Plugin.newMineDetonate;
                ___mineDetonateFar = Plugin.newMineDetonate;
            }
        }
    }
}
