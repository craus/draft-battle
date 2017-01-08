using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinMatchButton : NetworkBehaviour
{
    MatchInfoSnapshot match;

    public void Init(MatchInfoSnapshot match) {
        this.match = match;
        GetComponentInChildren<Text>().text = match.name;
        if (MyNetworkManager.instance.createdMatch != null && MyNetworkManager.instance.createdMatch.networkId == match.networkId) {
            GetComponentInChildren<Button>().interactable = false;
        }
        GetComponentInChildren<Button>().onClick.AddListener(Join);
    }

    void Join() {
        MyNetworkManager.instance.JoinMatch(match);
    }
}