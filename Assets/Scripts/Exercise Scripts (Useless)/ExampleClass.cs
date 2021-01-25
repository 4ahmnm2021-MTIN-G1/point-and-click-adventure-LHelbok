using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public float controllerFloat;
    public int controllerInt;
    public bool controllerBool;
    public string controllerString;

    public HingeJoint hj;
    public SpriteRenderer sr;
    public GameObject go;
    public AudioSource ao;

    private void Start()
    {
        //Die Float Variable controllerFloat steuert vom Hinge Joint Objekt die Mass Scale
        hj.massScale = controllerFloat;

        //Die Int Variable controllerInt steuert vom Sprite Renderer den Order in Layer
        sr.sortingOrder = controllerInt;

        //Die String Variable controllerString steuert vom Game Objekt den name
        go.name = controllerString;

        //Die String Variable controllerString steuert vom Game Objekt den name, funktioniert auch mit 'this' da die Klasse am Game Objekt direkt dran hängt
        //this.name = controllerString;

        //Die Bool Variable controllerBool steuert von der Audio Source den Loop
        ao.loop = controllerBool;
    }

}
