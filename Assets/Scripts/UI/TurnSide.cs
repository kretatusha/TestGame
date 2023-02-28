using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSide : MonoBehaviour
{
    public float topBound = 30.0f;
    public float lowerBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > topBound || transform.position.x < lowerBound)
        {
            transform.rotation = new Quaternion(transform.rotation.x, -transform.rotation.y, transform.rotation.z, transform.rotation.w);
            transform.position = new Vector3(transform.position.x < lowerBound ? lowerBound : topBound, transform.position.y, transform.position.z);
        }
    }
}
