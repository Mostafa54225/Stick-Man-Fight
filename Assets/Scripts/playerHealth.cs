using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public float health = 10;
    [SerializeField] private HealthBar healthBar;
   
    void Update()
    {
        
        if (health <= 0)
        {
            Debug.Log("You Died :)");
            Time.timeScale = .3f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            StartCoroutine(wait());
            health = 10;
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        healthBar.setSize(health / 10.0f);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

}
