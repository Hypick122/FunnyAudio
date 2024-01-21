using System.Collections.Generic;
using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Hypick.Services;
using UnityEngine;

namespace Hypick;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static Plugin Instance { get; set; }

    public static ManualLogSource Log => Instance.Logger;

    public new static PluginConfig Config;

    private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

    public TemplateService Service;

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
    // internal static AudioClip[] NMBShotgunShoot;
    // internal static AudioClip[] NMBShotgunShoot2;
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
        
        Service = new TemplateService();

        Log.LogInfo($"Load assets...");
        LoadAssetBundle(GetFilePath("bonk"), out BonkSFX);
        // LoadAssetBundle(GetFilePath("metalpipe", out newShovelDropSFX);
        
        LoadAssetBundle(GetFilePath("vineboom"), out VineBoomSFX);
        
        LoadAssetBundle(GetFilePath("yippee"), out YippeeSFX);
        LoadAssetBundle(GetFilePath("ahh"), out AhhSFX);
        LoadAssetBundle(GetFilePath("angryscreech"), out AngryScreechSFX);

        LoadListAssetBundle(["fart", "fartfar"], FartsSFX);

        LoadListAssetBundle(["moaning", "moaningfar"], MoaningsSFX);

        LoadListAssetBundle(["blast", "blast2"], NMBShotgunShoots);
        LoadAssetBundle(GetFilePath("Shotgun/reload"), out NMBShotgunReload);
        LoadAssetBundle(GetFilePath("NutCracker/turn"), out NMBNutCrackerAim);
        LoadAssetBundle(GetFilePath("NutCracker/die"), out NMBNutCrackerDie);
        LoadAssetBundle(GetFilePath("NutCracker/hiteye"), out NMBNutCrackerHitEye);

        Log.LogInfo($"Applying patches...");
        _harmony.PatchAll();
        Log.LogInfo($"Patches applied");

        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} is fully loaded!");
    }

    private void LoadAssetBundle(string path, out AudioClip[] audioClips)
        {
            var bundle = AssetBundle.LoadFromFile(path);
            if (bundle == null)
            {
                Logger.LogError($"Failed to load asset bundle from {path}");
                audioClips = null;
            }
            else
            {
                audioClips = bundle.LoadAllAssets<AudioClip>();
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
                    Logger.LogError($"Failed to load asset bundle from {path}");
                }
                else
                {
                    audioClips.Add(bundle.LoadAllAssets<AudioClip>()[0]);
                }
            }
        }

        private string GetFilePath(string fileName)
        {
            string folderLocation = Path.GetDirectoryName(Plugin.Instance.Info.Location);
            return Path.Combine(folderLocation, "Assets", fileName);
        }

        // private static void LoadAudioClip(string filepath)
        // {
        //     UnityWebRequest audioClip = UnityWebRequestMultimedia.GetAudioClip(filepath, AudioType.OGGVORBIS);
        //     audioClip.SendWebRequest();
        //     while (!audioClip.isDone) { }
        //     if (audioClip.error != null)
        //     {
        //         Logger.LogError("Error loading sounds: " + filepath + "\n" + audioClip.error);
        //     }
        //     AudioClip content = DownloadHandlerAudioClip.GetContent(audioClip);
        //     if ((bool)content && (int)content.loadState == 2)
        //     {
        //         Logger.LogInfo("Loaded " + filepath);
        //         content.name = Path.GetFileName(filepath);
        //         clips.Add(content);
        //     }
        // }
}
