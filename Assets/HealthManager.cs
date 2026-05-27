using UnityEngine;
using UnityEngine.UI;
using TMPro; // Buat teks skor
using UnityEngine.SceneManagement; // Buat ngulang game

public class HealthManager : MonoBehaviour
{
    public Image[] hearts; 
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject gameOverPanel;
    public TMP_Text teksSkorAkhir;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartUI();
        gameOverPanel.SetActive(false); // Ngumpetin panel di awal
        Time.timeScale = 1f; // Pastikan waktu jalan
    }

    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHeartUI();

        if (currentHealth <= 0)
        {
            // MUNCULIN GAME OVER
            gameOverPanel.SetActive(true);
            teksSkorAkhir.text = "Skor Akhir : " + FishClick.score;
            Time.timeScale = 0f; // Berhentiin waktu game
        }
    }

    void UpdateHeartUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }

    // Dipanggil pas tombol Play Again dipencet
    public void RestartGame()
    {
        FishClick.score = 0; // Reset skor
        Time.timeScale = 1f; // Jalanin waktu lagi
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}