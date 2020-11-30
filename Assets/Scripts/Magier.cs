using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magier : MonoBehaviour
{
    public string nameOfCharacter = "Sarah";
    public int ageOfCharacter = 20;
    public float sizeOfCharacter = 1.6f;
    public bool isWearingGlasses = false;

    public Camera cam;
    public GameObject go;
    public BoxCollider box;
    public Rigidbody rb;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        nameOfCharacter = "Elyra";
        ageOfCharacter = 295;
        sizeOfCharacter = 1.85f;
        isWearingGlasses = true;

        cam.farClipPlane = 20;
        go.name = "Hello";
        box.isTrigger = true;
        rb.useGravity = false;
        rb.mass = 80;
        text.text = "Lea Helbok";
        text.fontSize = 23;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
