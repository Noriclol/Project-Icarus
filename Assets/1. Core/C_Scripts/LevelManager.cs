using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Handles the loading of Scenes in The Game
public class LevelManager : MonoBehaviour
{

    public LevelList CurrentLevel = LevelList.Boot; 
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    
    
}


public enum LevelList
{
    Boot,
    Menu,
    Game,
}