using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "ScriptableObjects/Resources/Resource", order = 1)]
public class Resource : ScriptableObject
{
    public new string name;
    public E_ResouceType type;
}

public enum E_ResouceType
{
    Ore,
    Wood,
}