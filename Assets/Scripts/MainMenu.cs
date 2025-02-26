using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
   public void ToEnter()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void ToQuit()
    {
        Application.Quit();
    }
}
