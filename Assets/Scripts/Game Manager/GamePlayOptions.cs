using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayOptions : MonoBehaviour
{
    [Header("Object Components")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CameraMouseLook _cameraMouseLook;
    
    [Header("Game Object Variables")]
    // [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject reticule;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject controlsPanel;
    // [SerializeField] private GameObject controlsButton;
    
    private void Update()
    {
        // if (Input.GetKey(KeyCode.O))
        // {
        //     optionsButton.SetActive(true);
        //     _playerMovement.enabled = false;
        //     _cameraMouseLook.enabled = false;
        //     Cursor.lockState = CursorLockMode.None;
        // }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowOptionsPanel();
            _playerMovement.enabled = false;
            _cameraMouseLook.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ShowOptionsPanel()
    {
        controlsPanel.SetActive(false);
        reticule.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);
        optionsPanel.SetActive(false);
        reticule.SetActive(false);
    }
    
    public void ResumeGame()
    {
        controlsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        reticule.SetActive(true);
        _playerMovement.enabled = true;
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
