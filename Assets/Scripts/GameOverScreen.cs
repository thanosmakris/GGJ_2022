using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;

    private void OnEnable() {
        GameEvents.onPlayerDied += HandlePlayerDeath;
    }
    private void OnDisable() {
        GameEvents.onPlayerDied -= HandlePlayerDeath;
    }


    void HandlePlayerDeath()
    {
        gameOverPanel.SetActive(true);
        Invoke("EnableRestartButton", 0.75f);
    }

    void EnableRestartButton()
    {
        restartButton.interactable = true;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    
}
