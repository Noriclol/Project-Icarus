using System.Collections.Generic;
using UnityEngine;


public class CityHandler : MonoBehaviour
{

    [Header("CityFields")]
    
    [SerializeField]
    private string cityName;

    [SerializeField]
    private int population = 0;
    
    [SerializeField]
    private int StarterBuildings = 5;
    
    [SerializeField]
    private Stockpile Stockpile;
    
    [SerializeField]
    private CityBuildings Buildings;

    private List<CraftingResource> nearbyResources;




    [Header("buildingRefs")]
    //building Refs
    [SerializeField]
    private Building house;
    
    [SerializeField]
    private Building townHall;
    
    [SerializeField]
    private Building market;
    
    [SerializeField]
    private Building woodCutter;

    [SerializeField]
    private Building mine;
    

    //Properties
    
    public string CityName { get => cityName; }
    public int Population { get => population; } 
    
    
    
    
    
    public void InitializeCity()
    {
        Buildings.CreateBuilding(townHall);
        for (int i = 0; i < StarterBuildings; i++)
        {
            Buildings.CreateBuilding(house);
        }
        Buildings.CreateBuilding(market);
        Buildings.CreateBuilding(woodCutter);
        Buildings.CreateBuilding(mine);
    }

    public void UpdateCity()
    {
        Stockpile.UpdateStockpile(Buildings.GatheringBuildings, Buildings.ProcessingBuildings);

    }

    //public void UpdateMaterials(){}
    //private Resource<List> FindNearbyResources(){}


}

