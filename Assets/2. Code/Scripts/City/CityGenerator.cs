using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class CityGenerator : MonoBehaviour
{

    [Header("CityPrefab")]
    public GameObject CityInstance;

    [Header("ManagerRef")] 
    private CityManager manager;
    
    [Header("Fields")][Space]
    [Header("Spawning")]
    
    [SerializeField]
    private int spawnAreaSize = 100;

    [SerializeField]
    private int seed;

    [SerializeField]
    private int amount = 10;
    
    private int spawnCount;


    public ChunkData[,] DataGrid;
    public int[,] posCoords;

    


    private void Start()
    {
        spawnCount = amount;
    }


    public void RunGeneratorTemp()
    {
        //temp Generator that generates a single city
        manager.Handlers = new List<CityHandler>();

        var newCity = Instantiate(CityInstance, Vector3.zero, quaternion.identity);
        
        manager.Handlers.Add(newCity.GetComponent<CityHandler>());
    }
    


    public void RefreshGenerator()
    {
        //if cityhandler invalid then no refresh nessesary
        if (manager.Handlers == null)
        {
            print("No Previous CityHandlers");
            return;
        }
            
        print("Previous CityHandlers Found. Purging");
        //Destroy all Cityhandlers and their respective Prefabs
        foreach (var script in manager.Handlers)
        {
            
            Destroy(script.gameObject);
        }
    }

    public bool allBuildingsPlaced() {

        if (spawnCount == 0)
            return true;
        
        return false;
    }

    public void SubTractPlacedCities()
        => spawnCount--;
    

    public void GenerateInfoGrid() {

        

        posCoords = new int[spawnAreaSize, spawnAreaSize];
        DataGrid = new ChunkData[spawnAreaSize, spawnAreaSize];

        for (int y = 0; y < spawnAreaSize; y++) {
            for (int x = 0; x < spawnAreaSize; x++) {

                ChunkData chunkData = new ChunkData();
                chunkData.Populate();

                DataGrid[x, y] = chunkData;
            }
        }
    }

    public void PlaceLocationPositions()
    {
        while (allBuildingsPlaced()) {

            allBuildingsPlaced();

            for (int y = 0; y < spawnAreaSize; y++) {
                for (int x = 0; x < spawnAreaSize; x++) {

                    int roll = Random.Range(0, 100);

                    float percentage = amount / spawnAreaSize;

                    if (roll >= percentage && DataGrid[x, y].settled)
                    {
                        DataGrid[x, y].Populate();
                    }
                }
            }
            SubTractPlacedCities();
        }
    }

    public void GenerateLocations()
    {
        GenerateCities();
    }

    public void GenerateCities()
    {
        for (int y = 0; y < spawnAreaSize; y++)
        {
            for (int x = 0; x < spawnAreaSize; x++)
            {
                if (DataGrid[x, y].settled)
                {
                    var instance = Instantiate(CityInstance, new Vector3(x, 0, y), Quaternion.identity);
                    manager.Handlers.Add(instance.GetComponent<CityHandler>());
                }
            }
        }
    }


    

}






public class ChunkData
{
    //public E_Biome biome;
    public bool settled;
    
    public void Populate()
    {
        settled = true;
    }
}

public class CityInstance
{
    public CityHandler Handler;
    public Vector3 Position;

}
