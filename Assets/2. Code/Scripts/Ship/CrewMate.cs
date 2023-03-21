using System;
using System.Collections.Generic;
using _2._Code.Enums.Ship;
using UnityEngine;

namespace Assets.ProjectVoyager.Ship
{
    public abstract class CrewMate
    {
        public string CrewmateName;
        public static System.Random _R = new System.Random();
        public List<ShipJob> jobs = new List<ShipJob>();

        private void Init(ShipJob job)
        {
            jobs.Add(job);
        }

        private CrewMate(ShipJob job)
        {

        }

        public virtual void GiveOrder() { }

        public virtual void TakeOrder()
        {
            
        }
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }

        public string GenerateName()
        {
            string firstName = RandomEnumValue<Crewmate.FirstName>().ToString();
            string lastName = RandomEnumValue<Crewmate.LastName>().ToString();

            return $"{firstName} {lastName}";
        }
    }
}
