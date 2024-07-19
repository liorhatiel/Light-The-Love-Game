using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBlueController : MonoBehaviour
{
    public GameObject HiddenBlue;
    public GameObject ShownBlue;

    public BlueBtnController blueButton;

    void Start()
    {
        HiddenBlue.SetActive(true);
        ShownBlue.SetActive(false);
    }
   

}
