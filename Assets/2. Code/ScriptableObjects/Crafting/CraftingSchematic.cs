using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Schematic", menuName = "Crafting/Schematic", order = 2)]
public class CraftingSchematic : ScriptableObject {
	public new string name;
	public List<Material> materials;
	public List<CraftingComponent> components;

}
