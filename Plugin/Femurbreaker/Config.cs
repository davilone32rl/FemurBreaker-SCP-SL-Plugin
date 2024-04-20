namespace Aguguero_negrito
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    using Hints;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Cuanto porciento quieres que falle la recontencion del 106")]
        public float porcent { get; set; } = 25;
    }
}
