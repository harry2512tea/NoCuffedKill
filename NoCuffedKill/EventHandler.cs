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
        private static bool Reflect = NoCuffedKill.config.RelfectDamage;
        private static bool DetainerDamage = NoCuffedKill.config.DetainerDamage;


        public static void OnPlayerHurt(HurtingEventArgs ev)
        {
            Player A = ev.Attacker;
            Player T = ev.Target;

            if(T.IsCuffed)
            {
                if (!(A == T.Cuffer) || DetainerDamage == false)
                {
                    switch (T.Team)
                    {
                        case Team.CDP:
                            switch (A.Team)
                            {
                                case Team.MTF:

                                    ev.IsAllowed = false;
                                    if (Reflect)
                                    {
                                        A.Hurt(ev.Amount);
                                    }
                                    break;
                                case Team.RSC:

                                    ev.IsAllowed = false;
                                    if (Reflect)
                                    {
                                        A.Hurt(ev.Amount);
                                    }
                                    break;
                            }
                            break;
                        case Team.RSC:
                            switch (A.Team)
                            {
                                case Team.CHI:

                                    ev.IsAllowed = false;
                                    if (Reflect)
                                    {
                                        A.Hurt(ev.Amount);
                                    }
                                    break;
                                case Team.CDP:

                                    ev.IsAllowed = false;
                                    if (Reflect)
                                    {
                                        A.Hurt(ev.Amount);
                                    }
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
