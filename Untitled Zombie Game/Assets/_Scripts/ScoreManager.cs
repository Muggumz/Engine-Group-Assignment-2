using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScoreManager : MonoBehaviour

{
    public static ScoreManager instance;
    public TMP_Text ChangingText;
    public int score = 0;

    public int EnemyCounter = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void ChangeScore(int killValue)
    {
        score += killValue;
        Debug.Log(score);
    }

    public void Update()
    {
        ChangingText.text = score.ToString();
    }

    public void AddEnemy()
    {
        EnemyCounter++;
    }

    public void DecreaseEnemy()
    {
        EnemyCounter--;
    }

    public int GetEnemyNumber()
    {
        return EnemyCounter;
    }
}
