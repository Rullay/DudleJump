using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   
    public void GameStart()
    {
    SceneManager.LoadScene("SampleScene");
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
