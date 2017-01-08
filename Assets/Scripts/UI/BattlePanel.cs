using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class BattlePanel : MonoBehaviour
{
    public Battle battle;
    public PlayerPanel playerPanelPrefab;

    public List<PlayerPanel> playerPanels;

    public void Init(Battle battle) {
        this.battle = battle;
        var sides = battle.units.Select(u => u.controller).Distinct().ToList();
        sides.ForEach(side => {
            var playerPanel = Instantiate(playerPanelPrefab);
            playerPanel.Init(side, battle);
            playerPanels.Add(playerPanel);
            playerPanel.transform.SetParent(transform);
        });
    }
}