using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour
{
    public int orderLayer;
    public SpriteRenderer sr;
    public PlayerMovement pm;

    public void OnMouseDown()
    {
        pm.SetNewDestination();
        sr.sortingOrder = orderLayer;
    }
}
