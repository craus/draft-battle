using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Attack : Ability
{
    public int damage;

    public void Use(Unit target) {
        target.ReceiveDamage(damage);
    }
}