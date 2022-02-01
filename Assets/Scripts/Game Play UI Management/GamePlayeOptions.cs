using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayeOptions : MonoBehaviour
{
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlantationOfSaplings plantManager;
    [SerializeField] private GameObject reticule;
    [SerializeField] private CameraMouseLook _cameraMouseLook;
    [SerializeField] private GameObject optionsPanel;

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            optionsButton.SetActive(true);
            _playerMovement.enabled = false;
            plantManager.enabled = false;
            _cameraMouseLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ShowOptionsPanel()
    {
        reticule.SetActive(false);
        optionsPanel.SetActive(true);
        optionsButton.SetActive(false);
    }
    
    public void ResumeGame()
    {
        optionsPanel.SetActive(false);
        optionsButton.SetActive(false);
        reticule.SetActive(true);
        _playerMovement.enabled = true;
        plantManager.enabled = true;
        _cameraMouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToHomaPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitTheGame()
    {
        Debug.Log("Exited Game from game play!");
        Application.Quit();
    }
}
