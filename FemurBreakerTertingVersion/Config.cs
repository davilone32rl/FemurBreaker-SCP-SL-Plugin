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
        public string OnFailure { get; set; } = "!La recontencion del scp 106 a fallado¡ Busca a otra persona para la recontencion";
        [Description("OnDeath")]
        public string OnDeath { get; set; } = "!El scp 106 se recontuvo con exito¡";
        [Description("OnRecontainmentDeath")]
        public string OnRecontainmentDeath { get; set; } = "Recontenido";
        [Description("OnRecontainmentRepeat")]
        public string OnRecontainmentRepeat { get; set; } = "!Ya se recontuvo el viejo choto¡";
        [Description("OnRequirements")]
        public string OnRequirements { get; set; } = "!Falta que alguien se sacrifique¡";
        [Description("OnRequerimentsComplete")]
        public string OnRequerimentsComplete { get; set; } = "!Ya se sacrifico uno¡";
        [Description("OnSacrificeDeathReason")]
        public string OnSacrificeDeathReason { get; set; } = "!Eres un heroe¡";
        [Description("Bot name")]
        public string OnNameBot { get; set; } = "C.A.S.S.I.E";
    }
}
