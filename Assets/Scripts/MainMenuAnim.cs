using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    [SerializeField] private GameObject rockis;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject cloud2;
    [SerializeField] private float point1;
    [SerializeField] private float point2;
    [SerializeField] private float point3;
    [SerializeField] private float point4;
    private float counter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rockis.transform.position = new Vector3(6.34f, -2.0f, 0);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rockisUpdated();
    }

    void rockisUpdated()
    {
        rockCnt();
        cloudCnt(cloud);
        cloudCnt(cloud2);
        planeCntrl();
    }
    void rockCnt()
    {
        rockis.transform.Translate(-3.0f * Time.deltaTime, 0, 0);
        if (rockis.transform.position.x < -14.0f)
        {
            rockis.transform.position = new Vector3(6.34f,-2.0f, 0);
        }
    }
    void cloudCnt(GameObject cloudd)
    {
        float rand_PosY = Random.Range(-1.0f, 4.0f);

        if (cloudd.transform.position.x < -14.0f)
        {
            cloudd.transform.position = new Vector3(14.0f, rand_PosY, cloudd.transform.position.z);
        }

        cloudd.transform.Translate(-1.0f * Time.deltaTime, 0, 0);
    }
    void planeCntrl()
    {
        counter += Time.deltaTime;
        if(counter < point1)
        {
            plane.transform.Translate(0, 1f * Time.deltaTime, 0);
        }
        else if(counter < point3 && counter > point2)
        {
            plane.transform.Translate(0, -1f * Time.deltaTime, 0);
        }
        else if(counter < point4 && counter > point3)
        {
            plane.transform.Translate(0, 0, 0);

        }
       else if (counter > point4)
        {
            counter = 0;
        }
        
    }
}
