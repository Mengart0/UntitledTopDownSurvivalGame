using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPs : MonoBehaviour
{
    [Header("Player Powerups")]
    public float MaximumHealth = 0;
    //public float ExtraShooting = 0;
    public GameObject player;
    public Player playerScript;

    public Collider2D Collider;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D collision)  //Currently collision is happening between the player and the enemies instead of pickups
    {
        if (collision.tag == "Player")
        {
            if (this.gameObject.name == "Max Health Pickup")
            {
                playerScript.maxhealth += 15;
                //don't forget to update health bar as well
            }

            else { Debug.Log("Detection of `PickupName` Failed"); }
        }
    }

    public void Update()
    {
        Debug.Log(playerScript.maxhealth);
    }


}
