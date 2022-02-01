using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomContainerSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> containers = new List<GameObject>();
    GameObject _activeGameObject;
    
    void Start()
    {
        _activeGameObject = containers[Random.Range(0, containers.Count - 1)];
        _activeGameObject.SetActive(true);
    }
}