using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewInGame : MonoBehaviour
{
    //Variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;
    public TextMeshProUGUI scoreInitText;

    // Update is called once per frame
    void Update()
    {

        /*this.coinsText.text = coins.ToString();
        if(GameManager.sharedInstance.gameState == GameState.inGame ||
           GameManager.sharedInstance.gameState == GameState.inGameOver){
            
            this.coinsText.text = coins.ToString();
            
        }*/
            
        //if(GameManager.sharedInstance.gameState == GameState.inGame){
            if(scoreText!=null || maxScoreText!=null ||scoreInitText!=null){
                int scoreInit = GameManager.sharedInstance.GetPoints();
                Debug.Log(scoreInit);
                this.scoreInitText.text = scoreInit.ToString();
                int score = PlayerPrefs.GetInt("Score",0);
                this.scoreText.text = score.ToString();
                int maxScore = PlayerPrefs.GetInt("maxScore",0);
                this.maxScoreText.text = maxScore.ToString();
            }

            /*float distance = PlayerContoller.sharedInstance.GetDistance();
            this.scoreText.text = distance.ToString("f2");
            */

        //}   
    }
}
