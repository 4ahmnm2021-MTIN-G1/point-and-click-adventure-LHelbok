using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UI;


public class InteractableObject : MonoBehaviour
{
    public GameObject commandMenu;
    public UI_Manager uiManager;
    public Text dialogFenster;
    //public string inspectText;

    public string inactiveText;
    public string[] activeText;
    public string accompText;

    public int gameStatus;

    public Vector3 exitButtonNormal = new Vector3(38, -32,0);
    public Vector3 exitButtonUp = new Vector3(38, -2, 0);
    public Transform exitButton;

    public SpriteRenderer sr;
    public Image img;


    public void SetGameStatus(int paramGameStatus)
    {
        this.gameStatus = paramGameStatus;
    }

    private bool isItemCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        commandMenu.SetActive(false);

    }

    // Update is called once per frame
    private void ExecuteMenu()
    {
        commandMenu.SetActive(true);
        commandMenu.transform.position = transform.position;
        //if (this.gameStatus == 0 | this.gameStatus == 3)
        //{
        //    uiManager.exitButton.transform.position = new Vector3(uiManager.exitButton.transform.position.x, uiManager.exitButton.transform.position.y + 0.5f, uiManager.exitButton.transform.position.z);
        //}

        switch (this.gameStatus)
        {
            case 1:
                //uiManager.exitButton.transform.position = exitButtonNormal;
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Talk";
                break;
            case 2:
                //uiManager.exitButton.transform.position = exitButtonNormal;
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Collect";
                break;
            case 4:
                //uiManager.exitButton.transform.position = exitButtonNormal;
                uiManager.collectButton.SetActive(true);
                //uiManager.collectButtonText.color = new Color(255, 142, 102);
                uiManager.collectButtonText.text = "Light Fuse";
                break;
            case 5:
                //uiManager.exitButton.transform.position = exitButtonNormal;
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Explode";
                break;
            case 6:
                //uiManager.exitButton.transform.position = exitButtonNormal;
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Arrest";
                break;
            default:
                //uiManager.exitButton.transform.position = exitButtonUp;
                uiManager.collectButton.SetActive(false);
                break;
        }
        uiManager.activeIO = this;
    }

    public void OnMouseDown()
    {
        Debug.Log("MouseDown");
        Debug.Log(uiManager.introSequence);
        if (!uiManager.introSequence)
        {
            Debug.Log("In if");

            Debug.Log("Gamestatus" + this.gameStatus + this.tag);
            ExecuteMenu();
            
            uiManager.hoverObjectNames = false;

        }
    }

    public void OnMouseEnter()
    {
        if (uiManager.hoverObjectNames)
        {
            dialogFenster.text = this.gameObject.name;
        }
        
    }
}
