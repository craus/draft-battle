using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Console : MonoBehaviour
{
    public static Console instance;
    Text text;

    public void Awake() {
        instance = this;
        text = GetComponent<Text>();
    }

    public void Log(string message) {
        Debug.LogFormat(message);
        text.text += message + "\n";
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Log("T");
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            Console.instance.Log("A" + Network.isServer + Network.isClient);
        }
    }
}