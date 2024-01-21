using HarmonyLib;

namespace Hypick.Patches;

[HarmonyPatch(typeof(GrabbableObject))]
internal class GrabbableObjectPatch
{
    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    static void Start(GrabbableObject __instance)
    {
        if (Plugin.Config.AirhornActivate && __instance != null && __instance.GetComponent<NoisemakerProp>() != null && __instance.itemProperties.name == "Airhorn")
        {
            __instance.GetComponent<NoisemakerProp>().noiseSFX[0] = Plugin.MoaningsSFX[0];
            __instance.GetComponent<NoisemakerProp>().noiseSFXFar[0] = Plugin.MoaningsSFX[0];
        }

        // if (Plugin.Config.ShovelDropSFX && __instance.itemProperties.itemName == "Shovel") // maybe Large Axle
        // {
        //     __instance.itemProperties.dropSFX = Plugin.newShovelDropSFX[0];
        // }
    }
}