using UnityEngine;

public class RocksControl : MonoBehaviour
{
    public float rocksSpeed;
    [SerializeField] private float spawnPointDown = -2.70f;
    [SerializeField] private float spawnPointUp = 3.0f;
    
    //y -2.73 1.18
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rocksSpeed = 3.0f;
        float rand_y = Random.Range(spawnPointDown, spawnPointUp);
        transform.position = new Vector3(14.5f, rand_y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       // updateRocksSpeed();
      
        transform.Translate(-rocksSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -14.5) Destroy(gameObject);
       
    }

}
