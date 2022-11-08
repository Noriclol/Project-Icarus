using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Main.GameManager.PlayerSpawn = this.gameObject;
        Main.GameManager.PlayerInit();
        Main.GameManager.BindPlayer();
    }

}
