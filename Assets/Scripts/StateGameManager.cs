using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateGameManager : MonoBehaviour
{
    [SerializeField] GameObject panelWin;
    [SerializeField] GameObject panelLose;


    private void OnEnable()
    {
        PlayerController.OnDestroyPlayer += LoseGame;
        PlayerController.OnSafeDogs += WinGame;
        CarController.OnDestroyDog += LoseGame;
    }

    private void OnDisable()
    {
        PlayerController.OnDestroyPlayer -= LoseGame;
        PlayerController.OnSafeDogs -= WinGame;
        CarController.OnDestroyDog -= LoseGame;
    }

    void LoseGame()
    {
        Time.timeScale = 0.0f;
         panelLose.SetActive(true);    
    }

    void WinGame()
    {
        Time.timeScale = 0.0f;
        panelWin.SetActive(true);
    }

}
