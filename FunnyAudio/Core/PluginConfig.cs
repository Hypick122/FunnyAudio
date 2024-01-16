using BepInEx.Configuration;

namespace FunnyAudio.Core
{
    public struct Categories
    {
        public const string Shovel = "Shovel";
        public const string SpringMan = "SpringMan";
        public const string HoarderBug = "HoarderBug";
        public const string Landmine = "Landmine";
        public const string Airhorn = "Airhorn";
        // public const string Door = "Door";
    }

    public class PluginConfig
    {
        public bool ShovelHitSFX { get; private set; }
        // public bool ShovelDropSFX { get; private set; }
        public bool SpringNoises { get; private set; }
        public bool ChitterSFX { get; private set; }
        public bool HitPlayerSFX { get; private set; }
        public bool AngryVoiceSFX { get; private set; }
        public bool MineDetonate { get; private set; }
        public bool AirhornActivate { get; private set; }
        // public bool DoorOpen { get; private set; }

        public PluginConfig(ConfigFile cfg)
        {
            ShovelHitSFX = cfg.Bind<bool>(Categories.Shovel, "ShovelHitSFX", true, "Replaces the sound of a shovel hitting with the sound of Bonk (https://www.youtube.com/watch?v=6TP0abZdRXg)").Value;
            // ShovelDropSFX = cfg.Bind<bool>(Categories.Shovel, "ShovelDropSFX", true, "(https://www.youtube.com/watch?v=f8mL0_4GeV0)").Value;

            SpringNoises = cfg.Bind<bool>(Categories.SpringMan, "SpringNoises", true, "Replaces coil spring sounds with Vine Boom sounds (https://www.youtube.com/watch?v=Oc7Cin_87H4)").Value;

            ChitterSFX = cfg.Bind<bool>(Categories.HoarderBug, "ChitterSFX", true, "Replaces the sound of the Hoarding Bug with the sound of Yippee (https://www.youtube.com/watch?v=0CqEKoy-fIQ)").Value;
            HitPlayerSFX = cfg.Bind<bool>(Categories.HoarderBug, "HitPlayerSFX", true, "Replaces the sound of the Hoarding Bug with the sound Ahh (https://www.youtube.com/watch?v=09gX0WL0AmI)").Value;
            AngryVoiceSFX = cfg.Bind<bool>(Categories.HoarderBug, "AngryVoiceSFX", true, "Replaces the Hoarding Bug aggressiveness sound with AAAAAAGHH").Value;

            MineDetonate = cfg.Bind<bool>(Categories.Landmine, "MineDetonate", true, "Replaces the sound of a mine explosion with a POWERFUL explosion").Value;

            AirhornActivate = cfg.Bind<bool>(Categories.Airhorn, "AirhornActivate", true, "Replaces Airhorn sound with moans").Value;

            // DoorOpen = cfg.Bind<bool>(Categories.Door, "DoorOpen", true, "").Value; // Minecraft
        }
    }
}