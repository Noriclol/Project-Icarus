using System;
using System.Collections;
using System.Collections.Generic;
using Assets.ProjectVoyager.City;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject Generators;
    public GameObject Managers;
    public GameObject Instances;

    //Generators
    private CityGenerator _generator_city;

    //Managers
    private CityManager _manager_city;


    private void Start()
    {
        GameInit();
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
        _generator_city.RunGenerator();
    }
    
    
    
    public void GameInit()
    {
        
        //FetchAllReferences
        FetchGenerators();
        FetchManagers();
        
        //Generate
        
        
        //Instantiate Content (Player And Camera)
        
        //bind player controls
    }

    public void GameEnd()
    {
        //unbind player controls
        
        //Destroy Instantiated Content
    }
}
