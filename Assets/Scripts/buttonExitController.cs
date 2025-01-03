using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonExitController : MonoBehaviour
{
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();  
    }

    private void Start()
    {
        myButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Application.Quit();
    }
}
