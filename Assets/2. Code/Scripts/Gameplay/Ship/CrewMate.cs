using System.Collections.Generic;
using UnityEngine;

namespace Assets.ProjectVoyager.Ship
{
    public class CrewMate : MonoBehaviour
    {
        public List<Job> jobs = new List<Job>();

        void GiveOrder() { }
        CrewMate()
        {
            jobs.Add(Job.Crewmate);

        }
    }
}
