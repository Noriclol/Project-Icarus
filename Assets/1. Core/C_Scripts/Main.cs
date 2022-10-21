using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//main is the kernel of the core systems and it is responsible for instantiating the Core Arcitecture systems
public class Main : MonoBehaviour
{

    // MAIN CLASS
    
    
    
    
    // region  Components - BEGIN

    private static Main instance;

    //private ProgramState _state;

    //Core Components
    
    public static InputManager InputManager;
    
    public static LevelManager LevelManager;
    
    //GameManager
    
    public GameManager GameManager;
    // region  Components - END
    
    
    
    // region  Initialization - BEGIN
    private void Awake()
    {
        InstanceCheck();

        InputManager = GetComponent<InputManager>();
        LevelManager = GetComponent<LevelManager>();
        

        //field Initialization

    }


    private void InstanceCheck()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);

        else
            instance = this;
    }
    // region  Initialization - END


    
    public static void Instantiate_Main()
    {
        GameObject main = GameObject.Instantiate(Resources.Load("Main")) as GameObject;
        GameObject.DontDestroyOnLoad(main);
        Debug.Log("Main Loaded");
    }


    public static void Instantiate_GameManager()
    {
        GameObject gameManager = GameObject.Instantiate(Resources.Load("GameManager")) as GameObject;
        GameObject.DontDestroyOnLoad(gameManager);
        Debug.Log("GameManager Loaded");

        instance.GameManager = gameManager.GetComponent<GameManager>();

    }
    
    
    
    
    
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

    
    //Load before load type
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Load_BeforeSceneLoad()
    {
        Instantiate_Main();
    }
    
    //Load after load type
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void PostLoad_AfterSceneLoad()
    {
        Instantiate_GameManager();
    }
    
    // region  Initialization - END
}
