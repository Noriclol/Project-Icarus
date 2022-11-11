using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ProjectVoyager.Ship
{
    public class ShipHandler : MonoBehaviour
    {
        public List<GameObject> HullParts;
        public List<GameObject> Masts;

        public List<GameObject> Containers;
        public List<GameObject> Armaments;

        public Resource HullResource;

        public Resource FloorResource;
        


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
        public string Name;

        static System.Random _R = new System.Random();
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }




        public string GenerateName()
        {
            string firstName = RandomEnumValue<FirstName>().ToString();
            string lastName = RandomEnumValue<LastName>().ToString();

            return $"{firstName} {lastName}";
        }





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