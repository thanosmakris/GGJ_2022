using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }


    public Transform happyPlayer;
    public Transform angryPlayer;


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

    }

    public Transform GetRandomPlayer
    {
        get 
        {
            int randomNumber = Random.Range(0, 2);
            return randomNumber == 0 ? happyPlayer : angryPlayer;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }



}