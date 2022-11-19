using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    public float health = 100f;
    public float movSpeed = 2f;
    public float collisiondamage = 10f;
    public GeneralManager GManager;

    private Transform target;
    public Player player;



    public void TakeDamage (float damage)
    { 
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GManager.IncKillCount();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GeneralManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(collisiondamage);
        }
    }

}
