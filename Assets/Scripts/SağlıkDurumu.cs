using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SağlıkDurumu : MonoBehaviour
{
    public int startingHealth = 100;        // Başlangıç sağlığı
    private int currentHealth;               // Mevcut sağlık
    public Slider healthBar;                // Sağlık çubuğu
    private bool isDead;                    // Karakterin ölüp ölmediğini tutar
    public GameObject gameOverPanel;        // Game Over paneli referansı
    public GameObject karakterCanGostergesi;
    public GameObject pauseButon;
    public GameObject karakterHareketCanvas;

    private void Start()
    {
        isDead = false;
        currentHealth = startingHealth;
        healthBar.maxValue = startingHealth; // Sağlık çubuğu için maksimum değeri ayarla
        healthBar.value = startingHealth; // Sağlık çubuğunu başlangıç sağlığına ayarla
        gameOverPanel.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth); // Sağlık değerini sınırlandır

        float healthPercentage = (float)currentHealth / (float)startingHealth;
        healthBar.value = currentHealth; // Sağlık çubuğunu güncelle
        healthBar.transform.localScale = new Vector3(healthPercentage, 1, 1); // Sağlık çubuğunun ölçeklendirilmiş genişliğini güncelle

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        showGameoverPanel();
    }

    private void showGameoverPanel()
    {
        gameOverPanel.SetActive(true);
        karakterCanGostergesi.SetActive(false);
        karakterHareketCanvas.SetActive(false);
        pauseButon.SetActive(false);
        Time.timeScale = 0f;
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0); // Panel sıralamasındaki 0. yi getirir yani mainmenü panelini.
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}