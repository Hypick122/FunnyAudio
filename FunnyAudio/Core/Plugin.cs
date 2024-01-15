using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace FunnyAudio.Core
{
    [BepInPlugin(Metadata.PLUGIN_GUID, Metadata.PLUGIN_NAME, Metadata.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static Plugin Instance { get; private set; }

        private Harmony harmony;

        public new static PluginConfig Config { get; private set; }
        internal new static ManualLogSource Logger { get; private set; }

        internal static AudioClip[] newShovelHitSFX;

        internal static AudioClip[] newSpringNoises;

        internal static AudioClip[] newChitterSFX;
        internal static AudioClip[] newHitPlayerSFX;
        // internal static AudioClip[] newAngryVoiceSFX;

        internal static AudioClip[] newMineDetonate;
        // internal static AudioClip[] newMineDetonateFar;

        internal static AudioClip[] newAirhornActivate;
        internal static AudioClip[] newAirhornActivateFar;

        private void Awake()
        {
            if (Instance == null) Instance = this;

            Logger = base.Logger;
            Config = new PluginConfig(base.Config);

            string FolderLocation = Instance.Info.Location;
            FolderLocation = FolderLocation.TrimEnd("FunnyAudio.dll".ToCharArray());

            LoadAssetBundle(FolderLocation + "bonk", out newShovelHitSFX);

            LoadAssetBundle(FolderLocation + "vineboom", out newSpringNoises);

            LoadAssetBundle(FolderLocation + "yippee", out newChitterSFX);
            LoadAssetBundle(FolderLocation + "ahh", out newHitPlayerSFX);

            LoadAssetBundle(FolderLocation + "fart", out newMineDetonate);

            LoadAssetBundle(FolderLocation + "moaning", out newAirhornActivate);
            LoadAssetBundle(FolderLocation + "moaningfar", out newAirhornActivateFar);

            harmony = new Harmony(Metadata.PLUGIN_GUID);
            harmony.PatchAll();

            Logger.LogInfo($"Plugin {Metadata.PLUGIN_GUID} is loaded!");
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
    }
}