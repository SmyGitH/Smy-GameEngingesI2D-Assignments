using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text playerScore;
    public Text highScore;
    public float updateScore;
    private float updateHighScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateScore += Time.deltaTime * 2;
        playerScore.text = " Score: " + (int)updateScore;
        highScore.text = " Highscore: " + (int)updateHighScore;


        if (updateScore > updateHighScore){
            updateHighScore = updateScore;
        }
    }
}
