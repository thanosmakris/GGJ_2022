using UnityEngine;

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

    public Transform GetRandomPlayer
    {
        get 
        {
            int randomNumber = Random.Range(0, 2);
            return randomNumber == 0 ? happyPlayer : angryPlayer;
        }
    }



}