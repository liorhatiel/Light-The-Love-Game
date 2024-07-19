using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBtnController : MonoBehaviour
{

    public HiddenBlueController hiddenBlueController;

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
            Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(), hiddenBlueController.ShownBlue.GetComponent<Collider2D>(), true);
            isBluePressed = true;
            isButtonPressed = true;
            sr.enabled = false;
            hiddenBlueController.HiddenBlue.SetActive(false);
            hiddenBlueController.ShownBlue.SetActive(true);
        } else if (other.gameObject == pinkPlayer)
        {
            Physics2D.IgnoreCollision(pinkPlayer.GetComponent<Collider2D>(), hiddenBlueController.ShownBlue.GetComponent<Collider2D>(), true);
            isPinkPressed = true;
            isButtonPressed = true;
            sr.enabled = false;
            hiddenBlueController.HiddenBlue.SetActive(false);
            hiddenBlueController.ShownBlue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject == bluePlayer )
        {
            isBluePressed = false;
            if (!isPinkPressed)
            {
                sr.enabled = true;
                gameObject.SetActive(true);
                isButtonPressed = false;
                hiddenBlueController.HiddenBlue.SetActive(true);
                hiddenBlueController.ShownBlue.SetActive(false);
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
                hiddenBlueController.HiddenBlue.SetActive(true);
                hiddenBlueController.ShownBlue.SetActive(false);
            }
        }


    }

}


