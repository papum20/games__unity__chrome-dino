using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


[ExecuteInEditMode]
public class DinoController : MonoBehaviour
{

    public GameObject stand;
    public GameObject crouch;
    public GameObject dead;
    public GameObject gameOver;

    public Vector2 jumpForce;
    private bool jumping = false;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float upOrDown = CrossPlatformInputManager.GetAxisRaw("Vertical");

        if(upOrDown > 0)
//        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumping == false)
            {
                GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
                GetComponent<AudioSource>().Play();
                jumping = true;
            }
        }


        
/*        if (jumping == false && Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch.SetActive(true);
            stand.SetActive(false);
        }*/


    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            jumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject.Instantiate(dead, transform.position, Quaternion.identity);
            Time.timeScale = 0;
            stand.SetActive(false);
            gameOver.SetActive(true);
            gameOver.GetComponent<AudioSource>().Play();
        }
    }







    public bool getJumping()
    {
        return jumping;
    }
    /*public void setJumping(bool newValue)
    {
        jumping = newValue;
    }*/



    /*
    public void jumpFunction()
    {
        if (jumping == false)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
            jumping = true;
        }
    }*/

    /*
    public void crouchFunction()
    {
        crouch.SetActive(true);
        stand.SetActive(false);
    }
    */


}
