using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


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
        
        
        // collect Spawnpoints
        
        
        var spawnpoint = FindObjectOfType<SpawnPoint>();

        if (!spawnpoint)
        {
            Debug.Log("Spawnpoint not found");
            return;
        }
        //var instance = GameManager.Instance;
        var instance = Instantiate(Resources.Load("GameManager")) as GameObject;
        GameManager.Instance.PlayerSpawn = spawnpoint.gameObject;
        GameManager.Instance.PlayerInit();
        GameManager.Instance.BindShip();
        //GameManager.Instance.BindPlayer();
    }
    
    // region  Initialization - END
}
