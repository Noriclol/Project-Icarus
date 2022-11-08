using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Cannon", menuName = "Weapons/Cannons")]
public class Cannon : ScriptableObject
{
    public string cannonName;
    public string cannonDescription;
    public float Powder;
    public float Weight;
    public float FuzeTime;

    public GameObject CannonPrefab;

    public List<GameObject> AllowedShots;
    

}