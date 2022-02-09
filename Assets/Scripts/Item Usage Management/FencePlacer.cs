using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencePlacer : MonoBehaviour
{
    public FencePreview fencePreview = null;
    public float placingRange;
    public LayerMask ground;
    public int rotationIncrement = 90;

    private FencePreview currentPreview;
    public Vector3 targetRot;

    private bool isPlacing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            isPlacing = true;

        if (Input.GetKeyDown(KeyCode.X))
            isPlacing = false;

        if (isPlacing)
            InstantiatePreview();
        else
        {
            if (currentPreview != null)
                Destroy(currentPreview.gameObject);
        }
    }

    private void InstantiatePreview()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, placingRange,
            ground))
        {
            if (currentPreview == null)
            {
                currentPreview = Instantiate(fencePreview, hit.point, Quaternion.Euler(targetRot));
                currentPreview.placer = this;
            }
        }
    }
}
