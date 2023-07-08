using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    private float speed = 2f;
    private float start = 22f, end = -2f;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= end)
            transform.position = new Vector3(start, transform.position.y);
    }


}
