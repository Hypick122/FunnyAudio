using System.Collections.Generic;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace Hypick;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    public new static PluginConfig Config;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    internal static AudioClip[] BonkSFX;
    // internal static AudioClip[] newShovelDropSFX;

    internal static AudioClip[] VineBoomSFX;
    
    internal static AudioClip[] YippeeSFX;
    internal static AudioClip[] AhhSFX;
    // internal static AudioClip[] newHitPlayerSFX; // Om nom nom
    internal static AudioClip[] AngryScreechSFX;

    internal static List<AudioClip> FartsSFX = new();

    internal static List<AudioClip> MoaningsSFX = new();

    // NeedMoreBullets
    internal static List<AudioClip> NMBShotgunShoots = new();
    internal static AudioClip[] NMBShotgunReload;

    internal static AudioClip[] NMBNutCrackerAim;
    internal static AudioClip[] NMBNutCrackerDie;
    internal static AudioClip[] NMBNutCrackerHitEye;

    // internal static AudioClip[] TurretFire;
    // internal static AudioClip[] TurretFireFar;

    // internal static AudioClip[] Giant; // Om nom nom

    public Plugin()
    {
        Instance = this;
    }

    private void Awake()
    {
        Config = new PluginConfig(base.Config);

        Log.LogInfo($"Load assets...");
        LoadAssetBundle("bonk", out BonkSFX);
        // LoadAssetBundle(GetFilePath("metalpipe", out newShovelDropSFX);
        
        LoadAssetBundle("vineboom", out VineBoomSFX);
        
        LoadAssetBundle("yippee", out YippeeSFX);
        LoadAssetBundle("ahh", out AhhSFX);
        LoadAssetBundle("angryscreech", out AngryScreechSFX);

        LoadListAssetBundle(["fart", "fartfar"], FartsSFX);

        LoadListAssetBundle(["moaning", "moaningfar"], MoaningsSFX);

        LoadListAssetBundle(["Shotgun/blast", "Shotgun/blast2"], NMBShotgunShoots);
        LoadAssetBundle("Shotgun/reload", out NMBShotgunReload);
        LoadAssetBundle("NutCracker/nutcrackerturn", out NMBNutCrackerAim);
        LoadAssetBundle("NutCracker/nutcrackerdie", out NMBNutCrackerDie);
        LoadAssetBundle("NutCracker/nutcrackerhiteye", out NMBNutCrackerHitEye);

        Log.LogInfo($"Applying patches...");
        _harmony.PatchAll();
        Log.LogInfo($"Patches applied");

        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} is fully loaded!");
    }

    private void LoadAssetBundle(string fileName, out AudioClip[] audioClips)
    {
        var path = GetFilePath(fileName);
        var bundle = AssetBundle.LoadFromFile(path);
        if (bundle == null)
        {
            Log.LogError($"Failed to load asset bundle from {path}");
            audioClips = null;
        }
        else
        {
            audioClips = bundle.LoadAllAssets<AudioClip>();
            Log.LogInfo($"Asset {fileName} is loaded");
        }
    }

    private void LoadListAssetBundle(string[] fileNames, List<AudioClip> audioClips)
    {
        foreach (string fileName in fileNames)
        {
            var path = GetFilePath(fileName);
            var bundle = AssetBundle.LoadFromFile(path);
            if (bundle == null)
            {
                Log.LogError($"Failed to load asset bundle from {path}");
            }
            else
            {
                audioClips.Add(bundle.LoadAllAssets<AudioClip>()[0]);
                Log.LogInfo($"Asset {fileName} is loaded");
            }
        }
    }

    private string GetFilePath(string fileName)
    {
        string folderLocation = Path.GetDirectoryName(Instance.Info.Location);
        return Path.Combine(folderLocation, "Assets", fileName);
    }
}
