using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;   // 전역설정.


    public bool isGameStart = false;       // 게임 스타트 체크할 변수
    public bool isGameOver = false;        // 게임이 끝났는지 체크할 변수

    int score = 0;                  // 점수

    [SerializeField]
    GameObject titleUI;
    [SerializeField]
    GameObject gameOverUI;
    [SerializeField]
    Text scoreText;
    Text bestScore;



    // Start is called before the first frame update
    void Start()
    {
        gm = this;  // 변수에 자기 자신을 담아둠.

        if(titleUI == null)
        {
            titleUI = GameObject.Find("TitleUI");
        }

        // 하이어라키(씬)에 있는 오브젝트 중 같은 이름의 오브젝트를 찾아서 가져옴.
        // 만약 같은 이름의 오브젝트가 여러개 라면 먼저 검색된 오브젝트를 가져옴.

        gameOverUI = GameObject.Find("GameOverUI");

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // 같은 이름의 오브젝트를 찾은 다음 그 오브젝트 내에 있는 컴포넌트 중 Text 컴포넌트를 가져옴

        bestScore = GameObject.Find("BestScoreText").GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();        // 함수 호출!!
            }
        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();        // 함수 호출!!
            }
        }
    }


    void GameStart()
    {
        isGameStart = true;
        titleUI.SetActive(false);
        scoreText.enabled = true;

    }

    public void GameOver()
    {
        isGameOver = true;

        for(int i = 0; i < gameOverUI.transform.childCount; i++)
        {
            gameOverUI.transform.GetChild(i).gameObject.SetActive(true);
        }

        SetBestScore();     // 베스트 스코어 저장
        GetBestScore();

        
        bestScore.enabled = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // 현재 열려있는 씬을 다시 불러옴

        //SceneManager.LoadScene(0);        // 씬 빌드 인덱스 중 해당 숫자의 씬을 불러옴
        //SceneManager.LoadScene("Main");   // 같은 이름의 씬을 불러옴
    }

    public void GetScore()
    {
        score++;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void GetBestScore()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        int bscore = PlayerPrefs.GetInt("BestScore");
        bestScore.text = "BEST: " + bscore.ToString();
    }

    public void SetBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            if(score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

    }

}
