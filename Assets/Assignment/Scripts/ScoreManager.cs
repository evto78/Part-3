using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public static ScoreManager self;
    public static int score = 0;

    private void Start()
    {
        self = this;
    }

    public static void UpdateScore(int increase)
    {
        score += increase;
        self.scoreText.text = score.ToString();
    }
}
