using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
    public Unit unit;
    public Text damage;
    public Text hp;

    public void Init(Unit unit) {
        this.unit = unit;
        damage.text = unit.damage.ToString();
        hp.text = unit.hp.ToString();
    }
}