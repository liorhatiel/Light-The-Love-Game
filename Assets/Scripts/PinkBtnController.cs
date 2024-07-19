using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBtnController : MonoBehaviour
{

    public HiddenPinkController hiddenPinkController;

    [SerializeField] GameObject bluePlayer;
    [SerializeField] GameObject pinkPlayer;

    [SerializeField] SpriteRenderer sr;

    public bool isButtonPressed;
    [SerializeField] bool isBluePressed;
    [SerializeField] bool isPinkPressed;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");     // On code - At the beggining we declare who is the blue player.
        pinkPlayer = GameObject.FindGameObjectWithTag("PinkPlayer");     // On code - At the beggining we declare who is the pink player.
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == bluePlayer)
        {
            Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), hiddenPinkController.ShownPink.GetComponent<Collider2D>(), true);
            isBluePressed = true;
            isButtonPressed = true;
            sr.enabled = false;
            hiddenPinkController.HiddenPink.SetActive(false);
            hiddenPinkController.ShownPink.SetActive(true);
        }
        else if (other.gameObject == pinkPlayer)
        {
            Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), hiddenPinkController.ShownPink.GetComponent<Collider2D>(), true);
            isPinkPressed = true;
            isButtonPressed = true;
            sr.enabled = false;
            hiddenPinkController.HiddenPink.SetActive(false);
            hiddenPinkController.ShownPink.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject == bluePlayer)
        {
            isBluePressed = false;
            if (!isPinkPressed)
            {
                sr.enabled = true;
                gameObject.SetActive(true);
                isButtonPressed = false;
                hiddenPinkController.HiddenPink.SetActive(true);
                hiddenPinkController.ShownPink.SetActive(false);
            }
        }

        else if (other.gameObject == pinkPlayer)
        {
            isPinkPressed = false;
            if (!isBluePressed)
            {
                sr.enabled = true;
                gameObject.SetActive(true);
                isButtonPressed = false;
                hiddenPinkController.HiddenPink.SetActive(true);
                hiddenPinkController.ShownPink.SetActive(false);
            }
        }
    }

    //void PlayerPushTheButton()
    //{
    //    Physics2D.IgnoreCollision(bluePlayer.GetComponent<Collider2D>(), hiddenPinkController.ShownPink.GetComponent<Collider2D>(), true);
    //        isPinkPressed = true;
    //        isButtonPressed = true;
    //        sr.enabled = false;
    //        hiddenPinkController.HiddenPink.SetActive(false);
    //        hiddenPinkController.ShownPink.SetActive(true);
    //}
}
