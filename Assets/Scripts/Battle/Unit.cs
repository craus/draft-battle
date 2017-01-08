using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Unit
{
    public Controller controller;
    public int maxHp;
    public int hp;
    public int damage;

    public Unit(int damage, int hp) {
        this.damage = damage;
        this.hp = this.maxHp = hp;
    }

    public Unit Of(Controller controller) {
        this.controller = controller;
        return this;
    }

    public void ReceiveDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            Die();
        }
    }

    public void Die() {
    }

    public bool Alive() {
        return hp > 0;
    }

    public void SkipMove(Battle battle) {
        battle.NextMove();
    }

    public void Attack(Battle battle, Unit unit) {
        unit.ReceiveDamage(damage);
        battle.NextMove();
    }
}