using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    //for x spawn location is either -15 or 15
    //y location is going to be randomized between -8 and 8

    public GameObject enemy;
    Vector2 spawnpoint;
    public float spawnrate = 2f;
    //float nextSpawn = 0f; //supposedly decides when to spawn new wave but haven't been implamented

    public bool spawnState = true; //Spawn state for debugging tool

    public Player player;

    public float x, y;

    /*
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }*/

    void Update()
    {
        Debug.Log(spawnState);
        if(spawnState)
        {
            y = player.transform.position.y + (Random.Range(-8, 8));
            x = player.transform.position.x + (Random.Range(0.0F, 1.0F) < 0.5F ? 15.0F : -15.0F);
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
            {
                //check the number of enemies on the screen according to the enemy number and timer of the game spawn more or stop for a while
                spawnpoint = new Vector2(x, y);
                Instantiate(enemy, spawnpoint, Quaternion.identity);
            }
        }
    }

    public void ChangeSpawnState()
    {
        spawnState = !spawnState;
    }

}
