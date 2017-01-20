using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using System.Collections;

public class GameManager : NetworkBehaviour
{
    public const int maxHealth = 100;
    public bool destroyOnDeath;

    void Update() {

        if (Input.GetKeyDown(KeyCode.R)) {
            RpcMessage(42);
        }
    }

    private IEnumerator Start() {
        Console.instance.Log(string.Format("isServer = {0}", isServer));
        if (!isServer) {
            yield break;
        }
        while (true) {
            yield return new WaitForSecondsRealtime(5);
            RpcMessage(UnityEngine.Random.Range(0,100000));
        }
    }

    [ClientRpc]
    void RpcMessage(int x) {
        Console.instance.Log("M" + isServer + x);
    }
}