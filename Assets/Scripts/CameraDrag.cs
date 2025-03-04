using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Camera mainCamera;

    private Vector3 origin;
    private Vector3 difference;

    private Bounds cameraBounds;
    private Vector3 targetPosition;

    private void Awake() => mainCamera = Camera.main;
    /*{
        mainCamera = Camera.main;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        var height = mainCamera.orthographicSize;
        var width = height * mainCamera.aspect;

        var minX = Globals.WorldBounds.min.x + width;
        var maxX = Globals.WorldBounds.extents.x - width;

        var minY = Globals.WorldBounds.min.y + height;
        var maxY = Globals.WorldBounds.extents.y - height;

        cameraBounds = new Bounds();
        cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
            );
    }

    private void LateUpdate()
    {
        targetPosition = origin - difference;
        targetPosition = GetCameraBounds();
    }

    private Vector3 GetCameraBounds()
    {
        return new Vector3(
            Mathf.Clamp(targetPosition.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(targetPosition.y, cameraBounds.min.y, cameraBounds.max.y),
            transform.position.z
            );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
