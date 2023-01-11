using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


//main is the kernel of the core systems and it is responsible for instantiating the Core Arcitecture systems
public class Main : Singleton<Main>
{

    // MAIN CLASS
    
    
    
    
    // region  Components - BEGIN

    //private ProgramState _state;

    //Core Components
    
    public InputManager InputManager;
    
    public LevelManager LevelManager;
    
    //GameManager
    
    // region  Components - END
    
    
    
    // region  Initialization - BEGIN
    private new void Awake()
    {
        InputManager = GetComponent<InputManager>();
        LevelManager = GetComponent<LevelManager>();
        
        //field Initialization

    }

    // region  Initialization - END


    // region  Initialization - BEGIN
    
    //Initialize Functions
    //used for initialization of the game.
    
    // //Load before flash screen
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    // private void PreLoad_BeforeSplashScreen()
    // {
    //     switch (_state)
    //     {
    //         //Can be used to control which state of the game to run.
    //         //For now only have defaultstart state until proper implementation.
    //         
    //         case ProgramState.DefaultStart:
    //             
    //             break;
    //         
    //
    //     }
    // }

    
    //Load after load type
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void PostLoad_AfterSceneLoad()
    {
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
        GameManager.Instance.BindPlayer();
    }
    
    // region  Initialization - END
}
