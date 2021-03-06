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


            try
            {
                Player A = ev.Attacker;
                Player T = ev.Target;
                if (A != T)
                {
                    if (T.IsCuffed && (A != T.Cuffer || NoCuffedKill.config.DetainerDamage == false) && (A.Side != T.Side))
                    {
                        ev.IsAllowed = false;
                        if (NoCuffedKill.config.RelfectCuffedDamage)
                        {
                            A.Hurt(ev.Amount, ev.DamageType);
                        }
                    }

                    if (NoCuffedKill.config.ReflectTKDamage && A.Side == T.Side && A.Team != Team.SCP)
                    {
                        ev.IsAllowed = false;
                        if (ev.DamageType == DamageTypes.Grenade && NoCuffedKill.config.ReflectGrenadeTKDamage)
                        {
                            A.Hurt(ev.Amount, ev.DamageType);
                        }
                        else if (ev.DamageType != DamageTypes.Grenade && ev.DamageType != DamageTypes.Decont && ev.DamageType != DamageTypes.Falldown)
                        {
                            A.Hurt(ev.Amount, ev.DamageType);
                        }
                    }
                }
            }
            catch
            {
                return;
            }


        }
    }
}
