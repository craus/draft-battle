using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

public class Battle
{
    public List<Unit> units = new List<Unit>();

    public Unit movingUnit;

    public void NextMove() {
        movingUnit = units.Where(u => u.Alive()).ToList().CyclicNext(movingUnit);
    }
}