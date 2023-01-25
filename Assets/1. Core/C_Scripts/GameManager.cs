using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    // General
    
    public GameObject Generators;
    public GameObject Managers;
    public GameObject Instances;

    
    // Prefabs
    
    public GameObject PlayerPrefab;
    public GameObject ShipPrefab;
    
    public GameObject CameraPrefab;

    //SpawnPoints
    
    public GameObject PlayerSpawn;
    public GameObject ShipSpawn;
    
    //Instances
    public GameObject PlayerInstance;
    public GameObject ShipInstance;

    public GameObject CameraInstance;
    
    // Controllers
    public PlayerController playerController;
    public ShipController shipController;

    //Generators
    private CityGenerator generator_city;

    //Managers
    private CityManager manager_city;

    #region Unity

    private void Start()
    {
        GameInit();
    }
    
    
    public void LateUpdate()
    {

        //Update Managers
        //_manager_city.UpdateCities();
    }
    
    

    #endregion

    public void BindGeneral()
    {
        InputManager.SwitchController += 

    }
    
    public void BindPlayer()
    {
        InputManager.Move += playerController.OnMoveInput;
        InputManager.Jump += playerController.OnJump;
        InputManager.Interact += playerController.OnInteract;
    }


    public void UnbindPlayer()
    {
        InputManager.Move -= playerController.OnMoveInput;
        InputManager.Jump -= playerController.OnJump;
        InputManager.Interact -= playerController.OnInteract;
    }

    
    public void BindShip()
    {
         InputManager.TurnShip += shipController.RegisterTurn;

    }


    public void UnbindShip()
    {
        InputManager.TurnShip -= shipController.RegisterTurn;

    }





    public void SwitchControllers()
    {
        
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
    
    

    public void GameInit()
    {
        //GameGenInit();
        CameraInit();

        if (!PlayerSpawn && !ShipSpawn)
            Debug.Log("no Spawnpoint found");

        if (PlayerSpawn)
            PlayerInit();
        
        if (ShipSpawn)
            ShipInit();
    }




    public void GameEnd()
    {

    }
}
