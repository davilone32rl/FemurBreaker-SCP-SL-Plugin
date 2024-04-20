namespace Aguguero_negrito
{
    using Exiled.API.Features;
    using Exiled.API.Features.Components;
    using Exiled.API.Features.Roles;
    using Exiled.Events.EventArgs.Player;
    using Exiled.Events.Handlers;
    using MapEditorReborn.Events.EventArgs;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    using PlayerRoles;
    using Exiled.Loader;
    using Random = UnityEngine.Random;
    using Player = Exiled.API.Features.Player;
    using System.Collections;
    using System.Linq;
    using PluginAPI.Events;
    using Exiled.API.Extensions;
    using Exiled.Events.EventArgs.Server;
    using SCPSLAudioApi;

    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        float playerAlive = 0;
        public void OnTrap(ButtonInteractedEventArgs ev )
        {

            if (ev.Button.GameObject.name == "Button106FirstInteract")
            {
                if (playerAlive == 0)
                {
                    playerAlive = 1;
                    ev.Player.Kill(plugin.Config.OnSacrificeDeathReason, "A player sacrificed himself for the recontainment of scp 106");
                    return;
                }
                else
                {
                    ev.Player.Broadcast(new(plugin.Config.OnRequerimentsComplete, 5));
                }
            }

            if (ev.Button.GameObject.name == "Button106SecondInteract")
            {
                if (playerAlive == 1)
                {
                    if (Random.Range(1, 101) > plugin.Config.porcent)
                    {
                        // Falla la retención
                        playerAlive = 0;
                        ev.Player.Broadcast(new(plugin.Config.OnFailure, 5));                    
                    }
                    else
                    {
                        // Retención exitosa
                        playerAlive = 3;
                        ev.Player.Broadcast(new(plugin.Config.OnDeath, 5));
                        List<Player> scp106 = Player.List.Where(p => p.Role == RoleTypeId.Scp106).ToList();
                        if (scp106 != null)
                        {
                            foreach (Player player in scp106) { player.Kill(plugin.Config.OnRecontainmentDeath, "SCP-106 successfully terminated. Termination cause Recontainment"); }
                            
                        }
                    }
                    
                }
                else
                {
                    // El jugador no ha interactuado con el primer botón
                    if (playerAlive == 3)
                    {
                        ev.Player.Broadcast(new(plugin.Config.OnRecontainmentRepeat, 5));
                    }
                    else
                    {
                        ev.Player.Broadcast(new(plugin.Config.OnRequirements, 5));
                    }  
                }
            }
        }

        public void OnRestart(RoundEndedEventArgs ev)
        {
            playerAlive = 0;
        }
    }
}
