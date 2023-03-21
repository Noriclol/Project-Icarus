using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.ProjectVoyager.Ship
{
    public class ShipHandler : MonoBehaviour
    {
        // Ship Parts
        public List<GameObject> HullParts;
        public List<GameObject> Masts;
        public List<GameObject> Containers;
        public List<GameObject> Armaments;
        
        
        [FormerlySerializedAs("HullResource")] public CraftingResource hullCraftingResource;

        [FormerlySerializedAs("FloorResource")] public CraftingResource floorCraftingResource;
        
        private List<ShipTask> tasks;

        public class CannonDeck
        {
            public List<Transform> CannonTransforms;
        }
    }


//Tasks are
    public class ShipTask 
    {

    }


    public class Crewmate
    {
        

        public enum FirstName
        {
            Rick,
            Steve,
            Dan,
            Leon,
            John
        }

        public enum LastName
        {
            Jobs,
            Adams,
            BingHam,
            Bishop,
            Brown,
            Conway,
        }

    }
}