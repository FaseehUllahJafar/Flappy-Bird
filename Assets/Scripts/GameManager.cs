using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    public Text scoreText;
    public Player player;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject gameStart;
    [SerializeField] public AudioSource startGameSound;

    private float timeVal = 0f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        PlayerPrefs.SetInt("GameStarted", 0);
        Pause();
        startGameSound.Play();
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void continueGame()
    {
        int checkIfStarted = PlayerPrefs.GetInt("GameStarted");
        if (checkIfStarted == 1)
        {
            Time.timeScale = timeVal;
            if (timeVal == 0f)
            {
                timeVal = 1f;
                player.enabled = false;
                PlayerPrefs.SetInt("isPaused", 1);
            }
            else
            {
                timeVal = 0f;
                PlayerPrefs.SetInt("isPaused", 0);
                player.enabled = true;
            }
        }
    }
    public void Play()
    {
        PlayerPrefs.SetInt("GameStarted", 1);
        startGameSound.Stop();
        gameStart.SetActive(false);
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // if player restarts the game all the pipes should be removed
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f; // it stops everything
        player.enabled = false;
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        PlayerPrefs.SetInt("GameStarted", 0);
        Pause();
    }
}
