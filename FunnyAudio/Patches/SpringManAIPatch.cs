using FunnyAudio.Core;
using HarmonyLib;

namespace FunnyAudio.Patches
{
    [HarmonyPatch(typeof(SpringManAI))]
    internal class SpringManAIPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void Update(SpringManAI __instance)
        {
            if (Plugin.Config.SpringNoises)
            {
                __instance.springNoises = Plugin.newSpringNoises;
            }
        }
    }
}