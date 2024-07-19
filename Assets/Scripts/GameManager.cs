using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject bluePlayer;
    [SerializeField] GameObject pinkPlayer;



    void Start()
    {
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");
        pinkPlayer = GameObject.FindGameObjectWithTag("PinkPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        RestartWhenPlayerFall();
    }


    // If one of the player is fall to the buttom , the level will start over from the current level.
    void RestartWhenPlayerFall()
    {
        if (bluePlayer.transform.position.y < -5.35 || pinkPlayer.transform.position.y < -5.35)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

   
}
