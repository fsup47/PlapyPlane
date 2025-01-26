using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneControl : MonoBehaviour
{
    //h�z�na g�re ayarlayabilirsin y�n� tayinde veya digerine g�re
    private Rigidbody2D rigidBody2dPlane;
    [SerializeField] private float flightForce;
    [SerializeField] private float limitForce;
    [SerializeField] private AudioSource audioPlane;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2dPlane = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody2dPlane.AddForce(Vector2.zero);
            rigidBody2dPlane.AddForce(transform.up * flightForce, ForceMode2D.Impulse);

            audioPlane.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0.0f;
        Destroy(gameObject); 
        GameObject.Find("Canvas").GetComponent<gameSettings>().GameOver(); 
    }

}
