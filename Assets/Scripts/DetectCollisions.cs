using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int points;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            ScoreManager.instance.AddPoint(-points);
            other.gameObject.GetComponent<PlayerController>().minusLive();
        }
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            ScoreManager.instance.AddPoint(points);
        }
        Destroy(gameObject);
    }

}
