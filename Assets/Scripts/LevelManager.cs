using UnityEngine;
using UnityEngine.SceneManagement;
    
public class LevelManager : MonoBehaviour
{
    

    public int targetKillCount = 20;
    public GameObject winnerPanel;
    public GameObject karakterCanGostergesi;
    public GameObject pauseButon;
    public GameObject karakterHareketCanvas;

    private void Start()
    {
        winnerPanel.SetActive(false);

    }
    private void Update()
    {
        if (ZombiSald�r�.destroyedEnemyCount >= targetKillCount)
        {
            ShowWinnerPanel();
            Time.timeScale = 0f;
            Debug.Log("Winner");
        }
        else
        {
            Time.timeScale = 1f;
            
        }
            
    }

    private void ShowWinnerPanel()
    {
        winnerPanel.SetActive(true);
        karakterCanGostergesi.SetActive(false);
        karakterHareketCanvas.SetActive(false);
        pauseButon.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0); // Ana men� sahnesinin y�klenmesi i�in sahne indeksi 0 kullan�l�yor
    }

    public void GoToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextSceneIndex);
            ZombiSald�r�.destroyedEnemyCount = 0;

        }
        else
        {
            Debug.Log("There is no next level!"); // Son seviyedeyiz, bir sonraki seviye yok
        }
    }


   
}
