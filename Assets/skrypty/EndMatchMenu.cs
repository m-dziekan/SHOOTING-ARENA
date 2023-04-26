using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

 public class EndMatchMenu : MonoBehaviour {

   

    public void Rematch()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
