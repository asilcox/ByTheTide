using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class narrativeManager : MonoBehaviour
{
    [SerializeField] playerGameStates currentState; //The current state of the enum
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
                    //Should deactivate text here
                    break;
                }
            case playerGameStates.textPop:
                {
                    //display text here
                    break;
                }
        }
    }

    void updateString()
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "narrative")
        {
            //we just stepped into an area with narrative! Lets activate the text box and ensure we have the proper string index
        }
    }

    public enum playerGameStates
    {
        inPlay, //This should be the state the player is in when not interacting with texts
        textPop //Dialogue pops up here
    }
}
