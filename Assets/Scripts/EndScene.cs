using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScene : MonoBehaviour
{
    GameObject[] enemies;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0)
        {
            Time.timeScale = .3f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.7f);
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
