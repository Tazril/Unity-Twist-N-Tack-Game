using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    public static UiManager instance;

    public GameObject zigzagPanel;
    public GameObject gameOverPanel;
    public GameObject TapText;
    public GameObject Button;
    public Text score;
    public Text score1;
    public Text highScore1;
    public Text highScore2;
    public Text highScore3;
    public GameObject AboutPanel;
    public GameObject HelpPanel;
    public GameObject AboutButton;
    public GameObject HelpButton;
    public GameObject JumpButton;
    public GameObject MoveButton;
    public GameObject ScoreShow;
    public GameObject ShowHighScorePanel;
    public GameObject HighScoreButton;


    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
        
    }

    // Use this for initialization
    void Start () {
        highScore1.text = "High Score: ";
        highScore3.text = PlayerPrefs.GetInt("highScore").ToString();

    }

    public void GameStart()
    {
        ScoreShow.SetActive(true);
        TapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("Panel Up");
       
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        MoveButton.SetActive(false);
        
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void About()
    {
        
        AboutPanel.SetActive(true);
        MoveButton.SetActive(false);
        HelpButton.SetActive(false);
        HelpButton.SetActive(false);
        HighScoreButton.SetActive(false);

    }

    public void Help()
    {
        
        HelpPanel.SetActive(true);
        MoveButton.SetActive(false);
        HelpButton.SetActive(false);
        HighScoreButton.SetActive(false);

    }
    public void ShowHighScoreP()
    {
        ShowHighScorePanel.SetActive(true);
        HighScoreButton.SetActive(false);
    }


    // Update is called once per frame
    void Update () {
        score1.text = ScoreManager.instance.score.ToString();
        



    }

  
        
  
    
}
