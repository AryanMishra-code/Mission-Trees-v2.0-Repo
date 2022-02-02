using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutting : MonoBehaviour
{
    [SerializeField] private float rangeToStart = 10f;
    [SerializeField] float treeHealth = 200f;
    [SerializeField] private Transform player;
    private float distanceToPlayer = Mathf.Infinity;
    private Animator animController;
    
    private void Start()
    {
        animController = GetComponent<Animator>();
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        
        if (distanceToPlayer <= rangeToStart)
        {
            treeHealth -= 7.5f;

            if (treeHealth <= 0)
            {
                animController.SetTrigger("Set Tree Fall");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangeToStart);
    }
}