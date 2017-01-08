using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {
    public Battle battle;
    public UserController player;
    public BattlePanel battlePanel;
    public Bot bot = new Bot();

    public void Start() {
        battle = new Battle();
        battle.units.Add(new Unit(2, 3).Of(player));
        battle.units.Add(new Unit(2, 4).Of(player));
        battle.units.Add(new Unit(3, 5).Of(player));
        battle.units.Add(new Unit(3, 8).Of(player));

        battle.units.Add(new Unit(2, 4).Of(bot));
        battle.units.Add(new Unit(3, 5).Of(bot));
        battle.units.Add(new Unit(3, 8).Of(bot));
        battle.units.Add(new Unit(4, 11).Of(bot));

        battlePanel.Init(battle);
    }
}
