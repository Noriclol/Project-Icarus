using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Generators;
    public GameObject Managers;
    public GameObject Instances;

    public GameObject PlayerPrefab;
    public GameObject CameraPrefab;

    public GameObject PlayerSpawn;
    
    public PlayerController playerController;
    
    
    //Generators
    private CityGenerator _generator_city;

    //Managers
    private CityManager _manager_city;

    
    
    

    private void Start()
    {
        GameInit();
    }


    private void BindPlayer()
    {
        InputManager.Move += playerController.OnMoveInput;
        InputManager.Jump += playerController.OnJump;
        InputManager.Interact += playerController.OnInteract;
    }


    private void UnbindPlayer()
    {
        InputManager.Move -= playerController.OnMoveInput;
        InputManager.Jump -= playerController.OnJump;
        InputManager.Interact -= playerController.OnInteract;
    }

    //Fetch all Generators
    private void FetchGenerators()
    {
        _generator_city = Generators.GetComponent<CityGenerator>();
    }

    //Fetch all Managers
    private void FetchManagers()
    {
        _manager_city = Managers.GetComponent<CityManager>();
    }

    private void RunGenerators()
    {
        _generator_city.RunGeneratorTemp();
    }

    private void GameGenInit()
    {
                
        //FetchAllReferences
        FetchGenerators();
        FetchManagers();
        
        //Run Generators
        RunGenerators();
        
        
        //Initialize Managers
        _manager_city.InitializeCities();
    }


    private void PlayerInit()
    {
        var playerSpawnPos = Instances.transform.position;
        var PlayerInstance = Instantiate(PlayerPrefab, playerSpawnPos, quaternion.identity);
        playerController = PlayerInstance.GetComponent<PlayerController>();
    }
    
    public void GameInit()
    {
        GameGenInit();
        PlayerInit();
    }

    public void LateUpdate()
    {
        
        //Update Managers
        _manager_city.UpdateCities();
    }


    public void GameEnd()
    {
        
    }
}
