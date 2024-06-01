namespace FemurBreakerTertingVersion
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

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
    }
}
