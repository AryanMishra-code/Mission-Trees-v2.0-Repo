using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayStart : MonoBehaviour
{
    [Header("Pre-Game UI")]
    [SerializeField] private GameObject gameTextStart;
    [SerializeField] private GameObject startingHints;
    [SerializeField] private GameObject thirdText;
    [SerializeField] private GameObject basicControls;
    [SerializeField] private float timePauseForText = 10f;
    
    [Header("Starting Game Objects")]
    [SerializeField] private GameObject countOfSaplingsText;
    [SerializeField] private GameObject reticule;

    [Header("Other Ref. Components")]
    [SerializeField] private GamePlayOptions optionsManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FencePlacer _fence;

    void Start()
    {
        StartCoroutine(GameProcess());
    }

    IEnumerator GameProcess()
    {
        playerMovement.enabled = false;
        _fence.enabled = false;
        gameTextStart.SetActive(true);
        yield return new WaitForSeconds(timePauseForText);

        gameTextStart.SetActive(false);
        startingHints.SetActive(true);
        yield return new WaitForSeconds(timePauseForText);
        
        startingHints.SetActive(false);
        thirdText.SetActive(true);
        yield return new WaitForSeconds(timePauseForText + 5f);

        thirdText.SetActive(false);
        countOfSaplingsText.SetActive(true);
        reticule.SetActive(true);

        yield return new WaitForSeconds(2f);
        playerMovement.enabled = true;
        _fence.enabled = true;
        optionsManager.enabled = true;
    }
}