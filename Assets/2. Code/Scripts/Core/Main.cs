using System;
using UnityEngine;



public class Main : MonoBehaviour
{

    // MAIN CLASS
    
    
    
    
    
    
    
    // region  Components - BEGIN

    private static Main instance;

    private ProgramState _state;

    
    public static InputManager _inputManager;
    public static GameManager _gameManager;
    // region  Components - END
    
    
    
    // region  Initialization - BEGIN
    private void Awake()
    {
        InstanceCheck();

        _inputManager = GetComponent<InputManager>();
        
        
        //field Initialization
        _state = ProgramState.DefaultStart;
        
    }


    private void InstanceCheck()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);

        else
            instance = this;
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

    
    //Load before load type
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private void Load_BeforeSceneLoad()
    {
        switch (_state)
        {
            //Can be used to control which state of the game to run.
            //For now only have defaultstart state until proper implementation.
            
            case ProgramState.DefaultStart:
                
                break;
            

        }
    }
    
    //Load after load type
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void PostLoad_AfterSceneLoad()
    {
        switch (_state)
        {
            //Can be used to control which state of the game to run.
            //For now only have defaultstart state until proper implementation.
            
            case ProgramState.DefaultStart:
                
                break;
            

        }
    }
    
    // region  Initialization - END

    
    
    
    
    
    // region  Enums - BEGIN
    
    
    enum  ProgramState
    {
        Boot,
        
        DefaultStart,
        Menu,
        Game,
    }
    
    
    // region  Enums - END
}
