using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] string scene;
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
        SceneManager.LoadScene(scene);
        
    }

}
