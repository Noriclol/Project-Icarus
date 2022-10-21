using System.Collections.Generic;


public class CityBuildings
{
    public List<Building> AllBuildings;
    public List<Building> GatheringBuildings;
    public List<Building> ProcessingBuildings;

    void CreateBuilding(Building building)
    {
        AllBuildings.Add(building);
        if (building.type == E_BuildingType.Gatherer ) GatheringBuildings.Add(building);
        if (building.type == E_BuildingType.Processor) ProcessingBuildings.Add(building);
    }
    void DestroyBuilding(Building building){}

}

