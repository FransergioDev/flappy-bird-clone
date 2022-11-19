using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int score = 000;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private GameObject gameStartObj;
    [SerializeField] private GameObject gameInstructionsObj;

    private Player player;
    private Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        player.enabled = false;
        Time.timeScale = 0;
        this.Scoring(true);
        this.StartGame();
        InvokeRepeating(nameof(updateDifficulty), 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame(bool isAtive = true) 
    {
        gameStartObj.SetActive(isAtive);
    }

    public void GameOver(bool isAtive = true) 
    {
        player.enabled = false;
        gameOverObj.SetActive(isAtive);
        if (isAtive) {
            Time.timeScale = 0;
        }
    }

    void InstructionsGame(bool isAtive = true) 
    {
        gameInstructionsObj.SetActive(isAtive);
    }

    public void StartGameButton() 
    {
        this.GameOver(false);
        this.StartGame(false);
        player.enabled = true;
        Time.timeScale = 1;
    }

    public void InstructionsButton()  {
        this.StartGame(false);
        this.InstructionsGame(true);
    }

    public void BackInstructionsButton()  {
        this.InstructionsGame(false);
        this.StartGame(true);
    }

    public void RestartGameButton() {
        SceneManager.LoadScene(0);
    }

    public void Scoring(bool startGame = false) {
        string scoreForText = "";
        score = (!startGame) ?  score + 1 : score = 0;
        if (score < 10) {
            scoreForText = "00" + score.ToString();
        } else if(score > 10 && score < 100) {
            scoreForText = "0" + score.ToString();
        } else {
            scoreForText = score.ToString();
        }
        scoreText.text = scoreForText;
    }
    private void updateDifficulty()
    {
        spawner.updateDifficulty();
    }
}
