using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    private float speed = 10f;
    private float start = 27.75f, end = -5f;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= end)
            transform.position = new Vector3(transform.position.x + 8.06f * 4, transform.position.y);
    }


}
