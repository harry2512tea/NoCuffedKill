using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
using Hints;
using UnityEngine;
using Exiled.Events.EventArgs;
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

            if(ev.Target.IsCuffed)
            {
                switch(T.Team)
                {
                    case Team.CDP:

                        switch(A.Team)
                        {
                            case Team.MTF:
                                T.Health += ev.Amount;
                                if (Reflect)
                                {
                                    A.Health -= ev.Amount;
                                }
                                break;

                            case Team.RSC:
                                T.Health += ev.Amount;
                                if(Reflect)
                                {
                                    A.Health -= ev.Amount;
                                }
                                break;
                        }
                        break;

                    case Team.RSC:

                        switch(ev.Attacker.Team)
                        {
                            case Team.CDP:
                                T.Health += ev.Amount;
                                if (Reflect)
                                {
                                    A.Health -= ev.Amount;
                                }
                                break;

                            case Team.CHI:
                                T.Health += ev.Amount;
                                if (Reflect)
                                {
                                    A.Health -= ev.Amount;
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
