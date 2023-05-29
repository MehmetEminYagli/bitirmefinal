using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenü : MonoBehaviour
{
    public GameObject winnerpanel;
    public GameObject Gameoverpanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        winnerpanel.SetActive(false);
        Gameoverpanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
}
