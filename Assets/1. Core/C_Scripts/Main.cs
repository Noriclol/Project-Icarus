using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


//main is the kernel of the core systems and it is responsible for instantiating the Core Arcitecture systems
public class Main : Singleton<Main>
{

    // MAIN CLASS
    

    //Core Components
    
    public InputManager InputManager;
    
    public LevelManager LevelManager;
    private new void Awake()
    {
        InputManager = GetComponent<InputManager>();
        LevelManager = GetComponent<LevelManager>();
    }




    
    //Load after load type
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void PostLoad_AfterSceneLoad()
    {
        //base.
        
        // collect Spawnpoints
        
        
        SpawnPoint[] spawnPointObjects = (SpawnPoint[])FindObjectsOfType(typeof(SpawnPoint));
        List<SpawnPoint> spawnPoints = spawnPointObjects.ToList();
        
        if (spawnPoints.Count <= 0)
        {
            Debug.Log("Spawnpoints not found");
            return;
        }
        foreach (var point in spawnPoints)
        {
            switch (point.type)
            {
                case SpawnType.None:
                    Debug.Log("Spawnpoint not specified");
                    break;
                case SpawnType.Player:
                    GameManager.Instance.PlayerSpawn = point.gameObject;
                    break;
                case SpawnType.PlayerShip:
                    GameManager.Instance.ShipSpawn = point.gameObject;
                    break;
            }
        }
        
        
        //var instance = GameManager.Instance;
        //var instance = Instantiate(Resources.Load("GameManager"));
        
        
        
    }
    
    // region  Initialization - END
}
