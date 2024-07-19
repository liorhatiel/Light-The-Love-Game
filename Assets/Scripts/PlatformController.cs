using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    // This is for get a refrence for the SpriteRenderer componenet.
    [SerializeField] SpriteRenderer sr;

    // Those below is for know if this platform is blue, pink or uncolor.
    [SerializeField] bool isBlue;
    [SerializeField] bool isPink;

    // Those below is for detection.
    // We need that our platform will detect when the blue player collide with them and when the pink player collide with them.
    [SerializeField] GameObject bluePlayer;
    [SerializeField] GameObject pinkPlayer;


    // Those below is for the pink color
    // Blue is build in Unity Color , but Pink doesnt.
    string HtmlValue = "#FB12A6";
    protected Color pinkColor;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();                             // A refrence to the SpriteRenderer componenet.
        ColorUtility.TryParseHtmlString(HtmlValue, out pinkColor);       // This funcion take HTML VALUE and return Color that represent the HTML value.
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");     // On code - At the beggining we declare who is the blue player.
        pinkPlayer = GameObject.FindGameObjectWithTag("PinkPlayer");     // On code - At the beggining we declare who is the pink player.
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BluePlayer") && !isPink )
        {
            ChangePlatformToBlue();
        }

        else if (other.gameObject.CompareTag("PinkPlayer") && !isBlue)
        {
            ChangePlatformToPink();
        }
    }




    void ChangePlatformToBlue()
    {
        isBlue = true;                                                                                      // This game object is BLUE now.
        sr.color = Color.blue;                                                                              // Change this game object color to BLUE.
        gameObject.layer = 6;                                                                               // Layer 6 = Blue.
        Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(), GetComponent<Collider2D>() , true);       // ON RUN TIME - IGNORE THE PINK layer collision from this game object collision
    }


    void ChangePlatformToPink()
    {
        isPink = true;                                                                                      // This game object is BLUE now.
        sr.color = pinkColor;                                                                               // Change this game object color to PINK.
        gameObject.layer = 7;                                                                               // Layer 7 = Pink.
        Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), GetComponent < Collider2D>() , true);     // ON RUN TIME - IGNORE THE BLUE layer collision from this game object collision
    } 


}
