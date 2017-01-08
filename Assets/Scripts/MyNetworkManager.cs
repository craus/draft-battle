using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class MyNetworkManager : NetworkManager {
    public static MyNetworkManager instance;

    public uint playersPerMatch = 2;

    public float lastUpdateTime;
    public float updateTime = 1;

    public GameObject newMatchButton;
    public GameObject cancelMatchButton;
    public MatchList matchList;
    public InputField playerName;

    public MatchInfo createdMatch;

    public void Awake() {
        instance = this;
    }

    public void Start() {
        StartMatchMaker();
        RefreshMatchList();
    }

    public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList) {
        base.OnMatchList(success, extendedInfo, matchList);
        this.matchList.SetList(matches);
        Debug.LogFormat("Match list {0} items", matchList.Count);
    }

    public void RefreshMatchList() {
        matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
        lastUpdateTime = Time.time;
    }

    public void JoinMatch(MatchInfoSnapshot match) {
        matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, OnMatchJoined);
    }

    public void CreateMatch() {
        matchMaker.CreateMatch(playerName.text, playersPerMatch, true, "", "", "", 0, 0, OnMatchCreate);
    }

    public void CancelMatch() {
        matchMaker.DestroyMatch(createdMatch.networkId, 0, this.OnDestroyMatch);
        newMatchButton.SetActive(true);
    }

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo) {
        base.OnMatchCreate(success, extendedInfo, matchInfo);
        newMatchButton.SetActive(false);
        cancelMatchButton.SetActive(true);
        createdMatch = matchInfo;
    }

    public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo) {
        base.OnMatchJoined(success, extendedInfo, matchInfo);
    }

    public void Update() {
        if (Time.time > lastUpdateTime + updateTime) {
            RefreshMatchList();
        }
    }
}
