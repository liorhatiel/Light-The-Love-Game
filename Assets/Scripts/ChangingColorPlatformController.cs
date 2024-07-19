using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColorPlatformController : MonoBehaviour
{

    [SerializeField] SpriteRenderer sr;
    [SerializeField] float changingTime;

    // Declare the colors of our changing color platform.
    string HtmlValue = "#FB12A6";
    Color pinkColor;
    Color blueColor = Color.blue;


    // To know witch color the platform start.
    [SerializeField] bool startAsBlue;
    [SerializeField] bool startAsPink;


    // Those below is for detection.
    // We need that our platform will detect when the blue player collide with them and when the pink player collide with them.
    [SerializeField] GameObject bluePlayer;
    [SerializeField] GameObject pinkPlayer;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString(HtmlValue, out pinkColor);
        DetectStartColor();
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");     // On code - At the beggining we declare who is the blue player.
        pinkPlayer = GameObject.FindGameObjectWithTag("PinkPlayer");     // On code - At the beggining we declare who is the pink player.
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorEverySomeSeconds();
    }
       

    void ChangeColorEverySomeSeconds()
    {
       if (sr.color == blueColor)
        {
            gameObject.layer = 6;                                  // Change this game object layer to 6 (BLUE).
            Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(), GetComponent<Collider2D>() , true);       // ON RUN TIME - IGNORE THE PINK layer collision from this game object collision
            Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);       // ON RUN TIME - **STOP!!** ignore. False detect stop.
            Invoke("ChangeColorToPink", changingTime);             // Change the color of this platform to pink in changing time (1.5 SECONDS).

        } else
        {
            gameObject.layer = 7;                                  // Change this game object layer to 7 (PINK).
            Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), GetComponent<Collider2D>() , true);       // ON RUN TIME - IGNORE THE BLUE layer collision from this game object collision
            Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);       // ON RUN TIME - **STOP!!** ignore. False detect stop.
            Invoke("ChangeColorToBlue", changingTime);             // Change the color of this platform to pink in changing time (1.5 SECONDS).
        }
    }

    void DetectStartColor()
    {
        if (startAsBlue)
        {
            sr.color = Color.blue;
        } else
        {
            sr.color = pinkColor;
        }
    }

    void ChangeColorToPink()
    {
        sr.color = pinkColor;
    }

    void ChangeColorToBlue()
    {
        sr.color = blueColor;
    }
}
