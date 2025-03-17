using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject[] obstacleprefabs;
    private Vector3 spawnpos = new Vector3(25, 0, 0);
    private float startdelay = 2;
    private float repeatrate = 2;
    private PlayerController playerControllerScript;
    private int randomobstacle;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
        InvokeRepeating("Spawnobstacle", startdelay, repeatrate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawnobstacle() 
    {
        if (playerControllerScript.gameover == false)
        {
            randomobstacle = Random.Range(0, obstacleprefabs.Length);
            Instantiate(obstacleprefabs[randomobstacle], spawnpos, obstacleprefabs[randomobstacle].transform.rotation);
        }
        


    }

}

