using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _2._Code.Enums.Crafting;

[CreateAssetMenu(fileName = "New Resource", menuName = "ScriptableObjects/Resources/Resource", order = 1)]
public class CraftingResource : ScriptableObject
{
    [SerializeField]
    private CraftingResourceType type;
    
    public List<CraftingMaterial> material;
}







