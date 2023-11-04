using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour                    //tale script per gestire i gameLoop (Gameover, ecc.)
{
    public static Gamemanager gamemanager;
    [SerializeField]
    GameObject pressAnyKeyPanel, gameOverPanel, gameWonPanel;
    Rigidbody2D ball;                       //riferimento alla palla
    bool gameStart = false, gameOver = false;
    int spawnedBricks = 0;

    GameObject Bar;
    [SerializeField]
    GameObject explosionEffect;

    [SerializeField]
    AudioSource VictorySound;

    [SerializeField]
    AudioSource RestartSound;

    private void Awake()
    {
        gamemanager = this;
    }
    void Start()
    {
        ResetGameScene();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {     
            if (gameOver)
            {
                gameOverPanel.SetActive(false);
                gameWonPanel.SetActive(false);
                ResetGameScene();
            }

            else if (!gameStart)             //Se il gioco non è partito ed io faccio click tasto Sx del mouse --> applico alla palla una forza verso l'alto
            {
                gameStart = true;
                pressAnyKeyPanel.SetActive(false);
                ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();                    //prendo  la referenza alla palla
                ball.AddForce(Vector2.up);                                                                      //applico la forza alla palla per far sparare la prima volta la palla
            }
        }
    }


     void ResetGameScene()                                               //metodo che mi aggiunge e/o toglie ogni volta la scena "GameScene"
    {
        RestartSound.Play();
        if (SceneManager.GetSceneByName("GameScene").name == "GameScene")
        {
            SceneManager.UnloadScene("GameScene");
        }

        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        gameOver = false;
        gameStart = false;
        pressAnyKeyPanel.SetActive(true);
        spawnedBricks = 0;

    }


  public void GameOver()
    {
        if (Bar == null)                                                         
        {
            Bar = GameObject.FindGameObjectWithTag("Bar");
        }
        GameObject.Instantiate(explosionEffect, Bar.transform.position, Quaternion.identity, Bar.transform);        //instanzio la particles dell'esplosione 
        Bar.GetComponent<SpriteRenderer>().enabled = false;                                     //faccio scomparire la barra (non devo riabilitarla, tanto verra resettata la scena)

        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    void GameWon()
        {
            Destroy(ball.gameObject);
            VictorySound.Play();
            gameWonPanel.SetActive(true);
            gameOver = true;
    }

    public void setSpawnedBricks  (int value)
    {
        spawnedBricks=value;
    }
 
    public void BrickDestroyed()
    {
        spawnedBricks--;
        if(spawnedBricks <= 0 )
        {
            GameWon();
        }
    }

   
}
