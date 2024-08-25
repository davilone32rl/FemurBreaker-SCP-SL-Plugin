namespace FemurBreakerTertingVersion
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using UnityEngine;
    using Waits;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("How many percent do you want the femurbreaker to get right?")]
        public float porcent { get; set; } = 25;
        [Description("Onfailure")]
        public string OnFailure { get; set; } = "!The recontainment of scp 106 has failed! Find another person for recontainment¡";
        [Description("OnDeath")]
        public string OnDeath { get; set; } = "SCP-106 has been successfully recontained!";
        [Description("Announcement that Cassie makes when a player restrains himself from killing 106")]
        public string CassieAnounceWhitPlayerDead = "A player sacrificed himself for the recontainment of scp 106";
        [Description("OnRecontainmentDeath")]
        public string OnRecontainmentDeath { get; set; } = "recontained!";
        [Description("OnRecontainmentRepeat")]
        public string OnRecontainmentRepeat { get; set; } = "The old bastard has been recontained!";
        [Description("OnRequirements")]
        public string OnRequirements { get; set; } = "Someone still needs to sacrifice themselves!";
        [Description("OnRequerimentsComplete")]
        public string OnRequerimentsComplete { get; set; } = "One has already sacrificed themselves!";
        [Description("OnSacrificeDeathReason")]
        public string OnSacrificeDeathReason { get; set; } = "You're a hero!";
        [Description("Bot name")]
        public string OnNameBot { get; set; } = "C.A.S.S.I.E";
        [Description("If you want the femurbreaker sound activate this")]
        public bool npc { get; set; } = true;
        [Description("seconds of audio")]
        public float seconds { get; set; } = 33f;
        [Description("Activate this if you want a cassie to say when someone sacrifices")]
        public bool CassieWithSacrificie { get; set; } = true;
        [Description("UseCassie")]
        public bool SoundOrNotsound { get; set; } = true;
        [Description("Cassie sound when 106 holds back (You will need to have \"UseCassie\" disabled)")]
        public string Cassie { get; set; } = "SCP 1 0 6 HAS BEEN SUCCEFULY RECOTIANETD BY FEMUR BREAKER";
        [Description("Use generators")]
        public bool UseGenerators { get; set; } = false;
        [Description("How many generators so that it can be activated")]
        public int Generators { get; set; } = 3;
        [Description("How many generators so that it can be activated")]
        public string TextGenerators { get; set; } = "Generators: ";
        [Description("The bot id")]
        public int BotId = 99;
        [Description("The bot badget name")]
        public string BotBadgetName = "C.A.S.S.I.E";
        [Description("The bot id")]
        public string BadgetBotColor = "orange";
        [Description("The file name (The audio must be in ogg format.)")]
        public string FileAudioName = "FemurSound";
    }
}
