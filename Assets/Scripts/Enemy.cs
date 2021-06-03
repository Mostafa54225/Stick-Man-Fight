using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public GameObject player;
    public float shootingRange;
    public GameObject Bullet;
    public GameObject bulletParent;
    public float fireRate = 1;
    public float nextFireTime;
    //private Rigidbody2D rb;


    public float health = 10.0f;
    [SerializeField] private healthBarEnemy healthBarEnemy;
    //GameObject barrel;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("playerPos");
    }


    // Update is called once per frame
    void Update()
    {
        float distanceFromPLayer = Vector2.Distance(player.transform.position, transform.position);
        if(distanceFromPLayer < lineOfSite && distanceFromPLayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        } else if(distanceFromPLayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(Bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        if (health <= 0)
        {
            Debug.Log("Enemy Died :)");
            killSelf();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            health--;
            takeDamage(1);
        }
        else if (collision.CompareTag("FallDetector"))
            killSelf();

    }

    public void takeDamage(float damage)
    {
        health = health - damage;
        healthBarEnemy.setSize(health / 10.0f);
    }

    void killSelf()
    {
        Destroy(gameObject);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
