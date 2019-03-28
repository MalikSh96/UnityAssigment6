using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0; //using float here
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime; //<-- this is the reason why score is float, Time.deltaTime is float
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return; 
        scoreToNextLevel *= 2; //10,20,40,80,160 etc..
        difficultyLevel++;
        GetComponent<CharacterBehaviour>().SetSpeed(difficultyLevel);
    }
}
