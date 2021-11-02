using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace NoCuffedKill
{
    public class NoCuffedKill : Plugin<Config>
    {
        public static Config config;
        public EventHandler EventHandler;
        public override string Name { get; } = "NoCuffedKill";
        public override string Author { get; } = "Thire";
        public override Version Version { get; } = new Version(0, 1, 1);
        public override Version RequiredExiledVersion { get; } = new Version(3, 3, 1);
        public override string Prefix { get; } = "NCK";
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        internal static NoCuffedKill Instance;
        public override void OnEnabled()
        {
            Log.Info("NoCuffedKill is currently Enabled, Thank you!");
            Instance = this;
            EventHandler = new EventHandler();
            Player.Hurting += EventHandler.OnPlayerHurt;
        }

        public override void OnDisabled()
        {
            Player.Hurting -= EventHandler.OnPlayerHurt;
        }
    }
}
