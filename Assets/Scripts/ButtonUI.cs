using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonUI : MonoBehaviour
{
   [SerializeField] GameObject ObjectUI;
    [SerializeField] Button myButton;

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
        
        if (ObjectUI.activeSelf)
        {
            ObjectUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            ObjectUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }


}
