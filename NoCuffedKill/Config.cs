using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.API.Enums;
using System.ComponentModel;


namespace NoCuffedKill
{
    public class Config : IConfig
    {
        [Description("Enable or disable the plugin")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not the plugin should reflect damage")]
        public bool RelfectCuffedDamage { get; set; } = true;

        [Description("whether or not the detainer can kill the detainee")]
        public bool DetainerDamage { get; set; } = false;

        [Description("Whether or not attempted team killing damage should be reflected")]
        public bool ReflectTKDamage { get; set; } = false;
    }
}
