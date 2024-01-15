using BepInEx.Configuration;

namespace FunnyAudio.Core
{
    public struct Categories
    {
        // public const string SFX = "SFX";
        public const string Shovel = "SFX.Shovel";
        public const string SpringMan = "SFX.SpringMan";
        public const string HoarderBug = "SFX.HoarderBug";
        public const string Landmine = "SFX.Landmine";
        public const string Airhorn = "SFX.Airhorn";
    }

    public class PluginConfig
    {
        public bool ShovelHitSFX { get; private set; }
        public bool SpringNoises { get; private set; }
        public bool ChitterSFX { get; private set; }
        public bool HitPlayerSFX { get; private set; }
        // public bool AngryVoiceSFX { get; private set; }
        public bool MineDetonate { get; private set; }
        public bool AirhornActivate { get; private set; }

        public PluginConfig(ConfigFile cfg)
        {
            ShovelHitSFX = cfg.Bind<bool>(Categories.Shovel, "ShovelHitSFX", true, "Replaces the sound of a shovel hitting with the sound of Bonk (https://www.youtube.com/watch?v=6TP0abZdRXg)").Value;

            SpringNoises = cfg.Bind<bool>(Categories.SpringMan, "SpringNoises", true, "Replaces coil spring sounds with Vine Boom sounds (https://www.youtube.com/watch?v=Oc7Cin_87H4)").Value;

            ChitterSFX = cfg.Bind<bool>(Categories.HoarderBug, "ChitterSFX", true, "Replaces the sound of the storage beetle chirping with the sound of Yippee (https://www.youtube.com/watch?v=0CqEKoy-fIQ)").Value;
            HitPlayerSFX = cfg.Bind<bool>(Categories.HoarderBug, "HitPlayerSFX", true, "Replaces the sound of the storage beetle hitting with the sound Ahh (https://www.youtube.com/watch?v=09gX0WL0AmI)").Value;
            // AngryVoiceSFX = cfg.Bind<bool>(Categories.HoarderBug, "AngryVoiceSFX", true, "").Value;

            MineDetonate = cfg.Bind<bool>(Categories.Landmine, "MineDetonate", true, "Replaces the sound of a mine explosion with a POWERFUL explosion").Value;

            AirhornActivate = cfg.Bind<bool>(Categories.Airhorn, "AirhornActivate", true, "replaces Airhorn sound with moans").Value;
        }
    }
}