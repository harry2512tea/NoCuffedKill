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


        public static void OnPlayerHurt(HurtingEventArgs ev)
        {
            Player A = ev.Attacker;
            Player T = ev.Target;

            if(T.IsCuffed)
            {
                switch(T.Team)
                {
                    case Team.CDP:
                        switch(A.Team)
                        {
                            case Team.MTF:

                                T.Heal(ev.Amount);
                                if (Reflect)
                                {
                                    A.Hurt(ev.Amount);
                                }
                                break;
                            case Team.RSC:

                                T.Heal(ev.Amount);
                                if (Reflect)
                                {
                                    A.Hurt(ev.Amount);
                                }
                                break;
                        }
                        break;
                    case Team.RSC:
                        switch(A.Team)
                        {
                            case Team.CHI:

                                T.Heal(ev.Amount);
                                if (Reflect)
                                {
                                    A.Hurt(ev.Amount);
                                }
                                break;
                            case Team.CDP:

                                T.Heal(ev.Amount);
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
