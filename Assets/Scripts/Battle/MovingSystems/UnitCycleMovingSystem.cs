using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class UnitCycleMovingSystem : PerUnitMovingSystem
{
    public List<PerUnitMovingState> order = new List<PerUnitMovingState>();
}