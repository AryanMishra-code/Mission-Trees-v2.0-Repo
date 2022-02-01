using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayStart : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    
    [SerializeField] private GameObject gameTextStart;
    [SerializeField] private GameObject startingHints;
    [SerializeField] private GameObject thirdText;
    [SerializeField] private GameObject countOfSaplingsText;
    [SerializeField] private GameObject statusOfSaplingsText;
    [SerializeField] private GameObject reticule;
    [SerializeField] private GamePlayeOptions optionsManager;
    
    [SerializeField] private float timePauseForText = 10f;

    void Start()
    {
        StartCoroutine(GameProcess());
    }

    IEnumerator GameProcess()
    {
        playerMovement.enabled = false;
        gameTextStart.SetActive(true);
        yield return new WaitForSeconds(timePauseForText);

        gameTextStart.SetActive(false);
        startingHints.SetActive(true);
        yield return new WaitForSeconds(timePauseForText);
        
        startingHints.SetActive(false);
        thirdText.SetActive(true);
        yield return new WaitForSeconds(15f);
        
        thirdText.SetActive(false);
        countOfSaplingsText.SetActive(true);
        statusOfSaplingsText.SetActive(true);
        reticule.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        playerMovement.enabled = true;
        optionsManager.enabled = true;
    }
}