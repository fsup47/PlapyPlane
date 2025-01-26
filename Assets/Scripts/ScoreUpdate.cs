using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("startPrefab").GetComponent<GameMec>().scoreControl();
    }
}
