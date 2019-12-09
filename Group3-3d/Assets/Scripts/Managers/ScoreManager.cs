using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static int modifier = 1;
    public static int enemiesLeft = 5;
    public Text scoreText;
    public Text levelText;
    public Text remainingText;



    static float timer;
    static string title = "Score: ";
    static int level = 1;
    int bonusTime = 10;
    int enemiesLevelUp = 5;

    void Awake ()
    {
        score = 0;
    }


    void Update ()
    {
        ScoreManager.timer += Time.deltaTime;

        if (ScoreManager.timer >= bonusTime)
        {
            modifier = 1;
            ScoreManager.title = "Score: ";
        }

        if(enemiesLeft <= 0)
        {
            LevelUp();
        }

        scoreText.text = title + score;
        levelText.text = "spookiness Level: " + level;
        remainingText.text = "Enemies Left: " + enemiesLeft;

    }

    public static void Bonus()
    {
        ScoreManager.timer = 0;
        ScoreManager.modifier = 2;
        ScoreManager.title = "X2 Score: ";
    }

    public void LevelUp()
    {
        level++;
        enemiesLevelUp = enemiesLevelUp*2;
        enemiesLeft = enemiesLevelUp;
        GameOverManager.anim.SetTrigger("LevelUp");
    }

    public static int GetLevel()
    {
        return ScoreManager.level; 
    }
}
