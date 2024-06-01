namespace FemurBreakerTertingVersion
{
    using Exiled.API.Features;
    using Merr = MapEditorReborn.Events.Handlers.Schematic;
    using ExiledhandlerS = Exiled.Events.Handlers.Server;
    using System.IO;

    public class Plugin : Plugin<Config>
    {
        private EventHandlers Handlers;
        public readonly string AudioPath = Path.Combine(Paths.Plugins, "audio");
        public override void OnEnabled()
        {

            if (!Directory.Exists(AudioPath))
            {
                Directory.CreateDirectory(AudioPath);
            }

            Handlers = new EventHandlers(this);
            ExiledhandlerS.RoundEnded += Handlers.OnRestart;
            Merr.ButtonInteracted += Handlers.OnTrap;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            ExiledhandlerS.RoundEnded -= Handlers.OnRestart;
            Merr.ButtonInteracted -= Handlers.OnTrap;
            Handlers = null;
            base.OnDisabled();
        }
    }
}
