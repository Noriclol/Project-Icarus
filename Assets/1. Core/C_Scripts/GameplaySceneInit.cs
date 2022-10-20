using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameplaySceneInit : MonoBehaviour
{
    [SerializeField]
    private SceneInitType _type;
    void Start()
    {
        switch (_type)
        {
            case SceneInitType.Gameplay:
                Main.GameManager.GameInit();
                break;
        }
    }
    
    
    
    
}

public enum SceneInitType
{
    Gameplay
}
