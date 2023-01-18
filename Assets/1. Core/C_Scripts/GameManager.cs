using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameObject Generators;
    public GameObject Managers;
    public GameObject Instances;

    public GameObject PlayerPrefab;
    public GameObject ShipPrefab;
    
    public GameObject CameraPrefab;

    public GameObject PlayerSpawn;

    public PlayerController playerController;

    public ShipController shipController;

    //Generators
    private CityGenerator generator_city;

    //Managers
    private CityManager manager_city;





    private void Start()
    {
        GameInit();
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


    public void PlayerInit()
    {
        var cameraInstance = Instantiate(CameraPrefab, Vector3.zero, quaternion.identity);

        var playerSpawnPos = PlayerSpawn.transform.position;
        var playerInstance = Instantiate(PlayerPrefab, playerSpawnPos, quaternion.identity);
        playerController = playerInstance.GetComponent<PlayerController>();
        playerController.camPos = cameraInstance.transform;
    }

    public void ShipInit()
    {
        
    }
    
    

    public void GameInit()
    {
        //GameGenInit();
    }

    public void LateUpdate()
    {

        //Update Managers
        //_manager_city.UpdateCities();
    }


    public void GameEnd()
    {

    }
}
