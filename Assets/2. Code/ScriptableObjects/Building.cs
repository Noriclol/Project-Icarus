using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "City/Building", order = 1)]
public class Building : ScriptableObject
{
    public E_BuildingType type;

    public virtual void Upgrade()
    {
        throw new System.NotImplementedException();
    }
    
}

public enum E_BuildingType
{
    None,
    Gatherer,
    Processor,
    Distributor
}

public interface IBuilding
{
    void Upgrade();
    void Update();
}
