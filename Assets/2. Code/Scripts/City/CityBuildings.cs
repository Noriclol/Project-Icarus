using System.Collections.Generic;


public class CityBuildings
{
    public List<Building> AllBuildings;
    public List<Building> GatheringBuildings;
    public List<Building> ProcessingBuildings;

    public void CreateBuilding(Building building)
    {
        AllBuildings.Add(building);
        if (building.type == BuildingType.Gatherer )
            GatheringBuildings.Add(building);
        
        if (building.type == BuildingType.Processor) 
            ProcessingBuildings.Add(building);
    }
    public void DestroyBuilding(Building building){}

}

