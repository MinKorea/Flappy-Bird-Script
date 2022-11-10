using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;   // ��������.


    public bool isGameStart = false;       // ���� ��ŸƮ üũ�� ����
    public bool isGameOver = false;        // ������ �������� üũ�� ����

    int score = 0;                  // ����

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
        gm = this;  // ������ �ڱ� �ڽ��� ��Ƶ�.

        if(titleUI == null)
        {
            titleUI = GameObject.Find("TitleUI");
        }

        // ���̾��Ű(��)�� �ִ� ������Ʈ �� ���� �̸��� ������Ʈ�� ã�Ƽ� ������.
        // ���� ���� �̸��� ������Ʈ�� ������ ��� ���� �˻��� ������Ʈ�� ������.

        gameOverUI = GameObject.Find("GameOverUI");

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // ���� �̸��� ������Ʈ�� ã�� ���� �� ������Ʈ ���� �ִ� ������Ʈ �� Text ������Ʈ�� ������

        bestScore = GameObject.Find("BestScoreText").GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameStart();        // �Լ� ȣ��!!
            }
        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();        // �Լ� ȣ��!!
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

        SetBestScore();     // ����Ʈ ���ھ� ����
        GetBestScore();

        
        bestScore.enabled = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // ���� �����ִ� ���� �ٽ� �ҷ���

        //SceneManager.LoadScene(0);        // �� ���� �ε��� �� �ش� ������ ���� �ҷ���
        //SceneManager.LoadScene("Main");   // ���� �̸��� ���� �ҷ���
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
