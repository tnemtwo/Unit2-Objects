using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;


    private void Start()
    {
        FindObjectOfType<ScoreManager>().OnScoreChanged.AddListener(UpdateScoreValue);
    }
    public void UpdateScoreValue(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHealthValue(float health)
    {
        healthText.text = health.ToString();
    }
}
