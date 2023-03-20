using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    
    //      Fields
    
    //  General
    
    public GameObject Generators;
    public GameObject Managers;
    public GameObject Instances;


    public ControlMode mode = ControlMode.Player;
    
    
    //  Prefabs
    
    public GameObject PlayerPrefab;
    public GameObject ShipPrefab;
    
    public GameObject CameraPrefab;

    //  SpawnPoints
    
    public GameObject PlayerSpawn;
    public GameObject ShipSpawn;
    
    //  Instances
    public GameObject PlayerInstance;
    public GameObject ShipInstance;
    public GameObject CameraInstance;
    
    
    
    //  Controllers
    [HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public ShipController shipController;

    
    //  Generators
    private CityGenerator generator_city;

    //  Managers
    private CityManager manager_city;

    
    
    
    
    
    
    //      GameManager Constructor Destructor
    public void GameInit()
    {
        
        BindGeneral();
        
        //  GameGenInit();
        CameraInit();

        if (!PlayerSpawn && !ShipSpawn)
            Debug.Log("no Spawnpoint found");

        if (PlayerSpawn)
        {
            PlayerInit();
            Debug.Log("Player Spawned");

        }
        if (ShipSpawn)
        {
            ShipInit();
            Debug.Log("Ship Spawned");
        }
        
    }
    

    public void GameEnd()
    {
        UnbindGeneral();
    }
    
    
    #region Unity

    private void Start()
    {
        GameInit();
        InitialControllerBind();
    }
    
    
    public void LateUpdate()
    {

        //Update Managers
        //_manager_city.UpdateCities();
    }
    
    

    #endregion

    
    
    
    
    
    //      Binds/ Unbinds
    public void BindGeneral()
    {
        Debug.Log("General Bound");

        InputManager.SwitchController += SwitchControllers;
    }
    
    public void BindPlayer()
    {
        Debug.Log("Player Bound");
        InputManager.Move += playerController.OnMoveInput;
        InputManager.Jump += playerController.OnJump;
        InputManager.Interact += playerController.OnInteract;
        playerController.vCam.SetActive(true);
    }
    
    public void BindShip()
    {
        Debug.Log("Ship Bound");
            
        InputManager.TurnShip += shipController.RegisterTurn;
        InputManager.AccelerateShip += shipController.RegisterSpeed;
        shipController.vCam.SetActive(true);

    }




    public void UnbindGeneral()
    {
        Debug.Log("General Unbound");

        InputManager.SwitchController -= SwitchControllers;
    }

    public void UnbindPlayer()
    {
        Debug.Log("Player Unbound");

        InputManager.Move -= playerController.OnMoveInput;
        InputManager.Jump -= playerController.OnJump;
        InputManager.Interact -= playerController.OnInteract;
        playerController.vCam.SetActive(false);
    }

    
    public void UnbindShip()
    {
        Debug.Log("Ship Unbound");
        InputManager.TurnShip -= shipController.RegisterTurn;
        InputManager.AccelerateShip -= shipController.RegisterSpeed;
        shipController.vCam.SetActive(false);
    }





    public void TestFunc()
    {
        Debug.Log("Testing the I button");
    }



    private void InitialControllerBind()
    {
        switch (mode)
        {
            case ControlMode.Camera:
                break;
            
            case ControlMode.Player:
                BindPlayer();
                break;
            case ControlMode.Ship:
                BindShip();
                break;
        }
    }
    
    
    //      General Controls
    
    [ContextMenu("!")]
    public void SwitchControllers()
    {
        
        Debug.Log("SwitchController");
        
        string namething = ""; 
        switch (mode)
        {
            case ControlMode.Ship:
                
                UnbindShip();
                BindPlayer();

                namething = "Player";
                mode = ControlMode.Player;
                break;
            
            case ControlMode.Player:
                
                UnbindPlayer();
                BindShip();

                namething = "Ship";
                mode = ControlMode.Ship;
                break;
        }
        
        
        Debug.Log($"Switching to {namething}");

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //Fetch all Generators
    private void FetchGenerators()
    {
        generator_city = Generators.GetComponent<CityGenerator>();
    }

    //Fetch all Managers
    private void FetchManagers()
    {
        manager_city = Managers.GetComponent<CityManager>();
    }

    private void RunGenerators()
    {
        generator_city.RunGeneratorTemp();
    }

    private void GameGenInit()
    {

        //FetchAllReferences
        FetchGenerators();
        FetchManagers();

        //Run Generators
        RunGenerators();


        //Initialize Managers
        manager_city.InitializeCities();
    }


    public void CameraInit()
    {
        CameraInstance = Instantiate(CameraPrefab, Vector3.zero, quaternion.identity);
    }
    
    public void PlayerInit()
    {

        var playerSpawnPos = PlayerSpawn.transform.position;
        PlayerInstance = Instantiate(PlayerPrefab, playerSpawnPos, quaternion.identity);
        playerController = PlayerInstance.GetComponent<PlayerController>();

        if (CameraInstance)
            playerController.camPos = CameraInstance.transform;
        else
            Debug.Log("CameraInstance not Valid, Camera needs to spawn before player or ship");
    }

    public void ShipInit()
    {
        var shipSpawnPos = ShipSpawn.transform.position;
        ShipInstance = Instantiate(ShipPrefab, shipSpawnPos, quaternion.identity);
        shipController = ShipInstance.GetComponent<ShipController>();
        
        
    }
    
    


}
