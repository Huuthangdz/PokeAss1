using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreUI : Singleton<ScoreUI>   
{
    [SerializeField] private TextMeshProUGUI textScore;
    public static int kill = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }
    public void ScorePlus()
    {
        kill += 1;
        textScore.text = kill.ToString();
    }
}
