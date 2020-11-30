using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public InteractableObject io;
    public Image img;

    public Text dialogFenster;

    public void DecisionExample()
    {
        if (img.sprite == io.sr.sprite)
        {
            dialogFenster.text = "Das Item wurde erfolgreich eingesammelt";
        }
    }
}
