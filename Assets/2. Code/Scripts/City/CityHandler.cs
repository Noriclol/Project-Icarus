using System.Collections.Generic;
using UnityEngine;


    public class CityHandler : MonoBehaviour
    {
        public string Name;
        public int Population = 0;
        public Stockpile Stockpile;
        public CityBuildings Buildings;
        

        public GameObject CityGFX;



        public void InitializeCity(){}

        public void UpdateCity()
        {
            Stockpile.UpdateStockpile(Buildings.GatheringBuildings, Buildings.ProcessingBuildings);

        }

        //public void UpdateMaterials(){}
        //private Resource<List> FindNearbyResources(){}


    }
