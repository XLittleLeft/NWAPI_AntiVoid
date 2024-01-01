using CommandSystem;
using MEC;
using NWAPIPermissionSystem;
using PluginAPI.Core;
using RelativePositioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AntiVoid
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class AntiVoidCommand : ICommand
    {
        public string Command => "AntiVoid";

        public string[] Aliases => new string[] { "AntiVoid" };

        public string Description => "Save yourself from the void";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player Player = Player.Get(sender);
            WaypointBase.GetRelativePosition(Player.Position, out byte id, out _);
            if (Player != null && Player.IsAlive && Player.Zone is MapGeneration.FacilityZone.None && (WaypointBase.TryGetWaypoint(id, out WaypointBase waypoint) && waypoint is not ElevatorWaypoint))
            {
                Player.IsGodModeEnabled = true;
                Timing.CallDelayed(1f, () =>
                {
                    Player.Position = XHelper.GetRandomSpawnLocation(Player.Role);
                });
                Timing.CallDelayed(3f, () =>
                {
                    Player.IsGodModeEnabled = false;
                });
                response = "Successfully";
                return true;
            }
            else
            {
                response = "Failed";
                return false;
            }
        }
    }
}
