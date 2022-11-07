using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    public List<CityHandler> Handlers = new List<CityHandler>();
    
    public void InitializeCities()
    {
        foreach (var handler in Handlers)
        {
            handler.InitializeCity();
        }
    }

    public void UpdateCities()
    {
        if (Handlers == null)
            return;
            
        
        foreach (var handler in Handlers)
        {
            handler.UpdateCity();
        }
    }
    
}
