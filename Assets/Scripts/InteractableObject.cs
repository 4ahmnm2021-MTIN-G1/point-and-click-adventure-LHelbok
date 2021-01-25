//using System.Linq.Expressions;
//using System.Net;
using UnityEngine;
using UnityEngine.UI;


public class InteractableObject : MonoBehaviour
{
    public GameObject commandMenu;
    public UI_Manager uiManager;
    public Text dialogFenster;

    public string inactiveText;
    public string[] activeText;
    public string accompText;

    public int gameStatus;

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

        switch (this.gameStatus)
        {
            case 1:
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Talk";
                break;
            case 2:
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Collect";
                break;
            case 4:
                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Light Fuse";
                break;
            case 5:

                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Explode";
                break;
            case 6:

                uiManager.collectButton.SetActive(true);
                uiManager.collectButtonText.text = "Arrest";
                break;
            default:
                uiManager.collectButton.SetActive(false);
                break;
        }
        uiManager.activeIO = this;
    }

    public void OnMouseUp()
    {
        if (!uiManager.introSequence)
        {
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
