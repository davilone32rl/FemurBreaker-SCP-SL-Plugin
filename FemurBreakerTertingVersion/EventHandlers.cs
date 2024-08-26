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
    using MEC;
    using AudioPlayer.API;

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
                        ev.Player.Kill(plugin.Config.OnSacrificeDeathReason, plugin.Config.CassieAnounceWhitPlayerDead);
                    }
                    else
                    {
                        ev.Player.Kill(plugin.Config.OnSacrificeDeathReason);
                    }
                    
                    return;
                }

                if (playerAlive == 1)
                {
                    if (plugin.Config.UseGenerators)
                    {
                        if (Generator.Get(Exiled.API.Enums.GeneratorState.Activating).Count() == plugin.Config.Generators)
                        {
                            if (Random.Range(1, 101) > plugin.Config.porcent)
                            {
                                playerAlive = 0;
                                ev.Player.Broadcast(4, plugin.Config.OnFailure);
                            }
                            else
                            {
                                playerAlive = 3;
                                ev.Player.Broadcast(4, plugin.Config.OnDeath);
                                List<Player> scp106 = Player.List.Where(p => p.Role == RoleTypeId.Scp106).ToList();
                                if (scp106 != null)
                                {
                                    foreach (Player player in scp106) {
                                        player.Hurt(9999, Exiled.API.Enums.DamageType.FemurBreaker);
                                    }
                                    Extension(plugin.Config.npc);
                                }
                            }
                        }
                        else
                        {
                            ev.Player.Broadcast(4, $"{plugin.Config.TextGenerators}" + $"{Generator.Get(Exiled.API.Enums.GeneratorState.Activating).Count()} / {plugin.Config.Generators}");
                        }
                    }
                    else
                    {
                        if (Random.Range(1, 101) > plugin.Config.porcent)
                        {
                            playerAlive = 0;
                            ev.Player.Broadcast(4, plugin.Config.OnFailure);
                        }
                        else
                        {
                            playerAlive = 3;
                            ev.Player.Broadcast(4, plugin.Config.OnDeath);
                            List<Player> scp106 = Player.List.Where(p => p.Role == RoleTypeId.Scp106).ToList();
                            if (scp106 != null)
                            {
                                foreach (Player player in scp106) { player.Kill(plugin.Config.OnRecontainmentDeath); }
                                Extension(plugin.Config.npc);
                            }
                        }
                    }


                }
                else
                {
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
                    var path = System.IO.Path.Combine(Paths.Plugins, "Audio", plugin.Config.FileAudioName + ".ogg");
                    var npc = AudioPlayer.Other.Extensions.SpawnDummy(name: plugin.Config.OnNameBot, id: 99, badgetext: plugin.Config.BotBadgetName, bagdecolor: plugin.Config.BadgetBotColor);
                    npc.hubPlayer.roleManager.ServerSetRole(RoleTypeId.Overwatch, RoleChangeReason.Died);
                    var audio = AudioPlayerBase.Get(npc.hubPlayer);
                    audio.BroadcastChannel = VoiceChat.VoiceChatChannel.Intercom;
                    audio.AudioToPlay.Add(path);
                    audio.Play(0);
                    Timing.CallDelayed(plugin.Config.seconds, () =>
                    {
                        AudioController.DisconnectDummy(npc.BotID);
                    });
                }
                else
                {
                    return;
                }
            }
            else
            {
                Cassie.Message(plugin.Config.Cassie);
            }
        }

        public void OnRestart(RoundEndedEventArgs ev)
        {
            playerAlive = 0;
        }
    }
}
