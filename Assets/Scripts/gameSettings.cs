using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSettings : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject startRe;
    [SerializeField] private GameObject imgPause;
    private int pauseNum;
    [SerializeField] private AudioSource diePlane;
    [SerializeField] private AudioSource gameMusic;
    private void Start()
    {
        pauseNum = 0;
        gameOver.SetActive(false);
        imgPause.SetActive(false);
        gameMusic.Play();
    }
    private void Update()
    {
        pressKeyBoardControl();
        pauseControl();
    }
    void pressKeyBoardControl()
    {
        if (gameOver.active)
        {
            if(Input.GetKeyDown(KeyCode.M)) SceneManager.LoadScene("MenuScene");
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
        gameMusic.Play();
        gameOver.SetActive(false);
        startRe.GetComponent<GameMec>().reStart();
    }

    public void GameOver()
    {
        gameMusic.Stop();
        diePlane.Play();
        gameOver.SetActive(true);
        imgPause.SetActive(false);
    }


}
