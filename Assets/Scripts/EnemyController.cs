using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[ExecuteInEditMode]
public class EnemyController : MonoBehaviour
{

    private GameManager gameManager;

    public Vector2 startPosition;
    private Vector2 movementForce;

    //private bool scored = false;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        movementForce = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().enemySpeed;
        GetComponent<Rigidbody2D>().AddForce(movementForce, ForceMode2D.Force);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!scored && transform.position.x <= 3.25f)
        {
            gameManager.scoreFunction();
            scored = true;
        }
        */
        if (transform.position.x <= -2)
            Destroy(gameObject);
    }

}
