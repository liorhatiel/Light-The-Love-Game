using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPinkController : MonoBehaviour
{
    public GameObject HiddenPink;
    public GameObject ShownPink;

    public PinkBtnController pinkButton;

    void Start()
    {
        HiddenPink.SetActive(true);
        ShownPink.SetActive(false);
    }

}
