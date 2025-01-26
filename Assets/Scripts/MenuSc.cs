using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSc : MonoBehaviour
{
    [SerializeField] private AudioSource menuAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("PlaneLikeFlapy");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
