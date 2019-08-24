using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //using TextMeshPro

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    // Update is called once per frame
    void Start()
    {
        //PlayerPrefs.DeleteAll();
       // score = 0;
        highScore = PlayerPrefs.GetInt("highScore", score);
    }

    void Update()
    {
        scoreUI.text = score.ToString();//store score into UI text so that score can appear on sreen
        highScoreUI.text = highScore.ToString();
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }
    //this function will trigger once the player hits a collider that has is trigger checked
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "scoreup")//gaps are tagged with "scoreup" in Unity
        {
            score++;
        }
       
    }
}
