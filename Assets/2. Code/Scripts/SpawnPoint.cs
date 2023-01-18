using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public SpawnType type;
    public enum SpawnType
    {
        None,
        Player,
        PlayerShip,
    }

}
