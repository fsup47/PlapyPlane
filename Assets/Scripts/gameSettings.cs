using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSettings : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject startRe;
    [SerializeField] private GameObject imgPause;
    private int pauseNum;
    [SerializeField] private AudioSource diePlane;
    [SerializeField] private AudioSource gameMusic1;
    [SerializeField] private AudioSource gameMusic2;
    [SerializeField] private GameObject configKeyInfo;
    private int musicNum;
    private float timecount;
    private void Start()
    {
        pauseNum = 0;
        timecount = 0;
        gameOver.SetActive(false);
        imgPause.SetActive(false);
        musicNum = 13;
        configKeyInfo.SetActive(true);
        Destroy(configKeyInfo, 3.5f);

    }
    private void Update()
    {
        pressKeyBoardControl();
        pauseControl();
        musicControl();
        
    }

    void pressKeyBoardControl()
    {
        if (gameOver.active)
        {
            if (Input.GetKeyDown(KeyCode.M)) SceneManager.LoadScene("MenuScene");
            if (Input.GetKeyDown(KeyCode.R)) ReStart();
        }
    }
    void pauseControl()
    {
        if (gameOver.active) return;
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseNum++;
            if (pauseNum % 2 != 0)
            {
                imgPause.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else if (pauseNum % 2 == 0)
            {
                imgPause.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }
    public void ReStart()
    {

        gameOver.SetActive(false);
        startRe.GetComponent<GameMec>().reStart();
    }

    public void GameOver()
    {

        diePlane.Play();
        gameOver.SetActive(true);
        imgPause.SetActive(false);
    }

    void musicControl()
    {
        if (gameOver.active)
        {
            gameMusic1.Stop();
            gameMusic2.Stop();
        }
        else if (gameMusic1.isPlaying || gameMusic2.isPlaying) return;
        else if (musicNum % 2 != 0 && !gameMusic1.isPlaying && !gameMusic2.isPlaying)
        {
            musicNum++;
            gameMusic1.Play();

        }
        else if (musicNum % 2 == 0 && !gameMusic1.isPlaying && !gameMusic2.isPlaying)
        {
            musicNum++;
            gameMusic2.Play();
            musicNum = 13;
        }



    }

}
