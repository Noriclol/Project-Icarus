using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Component", menuName = "Crafting/Component", order = 0)]
public class CraftingComponent : ScriptableObject
{
	public new string name;
	public List<Material> materials;
	public List<CraftingComponent> components;
}
