using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
using Hints;
using UnityEngine;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Player = Exiled.API.Features.Player;

namespace NoCuffedKill
{
    public class EventHandler
    {
        public static void OnPlayerHurt(HurtingEventArgs ev)
        {
            bool Reflect = NoCuffedKill.config.RelfectDamage;
            bool DetainerDamage = NoCuffedKill.config.DetainerDamage;
            Player A = ev.Attacker;
            Player T = ev.Target;

            if(T.IsCuffed && (A != T.Cuffer || DetainerDamage == false) && (A.Side != T.Side))
            {
                ev.IsAllowed = false;
                if (Reflect)
                {
                    A.Hurt(ev.Amount);
                }
            }
        }
    }
}
