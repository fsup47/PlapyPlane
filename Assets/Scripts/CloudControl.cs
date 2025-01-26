using UnityEngine;

public class CloudControl : MonoBehaviour
{
    // 1.75 - 5.0 f arasý y  x -14 14

    // Update is called once per frame
    void Update()
    {
        float rand_PosY = Random.Range(-2.45f, 5.0f);

        if (transform.position.x < -14.0f)
        {
            transform.position = new Vector3(14.0f, rand_PosY, transform.position.z);
        }

        transform.Translate(-1.0f * Time.deltaTime, 0, 0);
    }
}
