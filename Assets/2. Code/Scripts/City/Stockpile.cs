using System.Collections.Generic;
using System.Linq;

namespace Assets.ProjectVoyager.City
{
    public class Stockpile
    {
        public Dictionary<Resource, int> Stock { get; private set; }
        public List<Resource> Exports;
        public List<Resource> Imports;

        private Dictionary<Resource, int> _rawIncome;

        public void UpdateStockpile(List<Building> gathererBuildings, List<Building> processingBuildings)
        {
            // Add raw resources to stock
            // Process resources
        }

        public void AddToStock(Dictionary<Resource, int> resources)
        {
            for (int i = 0; i < resources.Count; i++)
            {
                var key = resources.ElementAt(i).Key;
                var val = resources.ElementAt(i).Value;
                if (Stock.ContainsKey(key))
                {
                    Stock[key] += val;
                }
                else
                {
                    Stock.Add(key, val);
                }

                // TODO: Update Trade UI
            }
        }
    }
}

