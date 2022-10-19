using UnityEngine;

namespace Assets.ProjectVoyager.City
{
    public class CityHandler : MonoBehaviour
    {
        #region Vars
        public string Name;
        public int Population = 0;
        public Stockpile Stockpile;
        public CityBuildings Buildings;

        //Building<List> buildings;
        #endregion

        #region Refs

        public GameObject CityGFX;


        #endregion


        public void InitializeCity(){}

        public void UpdateCity()
        {
            Stockpile.UpdateStockpile(Buildings.GatheringBuildings, Buildings.ProcessingBuildings);

        }

        //public void UpdateMaterials(){}
        //private Resource<List> FindNearbyResources(){}


    }
}
