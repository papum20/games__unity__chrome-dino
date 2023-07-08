using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino2Controller : MonoBehaviour
{

    public GameObject stand;
    public GameObject crouch;
    public GameObject dead;
    public GameObject gameOver;



    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            stand.SetActive(true);
            crouch.SetActive(false);
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject.Instantiate(dead, transform.position, Quaternion.identity);
            Time.timeScale = 0;
            crouch.SetActive(false);
            gameOver.SetActive(true);
            gameOver.GetComponent<AudioSource>().Play();
        }
    }





    /*
    public void unCrouchFunction()
    {
        stand.SetActive(true);
        crouch.SetActive(false);
    }*/

}
