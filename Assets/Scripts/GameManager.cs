using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;



//[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    public GameObject dino;
    public GameObject dino2;
    public GameObject gameOver;
    public Text score;
    public Text HighScore;

    public Vector2 enemySpeed;

    public GameObject[] prefabs;
    private GameObject enemyParent;

    public float minTime;
    public float maxTime;
    private float currentTime = 0;
    private float nextTime;

    private int scoreValue = 0;
    private float scoreTime = 0.1f;
    private float timePassed = 0;

    private bool dinoCrouching = false;




    // Start is called before the first frame update
    void Start()
    {
        dino2.SetActive(false);
        gameOver.SetActive(false);

        enemyParent = (GameObject)Instantiate(Resources.Load("EnemyParent"));

        nextTime = Random.Range(minTime, maxTime);

        HighScore.text = PlayerPrefs.GetInt("Score").ToString("0000");

        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {

        //DINO CROUCH

        DinoController dController = dino.GetComponent<DinoController>();      

        if (CrossPlatformInputManager.GetAxisRaw("Vertical") < 0 && (dinoCrouching || !dController.getJumping()) )
        {
            dinoCrouching = true;
            dino.SetActive(false);
            dino2.SetActive(true);
        }
        else
        {
            dinoCrouching = false;
            dino.SetActive(true);
            dino2.SetActive(false);
        }


        //OBSTACLES

        if(currentTime >= nextTime)
        {
            GameObject tmp = prefabs[Random.Range(0, prefabs.Length)];
            Instantiate(tmp, tmp.GetComponent<EnemyController>().startPosition, Quaternion.identity, enemyParent.GetComponent<Transform>());
            currentTime = 0;
            nextTime = Random.Range(minTime, maxTime);
        }
        else
        {
            currentTime += Time.deltaTime;
        }


        //SCORE

        if(timePassed >= scoreTime)
        {
            scoreValue++;
            score.text = scoreValue.ToString("0000");
            if (scoreValue % 100 == 0)
            {
                score.gameObject.GetComponent<AudioSource>().Play();
                Time.timeScale += 0.1f;
            }
            if (PlayerPrefs.GetInt("Score") < scoreValue)
                PlayerPrefs.SetInt("Score", scoreValue);
            timePassed = 0;
        }
        timePassed += Time.deltaTime;



        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject tmp = enemyParent;
            enemyParent = (GameObject)Instantiate(Resources.Load("EnemyParent"));
            Destroy(tmp);
        }
        */

    }




    /*
    public void scoreFunction()
    {
        scoreValue++;
        score.text = scoreValue.ToString("0000");
        if (PlayerPrefs.GetInt("Score") < scoreValue)
            PlayerPrefs.SetInt("Score", scoreValue);
    }
    */





    public void GameOverButton()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }


    public void ExitButton()
    {
        Application.Quit();
    }


}
