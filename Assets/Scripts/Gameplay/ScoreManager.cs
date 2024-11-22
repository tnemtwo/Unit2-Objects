using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScoreManager : MonoBehaviour
{

    public UnityEvent<int> OnScoreChanged;
    public UnityEvent<int> OnHighestScoreChange;
    [SerializeField] private int totalScore;
    [SerializeField] private int highestScore;

    [Header("Score Values")]
    [SerializeField] private int scorePerEnemy;
    [SerializeField] private int scorePerCoin;
    [SerializeField] private int scorePerPowerUp;

    [SerializeField] private List<ScoreData> allScores = new List<ScoreData>();

    [SerializeField] private ScoreData latestScore;
    private void Start()
    {
        Player playerObject = FindObjectOfType<Player>();
        playerObject.healthValue.OnDied.AddListener(RegisterScore);

        highestScore = PlayerPrefs.GetInt("HighScore");

        //At the start of the game
        //I'll retrieve the string from player prefs
        string latestScoreInJson = PlayerPrefs.GetString("LatestScore");

        //and try to convert it back into a ScoreData object/class
        latestScore = JsonUtility.FromJson<ScoreData>(latestScoreInJson);

    }

    private void RegisterScore() //when players dies
    {
        //Create an object filled with information
        latestScore = new ScoreData("RAF", totalScore);
        
        //Convert the object (class) into a string in json format
        string latestScoreInJson = JsonUtility.ToJson(latestScore);

        //save that string into PlayerPrefs
        PlayerPrefs.SetString("LatestScore", latestScoreInJson);

        
        if(totalScore > highestScore)
        {
            //WE GOT A NEW HIGH SCORE
            highestScore = totalScore;
            PlayerPrefs.SetInt("HighScore", highestScore);

            //PlayerPrefs.SetInt("My Name", "Rafael");
        }
        
    }
    // {"userName":"RAF","highestScore":30}

    public void IncreaseScore(ScoreType action)
    {
        switch (action)
        {
            case ScoreType.EnemyKilled:
                totalScore += scorePerEnemy;
                break;

            case ScoreType.CoinCollected:
                totalScore += scorePerCoin;
                break;

            case ScoreType.PowerUpCollected:
                totalScore += scorePerPowerUp;
                break;
        }

        OnScoreChanged.Invoke(totalScore);
    }


    public void EnemyKilled()
    {
        //IncreaseScore(scorePerEnemy);
    }

    public void CoinCollected()
    {
        //IncreaseScore(scorePerCoin);
    }
}
