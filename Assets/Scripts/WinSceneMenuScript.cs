using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinSceneMenuScript : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene(1);
    }
}
