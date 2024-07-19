using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlatform : MonoBehaviour
{

    [SerializeField] SpriteRenderer candleSpriteRenderer;
    [SerializeField] GameObject candle;
    [SerializeField] Sprite candleOff;
    [SerializeField] Sprite candleOn;


    [SerializeField] bool isBlueFinish;
    [SerializeField] bool isPinkFinish;

    void Start()
    {
        candle = GameObject.FindGameObjectWithTag("Candle");
        candleSpriteRenderer = candle.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        BothPlayerFinish();
    }


    // This funcion will execute only when both the player are came to the finish platform.
    void BothPlayerFinish()
    {
        if (isBlueFinish && isPinkFinish)
        {
            candleSpriteRenderer.sprite = candleOn;     // Light up the candle NOW
            Invoke("LoadNextLevel", 2f);                // Load the next level IN 2 SECONDS
        }
    }


    // Load the next level.
    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BluePlayer"))
        {
            isBlueFinish = true;
        } else if (other.gameObject.CompareTag("PinkPlayer"))
        {
            isPinkFinish = true;
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BluePlayer"))
        {
            isBlueFinish = false;
        }
        else if (other.gameObject.CompareTag("PinkPlayer"))
        {
            isPinkFinish = false;
        }
    }

}
