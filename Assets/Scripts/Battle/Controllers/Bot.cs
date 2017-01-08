using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

public class Bot : Controller
{
    public void TakeControl(Battle battle) {
        var target = battle.units.FirstOrDefault(u => u.Alive() && u.controller != this);
        if (target != null) {
            battle.movingUnit.Attack(battle, target);
        } else {
            battle.movingUnit.SkipMove(battle);
        }
    }
}