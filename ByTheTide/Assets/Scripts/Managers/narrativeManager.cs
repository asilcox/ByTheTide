using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class narrativeManager : MonoBehaviour
{
    //I am not sure if I am supposed to put anything in this section. Google and my brain are failing me. JG
    [SerializeField] GameObject narrativePannel;
    [SerializeField] public playerGameStates currentState;  //The current state of the enum
    [SerializeField] string[] dialogues; //Dialogue
    [SerializeField] int dialogueIndex; //Identifies which dialogue in the array we want to access
    [SerializeField] TextMeshProUGUI dialogueTextObj; //The text object to be assigned in engine
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case playerGameStates.inPlay:
                {
                    narrativePannel.gameObject.SetActive(false);
                    dialogueTextObj.gameObject.SetActive(false);
                    break;
                }
            case playerGameStates.textPop:
                {
                    narrativePannel.SetActive(true);
                    dialogueTextObj.gameObject.SetActive(true);
                    dialogueTextObj.text = dialogues[dialogueIndex];
                    break;
                }
        }
    }

   public void updateString()
    {
        if(dialogueIndex == dialogues.Length - 1)
        {
            //Test to see if we have reached the end of our array of strings
        }
        else
        {
            dialogueIndex++; //Increments which array we are accessing
        }
    }


    public enum playerGameStates
    {
        inPlay, //This should be the state the player is in when not interacting with texts
        textPop //Dialogue pops up here
    }
}
