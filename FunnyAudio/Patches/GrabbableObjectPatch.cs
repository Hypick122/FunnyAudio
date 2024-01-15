using FunnyAudio.Core;
using HarmonyLib;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(GrabbableObject))]
    internal class GrabbableObjectPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void Start(GrabbableObject __instance)
        {
            if (Plugin.Config.AirhornActivate && __instance != null && __instance.GetComponent<NoisemakerProp>() != null && __instance.itemProperties.name == "Airhorn")
            {
                __instance.GetComponent<NoisemakerProp>().noiseSFX[0] = Plugin.newAirhornActivate[0];
                __instance.GetComponent<NoisemakerProp>().noiseSFXFar[0] = Plugin.newAirhornActivateFar[0];
            }
        }
    }
}
