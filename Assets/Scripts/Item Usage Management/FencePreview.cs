using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencePreview : MonoBehaviour
{
    public GameObject fencePrefab = null;
    [HideInInspector] public FencePlacer placer;

    private bool snapped = false;

    private void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, placer.placingRange,
            placer.ground))
        {
            if (!snapped)
                transform.position = hit.point;
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                Vector3 targetRot = transform.localEulerAngles;
                targetRot.y += placer.rotationIncrement;
                transform.rotation = Quaternion.Euler(targetRot);
            }
            
            placer.targetRot = transform.localEulerAngles;

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(fencePrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnapPoint"))
        {
            StartCoroutine(SetSnappedBool());
            transform.position = other.transform.position - Vector3.up;
        }
    }

    private IEnumerator SetSnappedBool()
    {
        snapped = true;
        yield return new WaitForSeconds(placer.undoSnappingDelay);
        snapped = false;
    }
}
