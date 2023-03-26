using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapToPlayClose : MonoBehaviour
{
    public Button playButton;
    public GameObject panel;

    void Start()
    {
        playButton.onClick.AddListener(HideTapToPlayScreen);
    }

    void HideTapToPlayScreen()
    {
        gameObject.SetActive(false);
    }
}
