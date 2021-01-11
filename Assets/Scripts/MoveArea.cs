using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour
{
    public PlayerMovement pm;

    public void OnMouseDown()
    {
        pm.SetNewDestination();
    }
}
