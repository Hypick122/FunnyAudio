﻿using HarmonyLib;
using FunnyAudio.Core;
using UnityEngine;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(Shovel))]
    internal class ShovelPatch
    {
        // [HarmonyPatch("HitShovel")]
        // [HarmonyPrefix]
        // static void HitShovel(Shovel __instance)
        // {
        //     __instance.hitSFX = Plugin.newShovelHitSFX;
        // }

        [HarmonyPatch("HitShovelClientRpc")]
        [HarmonyPatch("HitShovel")]
        [HarmonyPrefix]
        static void HitShovel(ref AudioClip[] ___hitSFX)
        {
            if (Plugin.Config.ShovelHitSFX)
            {
                ___hitSFX = Plugin.newShovelHitSFX;
            }
        }
    }
}