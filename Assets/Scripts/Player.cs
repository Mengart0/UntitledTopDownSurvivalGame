using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Basic Stats")]
    [Tooltip("Default Move Speed of the Character")]
    public float moveSpeed = 5f;
    [Tooltip("Maximum health character could have")]
    public float maxhealth = 100f;
    [Tooltip("How much health the character has at the moment")]
    public float currenthealth = 100f;

    [Header("Assigned Objects")]
    public Rigidbody2D rb;
    public HealthBar healthBar;


    public EnemyScr closestEnemy = null;
    Vector2 movement;


    private void Start()
    {
        currenthealth = maxhealth;
    }

    void Update()
    {
        // ######## DEBUG PART ######## //

        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
        //Debug.Log(maxhealth);


        // ######## PLAYER MOVEMENT ######## //

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Physics.BoxCast(gameObject.transform.position, movement, Vector3.up);


        // ######## METHOD CALL ######## //

        ClosestEnemy();


        // ######## STATISTIC UPGRADES ######## //
        healthBar.SetMaxHealth(maxhealth);


    }

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;

        healthBar.SetHealth(currenthealth);

        if (currenthealth <= 0)
        {
            Die();
        }
    }
 
    void Die()
    {
        Destroy(gameObject);
    }

    public void ClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyScr[] allEnemies = GameObject.FindObjectsOfType<EnemyScr>();
        foreach (EnemyScr currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
    }


    private void FixedUpdate()
    {
        //Using inputed player movement to move the position of the player sprite
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}