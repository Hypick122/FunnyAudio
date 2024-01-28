using HarmonyLib;
using UnityEngine;

namespace Hypick.Patches;

[HarmonyPatch(typeof(ShotgunItem))]
internal class ShotgunItemPatch
{
    // public AudioClip[] gunShootSFX;
    // public AudioClip gunReloadSFX;
    // public AudioClip gunReloadFinishSFX;
    // public AudioClip noAmmoSFX;
    // public AudioClip gunSafetySFX;
    // public AudioClip switchSafetyOnSFX;
    // public AudioClip switchSafetyOffSFX;

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    static void Start(ref AudioClip ___gunReloadSFX)
    {
        if (Plugin.Config.ShotgunNeedMoreBullets)
            ___gunReloadSFX = Plugin.NMBShotgunReload[0];
    }

    [HarmonyPatch("ShootGun")]
    [HarmonyPrefix]
    static void ShootGun(ShotgunItem __instance)
    {
        if (Plugin.Config.ShotgunNeedMoreBullets)
        {
            // ___gunShootSFX = Plugin.NMBShotgunShoots[Random.Range(0, Plugin.NMBShotgunShoots.Count)];
            AudioSource audioSource = __instance.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(Plugin.NMBShotgunShoots[Random.Range(0, Plugin.NMBShotgunShoots.Count)], 1f);
        }
    }
}
