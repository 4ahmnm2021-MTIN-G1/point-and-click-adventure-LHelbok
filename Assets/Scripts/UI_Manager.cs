//using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public InteractableObject activeIO;
    public Text dialogFenster;

    public Text collectButtonText;
    public GameObject collectButton;

    public GameObject exitButton;

    public GameObject rantanplanStartButton;
    public GameObject jollyStartButton;

    public GameObject explosionRock;
    public GameObject rock;
    public GameObject joeDalton;

    public Text leatherBoardTextField;
    private string leatherBoardText;
    public GameObject leatherBoard;

    float timer = 0.0f;
    bool timerEnabled = false;

    bool isRopeCollected = false;

    public bool introSequence;
    private bool joeArrested;

    public bool hoverObjectNames;

    public CameraShake camShake;

    public GameObject player;
    public GameObject sleepingLuke;

    public AudioSource lightMatch;

    public AudioSource winVoice;
    public AudioSource loseVoice;

    public void DisplayText()
    {
        switch (activeIO.gameStatus)
        {
            case 0: //Inactive
                dialogFenster.text = activeIO.inactiveText;
                break;
            case 1: //Talk
                int randomNumber = Random.Range(0, 3);
                dialogFenster.text = activeIO.activeText[randomNumber];
                break;
            case 2: //Collect
                dialogFenster.text = "Sammle das Item mit 'Collect' ein.";
                break;
            case 3: //Accomplished
                dialogFenster.text = activeIO.accompText;
                break;
            case 4: //Light Fuse
                dialogFenster.text = "Zünde deine Dynamitstange mit 'Light Fuse' an.";
                break;
            case 5: //Explode Rock
                dialogFenster.text = "Sprenge den Felsen mit 'Explode'.";
                break;
            case 6: // Arrest Joe
                dialogFenster.text = "Nehme Joe mit 'Arrest' fest.";
                break;
            case 7: //Clue
                dialogFenster.text = "Die Spuren können dir helfen";
                break;
            default: //Error
                dialogFenster.text = "ungültiger Zustand";
                break;
        }
    }

    public void Start()
    {
        rock.SetActive(true);
        explosionRock.SetActive(false);
        leatherBoardText = " Hallo Lucky Luke! \n" +
            " Joe Dalton ist aus dem Gefängnis ausgebrochen! \n" +
            " Fange ihn wieder ein. \n" +
            " Mit `Inspect` siehst du was du mit Objekten machen kannst \n " +
            "Mit ‚Talk‘ sprichst du mit den anderen Charakteren\n " +
            "Mit ‚Collect‘ sammelst du Items ein \n " +
            "Viel Glück! \n";
        ExecuteLeatherBoard(leatherBoardText);
        GameObject.FindWithTag("Feuer").GetComponent<InteractableObject>().SetGameStatus(0);
        GameObject.FindWithTag("Joe").GetComponent<InteractableObject>().SetGameStatus(0);
        GameObject.FindWithTag("Jolly").GetComponent<InteractableObject>().SetGameStatus(0);
        GameObject.FindWithTag("Fels").GetComponent<InteractableObject>().SetGameStatus(0);
        GameObject.FindWithTag("Rantanplan").GetComponent<InteractableObject>().SetGameStatus(1);
        GameObject.FindWithTag("Kaktus").GetComponent<InteractableObject>().img.sprite = null;
        GameObject.FindWithTag("Feuer").GetComponent<InteractableObject>().img.sprite = null;
        player.SetActive(false);
        sleepingLuke.SetActive(true);
        joeDalton.SetActive(false);
        joeArrested = false;
        isRopeCollected = false;
        timer = 0.0f;
        hoverObjectNames = false;
        dialogFenster.text = "";


    }

    public void executeHoverNames(bool paramHoverName)
    {
        hoverObjectNames = paramHoverName;
    }

    public void ExecuteLeatherBoard(string displayText)
    {
        player.SetActive(false);
        leatherBoardTextField.text = displayText;
        leatherBoard.SetActive(true);
        introSequence = true;
        sleepingLuke.SetActive(false);
        dialogFenster.text = "";
    }

    public void DeactiveLeatherBoard()
    {
        player.SetActive(true);
        leatherBoard.SetActive(false);
        introSequence = false;
        hoverObjectNames = true;
        sleepingLuke.SetActive(true);
        sleepingLuke.SetActive(false);
        dialogFenster.text = "";
        if (joeArrested) // Joe ist verhaftet
        {
            Start();
        }

    }

    public void Exit()
    {
        dialogFenster.text = "";
        hoverObjectNames = true;
    }

    public void CollectItem()
    {
        activeIO.img.sprite = activeIO.sr.sprite;
        dialogFenster.text = "Das Item wurde erfolgreich eingesammelt";
        //activeIO.isItemCollected = true;
    }

    private void Update()
    {
        if (timerEnabled)
        {
            timer += Time.deltaTime;
            if (timer > 0.8f)
            {
                explosionRock.SetActive(false);
                timerEnabled = false;
            }
        }
    }


    public void TalkOrCollect()
    {
        if (activeIO.gameStatus == 1 && activeIO.gameObject.tag == "Rantanplan") // Talk
        {
            dialogFenster.text = "Was möchtest du wissen, Lucky Luke?";
            rantanplanStartButton.SetActive(true);
            activeIO.commandMenu.SetActive(false);
        }
        if (activeIO.gameStatus == 1 && activeIO.gameObject.tag == "Jolly") // Talk
        {
            dialogFenster.text = "Na Lucky Luke, was gibt's?";
            jollyStartButton.SetActive(true);
            activeIO.commandMenu.SetActive(false);
        }
        if (activeIO.gameStatus == 2 && activeIO.gameObject.tag == "Kaktus") // Collect
        {
            dialogFenster.text = "Objekt erfolgreich eingesammelt";
            activeIO.img.sprite = activeIO.sr.sprite;
            activeIO.gameStatus = 3;
            isRopeCollected = true;
        }

        if (activeIO.gameStatus == 2 && activeIO.gameObject.tag == "Jolly") // Collect
        {
            dialogFenster.text = "Objekt erfolgreich eingesammelt";
            activeIO.img.sprite = activeIO.sr.sprite;
            activeIO.gameStatus = 3;

            //Setzt den Status des Lagerfeuers auf Status 4 -> Schaltet den Button anzünden frei
            GameObject.FindWithTag("Feuer").GetComponent<InteractableObject>().SetGameStatus(4);
        }

        if (activeIO.gameStatus == 4 && activeIO.gameObject.tag == "Feuer") // Collect
        {
            dialogFenster.text = "Dynamitstange erfolgreich angezündet";
            activeIO.img.sprite = activeIO.sr.sprite;
            lightMatch.Play();
            activeIO.gameStatus = 3;

            GameObject.FindWithTag("Fels").GetComponent<InteractableObject>().SetGameStatus(5);
        }
        if (activeIO.gameStatus == 5 && activeIO.gameObject.tag == "Fels") // Collect
        {
            dialogFenster.text = "Fels erfolgreich gesprengt";
            activeIO.gameStatus = 3;
            rock.SetActive(false);
            explosionRock.SetActive(true);
            camShake.ShakeIt();
            activeIO.commandMenu.SetActive(false);
            joeDalton.SetActive(true);
            timerEnabled = true;
            GameObject.FindWithTag("Kaktus").GetComponent<InteractableObject>().SetGameStatus(0);
            GameObject.FindWithTag("Joe").GetComponent<InteractableObject>().SetGameStatus(6);
            GameObject.FindWithTag("Feuer").GetComponent<InteractableObject>().img.sprite = null;
        }
        if (activeIO.gameStatus == 6 && activeIO.gameObject.tag == "Joe") // Arrest
        {
            joeArrested = true;
            if (isRopeCollected)
            {
                activeIO.commandMenu.SetActive(false);
                leatherBoardText = "Super, du hast Joe Dalton eingefangen! \n\n Du hast das Spiel gewonnen!"; //Text wenn der Spieler gewonnen hat
                ExecuteLeatherBoard(leatherBoardText);
                hoverObjectNames = false;
                GameObject.FindWithTag("Kaktus").GetComponent<InteractableObject>().img.sprite = null;
                winVoice.Play();
            }
            else
            {
                activeIO.commandMenu.SetActive(false);
                leatherBoardText = "Du hast verloren! \n\n Du hast kein Seil um Joe festzunehmen!"; //Text wenn der Spieler verloren hat
                ExecuteLeatherBoard(leatherBoardText);
                hoverObjectNames = false;
                loseVoice.Play();
            }
           
        
        }
    }
}
