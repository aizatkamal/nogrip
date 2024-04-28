using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    public float theBestScore;
    public float time;
    public TextMeshPro scoreText;
    public TextMeshPro gameOverText;
    public TextMeshPro currentScore;
    public TextMeshPro bestScore;
    public TextMeshPro showScoreText;
    public TextMeshPro showBestText;
    public TextMeshPro newBest;
    public bool isGameActive = true;
    public bool isGameStart = false;
    public Button restartButton;
    public Button startButton;
    public Button mainButton;
    public Button pauseButton;
    public TextMeshProUGUI textPausePlay;
    public Button screenshotButton;
    public AudioClip cameraShutter;
    private AudioSource cameraAudio;
    public AudioSource musicManager;

    // Start is called before the first frame update
    void Start()
    {
        cameraAudio = GetComponent<AudioSource>();
        score = 0;
        scoreText.text = $"{score}";
        theBestScore = MainManager.Instance.bestScore;
        bestScore.text = $"{theBestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;

        // if game is not active or game over
        if (isGameActive == false)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            currentScore.gameObject.SetActive(true);
            bestScore.gameObject.SetActive(true);
            showScoreText.gameObject.SetActive(true);
            showBestText.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            mainButton.gameObject.SetActive(false);
            screenshotButton.gameObject.SetActive(true);
            isGameStart = false;

            if (score > theBestScore)
            {
                newBest.gameObject.SetActive(true);
            }

        }

        if (score > theBestScore)
        {
            bestScore.text = $"{score}";
            MainManager.Instance.SaveScore(score);
        }

    }

    public void StartGame()
    {
        isGameStart = true;
        startButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        mainButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            textPausePlay.text = "Play";
            musicManager.Pause();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            textPausePlay.text = "Pause";
            musicManager.Play();
        }
    }

    public void TakeScreenshot()
    {
        //Debug.Log(Application.persistentDataPath);
        cameraAudio.PlayOneShot(cameraShutter, 1.0f);
        ScreenCapture.CaptureScreenshot($"NoGrip{score}{theBestScore}{score + theBestScore}{Mathf.RoundToInt(time)}.png");
    }


}
