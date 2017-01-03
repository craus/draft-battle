using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour {
    public NetworkManager networkManager;

    public void Start() {
        networkManager.StartMatchMaker();
    }
}
