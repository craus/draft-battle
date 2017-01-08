using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections.Generic;

public class MatchList : MonoBehaviour
{
    public JoinMatchButton matchButtonPrefab;

    public void SetList(List<MatchInfoSnapshot> matchList) {
        transform.Children().ForEach(c => c.Destroy());
        matchList.ForEach(match => {
            var button = Instantiate(matchButtonPrefab);
            button.Init(match);
            button.transform.SetParent(transform);
        });
    }
}