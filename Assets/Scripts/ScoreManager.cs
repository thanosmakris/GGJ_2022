using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score;

    private void OnEnable() {
        GameEvents.onEnemyKilled += IncreaseScore;
    }
    private void OnDisable() {
        GameEvents.onEnemyKilled -= IncreaseScore;
    }

    private void Start() {
        scoreText.text = score.ToString();
    }


    void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreText.transform.DOPunchScale(Vector3.one * 0.5f, 0.2f);
    }
   
}
