using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Balance : MonoBehaviour
{
    public float targetRotation;
    public Rigidbody2D rb;
    public float force;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.fixedDeltaTime));    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("FallDetector"))
        {
            Time.timeScale = .3f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
