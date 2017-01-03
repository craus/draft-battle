using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{

    string message = null;
    public bool isAtStartup = true;

    NetworkClient myClient;
    NetworkConnection connection;

    void Update() {
        if (isAtStartup) {
            if (Input.GetKeyDown(KeyCode.S)) {
                SetupServer();
            }
            //match

            if (Input.GetKeyDown(KeyCode.C)) {
                SetupClient();
            }

            if (Input.GetKeyDown(KeyCode.B)) {
                SetupServer();
                SetupLocalClient();
            }

            if (Input.GetKeyDown(KeyCode.M)) {
                SendMessage();
            }
        }
    }

    private void SendMessage() {
        connection.Send(MsgType.Command, new TextMessage());
    }

    void OnGUI() {
        if (isAtStartup) {
            GUI.Label(new Rect(2, 10, 150, 100), "Press S for server");
            GUI.Label(new Rect(2, 30, 150, 100), "Press B for both");
            GUI.Label(new Rect(2, 50, 150, 100), "Press C for client");
        }
        if (message != null) {
            GUI.Label(new Rect(2, 70, 150, 100), message);
        }
    }

    // Create a server and listen on a port
    public void SetupServer() {
        NetworkServer.Listen(4444);
        NetworkServer.RegisterHandler(MsgType.Command, OnServerCommand);
        isAtStartup = false;
    }

    // Create a client and connect to the server port
    public void SetupClient() {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("127.0.0.1", 4444);
        isAtStartup = false;
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient() {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(MsgType.Command, OnClientCommand);
        isAtStartup = false;
    }

    // client function
    public void OnConnected(NetworkMessage netMsg) {
        message = netMsg.msgType.ToString();
        connection = netMsg.conn;
    }

    public void OnClientCommand(NetworkMessage netMsg) {
        message = string.Format("Received client command message of type: {0}", netMsg.msgType.ToString());
    }

    public void OnServerCommand(NetworkMessage netMsg) {
        message = string.Format("Received server command message of type: {0}", netMsg.msgType.ToString());
    }
}