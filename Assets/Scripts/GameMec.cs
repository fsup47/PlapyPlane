using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
//baþlama sesi, uçus hýzý, kapanýþ hýzý
public class GameMec : MonoBehaviour
{
    [SerializeField] private GameObject startScene;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject rocks;
    [SerializeField] private float rangeRocks;
    private GameObject scoreText;
    private int score;
    private float rangeRocksCount;
    [SerializeField] private float rocksSpeed;
    
    void Start()
    {

        rangeRocksCount = 0.0f;
        rocksSpeed = 3.0f;
        Time.timeScale = 1.0f;
        scoreText = GameObject.Find("scoree");
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        Instantiate(startScene, Vector3.zero, Quaternion.identity);
        score = 0;
        Instantiate(plane, Vector3.zero, Quaternion.identity);

    }

  
    void Update()
    {
        updateRockRange();
    }

    void rocks_Added()
    {
        var rocksVar = Instantiate(rocks);
        rocksVar.GetComponent<RocksControl>().rocksSpeed = rocksSpeed;
    }

    public void scoreControl()
    {
        score += 1;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        if (score % 5 == 0) rangeRocks -= 0.2f;
        if (score % 2 == 0) rocksSpeed += 0.3f;
    }

    public void reStart()
    {
        rocksSpeed = 3.0f;
        rangeRocks = 3.0f;
        foreach (var item in GameObject.FindGameObjectsWithTag("rock"))
        {
            Destroy(item);
        };
        score = 0;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        Instantiate(plane, Vector3.zero, Quaternion.identity);
        Time.timeScale = 1.0f;
   
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void updateRockRange()
    {
        rangeRocksCount += Time.deltaTime;

        if (rangeRocksCount > rangeRocks)
        {
            rangeRocksCount = 0.0f;
            rocks_Added();
        }

    }
}
