using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class PlayerPanel : MonoBehaviour
{
    public Controller player;
    public Battle battle;
    public UnitPanel unitPanelPrefab;

    public List<UnitPanel> unitPanels;

    public void Init(Controller controller, Battle battle) {
        this.player = controller;
        this.battle = battle;
        var units = battle.units.Where(u => u.controller == player).ToList();
        units.ForEach(unit => {
            var unitPanel = Instantiate(unitPanelPrefab);
            unitPanel.Init(unit);
            unitPanels.Add(unitPanel);
            unitPanel.transform.SetParent(transform);
        });
    }
}