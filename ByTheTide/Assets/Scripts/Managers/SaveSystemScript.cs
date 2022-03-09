using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class SaveSystemScript : MonoBehaviour
{
    private Vector3 SaveCurPos;
    private Vector3 HubIslandPos;

    private int Lives;
    private int isDead;
    
    private int HighLevel;
    private int CurLevel;

    [SerializeField] private GameObject[] Checkpoints;
    private int CurCheckpoint;
    private string curCheckpointName;


    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        CurLevel = scene.buildIndex;

        Lives = PlayerPrefs.GetInt("Lives");

        if (scene.name != "HubLevel")
        {
            if (isDead == 0)
            {
                SaveCurPos.x = PlayerPrefs.GetFloat("CurPosX", SaveCurPos.x);
                SaveCurPos.y = PlayerPrefs.GetFloat("CurPosY", SaveCurPos.y);
                SaveCurPos.z = PlayerPrefs.GetFloat("CurPosZ", SaveCurPos.z);
            }

            isDead = 0;

            if (SaveCurPos.x != 0 && SaveCurPos.y != 0 && SaveCurPos.z != 0)
            {
                gameObject.transform.position = SaveCurPos;
            }

            HighLevel = PlayerPrefs.GetInt("HighLevel");

            if (CurLevel < HighLevel)
                PlayerPrefs.SetInt("HighLevel", HighLevel);
        }
        else
        {
            HubIslandPos.x = PlayerPrefs.GetFloat("HubIslandPosX", HubIslandPos.x);
            HubIslandPos.y = PlayerPrefs.GetFloat("HubIslandPosY", HubIslandPos.y);
            HubIslandPos.z = PlayerPrefs.GetFloat("HubIslandPosZ", HubIslandPos.z);

            PlayerPrefs.SetInt("Lives", 3);
            gameObject.transform.position = HubIslandPos;

            CurCheckpoint = 0;
            PlayerPrefs.SetInt("curCheckPoint", CurCheckpoint);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            SaveCurPos = gameObject.transform.position;
            curCheckpointName = other.gameObject.name;
            curCheckpointName = Regex.Replace(curCheckpointName, "[^0-9]", "");
            CurCheckpoint = int.Parse(curCheckpointName);
            PlayerPrefs.SetInt("curCheckPoint", CurCheckpoint);
            SaveCheckPoint();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Hazard")
            CheckLives();
    }

    private void SaveCheckPoint()
    {
        PlayerPrefs.SetFloat("CurPosX", SaveCurPos.x);
        PlayerPrefs.SetFloat("CurPosY", SaveCurPos.y);
        PlayerPrefs.SetFloat("CurPosZ", SaveCurPos.z);
    }

    public void SaveHubLocation()
    {
        PlayerPrefs.SetFloat("HubIslandPosX", HubIslandPos.x);
        PlayerPrefs.SetFloat("HubIslandPosY", HubIslandPos.y);
        PlayerPrefs.SetFloat("HubIslandPosZ", HubIslandPos.z);
    }

    private void CheckLives()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "HubLevel")
        {
            Lives--;
            PlayerPrefs.SetInt("Lives", Lives);
        }

        if (Lives < 0)
        {
            isDead = 1;
            PlayerPrefs.SetFloat("CurPosX", 0);
            PlayerPrefs.SetFloat("CurPosY", 0);
            PlayerPrefs.SetFloat("CurPosZ", 0);
            PlayerPrefs.SetInt("Lives", 3);
        }

        SceneManager.LoadScene(CurLevel);
    }
}
