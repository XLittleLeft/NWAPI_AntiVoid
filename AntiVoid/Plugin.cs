using PlayerRoles.FirstPersonControl.Spawnpoints;
using PlayerRoles.FirstPersonControl;
using PlayerRoles;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PluginAPI.Core;
using RelativePositioning;

namespace AntiVoid
{
    public class Plugin
    {
        [PluginEntryPoint("AntiVoid","1.0.0","AntiVoid","X小左(XLittleLeft)")]
        void OnLoad()
        {
            EventManager.RegisterEvents(this);
        }
    }
}
