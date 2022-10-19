using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.ProjectVoyager.City
{
    public class CityGenerator : MonoBehaviour
    {
        public static int chunkSize = 100;
	
        public int Seed;

        public float MinHeight;
        public float MaxHeight;

        public  bool OnInspectorEditorBoolCheck = false;

        public static int Cities = 10;
        int nonPlacedCities = Cities;


        public ChunkData[,] DataGrid;
        public int[,] posCoords;

        public GameObject CityInstance;



        private List<CityHandler> cityHandlers;


        public void RunGenerator()
        {
            RefreshGenerator();

            GenerateInfoGrid();
            PlaceLocationPositions();
            GenerateLocations();
        }

        public void RefreshGenerator()
        {
            foreach (var script in cityHandlers)
            {
                Destroy(script.gameObject);
            }
        }

        public bool allBuildingsPlaced() {

            if (
                nonPlacedCities == 0
            )
            {
                return true;
            }
            return false;
        }

        public void SubTractNonPlacedCities()
        {
            nonPlacedCities--;
        }

        public void GenerateInfoGrid() {

            System.Random seed = new System.Random(Seed);

            posCoords = new int[chunkSize, chunkSize];
            DataGrid = new ChunkData[chunkSize, chunkSize];

            for (int y = 0; y < chunkSize; y++) {
                for (int x = 0; x < chunkSize; x++) {

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

                for (int y = 0; y < chunkSize; y++) {
                    for (int x = 0; x < chunkSize; x++) {

                        int roll = Random.Range(0, 100);

                        float percentage = Cities / chunkSize;

                        if (roll >= percentage && DataGrid[x, y].settled)
                        {
                            DataGrid[x, y].Populate();
                        }
                    }
                }
                SubTractNonPlacedCities();
            }
        }

        public void GenerateLocations()
        {
            GenerateCities();
        }

        public void GenerateCities()
        {
            for (int y = 0; y < chunkSize; y++)
            {
                for (int x = 0; x < chunkSize; x++)
                {
                    if (DataGrid[x, y].settled)
                    {
                        var instance = Instantiate(CityInstance, new Vector3(x, 0, y), Quaternion.identity);
                        var script = instance.GetComponent<CityHandler>();
                        cityHandlers.Add(script);

                        script.InitializeCity();
                        script.UpdateCity();
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
}