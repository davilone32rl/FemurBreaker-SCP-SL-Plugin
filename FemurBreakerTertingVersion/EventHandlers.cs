namespace FemurBreakerTertingVersion
{
    using Exiled.API.Features;
    using MapEditorReborn.Events.EventArgs;
    using System.Collections.Generic;
    using PlayerRoles;
    using Random = UnityEngine.Random;
    using Player = Exiled.API.Features.Player;
    using System.Linq;
    using Exiled.Events.EventArgs.Server;
    using SCPSLAudioApi.AudioCore;
    using System.Net.Http.Headers;
    using System.Threading;
    using MEC;

    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        float playerAlive = 0;
        public void OnTrap(ButtonInteractedEventArgs ev)
        {

            if (ev.Button.GameObject.name == "Button106")
            {
                if (playerAlive == 0)
                {
                    playerAlive = 1;
                    if (plugin.Config.CassieWithSacrificie)
                    {
                        ev.Player.Kill(plugin.Config.OnSacrificeDeathReason, "A player sacrificed himself for the recontainment of scp 106");
                    }
                    else
                    {
                        ev.Player.Kill(plugin.Config.OnSacrificeDeathReason);
                    }
                    
                    return;
                }

                if (playerAlive == 1)
                {
                    if (Random.Range(1, 101) > plugin.Config.porcent)
                    {
                        // Falla la retención
                        playerAlive = 0;
                        ev.Player.Broadcast(4, plugin.Config.OnFailure);
                    }
                    else
                    {
                        // Retención exitosa
                        playerAlive = 3;
                        ev.Player.Broadcast(4, plugin.Config.OnDeath);
                        List<Player> scp106 = Player.List.Where(p => p.Role == RoleTypeId.Scp106).ToList();
                        if (scp106 != null)
                        {
                            foreach (Player player in scp106) { player.Kill(plugin.Config.OnRecontainmentDeath, "SCP-106 successfully terminated. Termination cause Recontainment"); }
                            Extension(plugin.Config.npc);
                        }
                    }

                }
                else
                {
                    // El jugador no ha interactuado con el primer botón
                    if (playerAlive == 3)
                    {
                        ev.Player.Broadcast(4, plugin.Config.OnRecontainmentRepeat);
                    }
                    else
                    {
                        ev.Player.Broadcast(4, plugin.Config.OnRequirements);
                    }
                }
            }
        }
        
        public void Extension(bool YT)
        {
            if (plugin.Config.SoundOrNotsound) 
            {
                if (YT)
                {
                    var path = System.IO.Path.Combine(Paths.Plugins, "Audio", "FemurSound.ogg");
                    var npc = Npc.Spawn(plugin.Config.OnNameBot, RoleTypeId.Overwatch);
                    npc.RemoteAdminPermissions = PlayerPermissions.AFKImmunity;
                    var audio = AudioPlayerBase.Get(npc.ReferenceHub);
                    audio.BroadcastChannel = VoiceChat.VoiceChatChannel.Intercom;
                    audio.AudioToPlay.Add(path);
                    audio.Play(0);
                    Timing.CallDelayed(plugin.Config.seconds, () =>
                    {
                        npc.Destroy();
                    });
                }
                else
                {
                    return;
                }
            }
            else
            {
                Cassie.Message("SCP 1 0 6 HAS BEEN SUCCEFULY RECOTIANETD BY FEMUR BREAKER!");
            }
        }

        public void OnRestart(RoundEndedEventArgs ev)
        {
            playerAlive = 0;
        }
    }
}
