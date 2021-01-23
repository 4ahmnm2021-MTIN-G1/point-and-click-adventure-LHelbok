using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform thisTransform;
    public Vector3 mousePos;
    public Vector3 worldPos;
    public Vector3 playerPos;
    public float speed = 0.1f;

    public float minScale;
    public float maxScale;
    public float scale;

    public Transform minHeight;
    public Transform maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = thisTransform.position;
    }

    // Update is called once per frame
    void Update()
    {        
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, playerPos, speed);
        float value = Mathf.InverseLerp(minHeight.position.y, maxHeight.position.y, thisTransform.position.y);

        scale = Mathf.Lerp(minScale, maxScale, value);

        Vector3 scaleVector = new Vector3(scale, scale, scale);

        thisTransform.localScale = scaleVector;
    }

    public void SetNewDestination()
    {
        mousePos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        playerPos = new Vector3(worldPos.x, worldPos.y, thisTransform.position.z);
    }
}
