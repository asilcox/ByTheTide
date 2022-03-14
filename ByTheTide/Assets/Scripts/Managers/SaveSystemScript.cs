using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SaveSystemScript : MonoBehaviour
{
    private Vector3 SaveCurPos;
    private Vector3 SaveCurRot;
    private Vector3 HubIslandPos;
    private Vector3 HubIslandRot;

    private CharacterController CC;

    private TextMeshProUGUI LivesText;

    private int Lives;
    private int isDead;

    private int HighLevel;
    private int CurLevel;

    private string curCheckpointName;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Tutorial")
            CurLevel = 0;
        else if (scene.name == "churchysTestLevel")
            CurLevel = 1;
        else if (scene.name == "PhilipLevel2")
            CurLevel = 2;
        CC = GetComponent<CharacterController>();

        Lives = PlayerPrefs.GetInt("Lives");

        GameObject go_HUD = GameObject.Find("livesCounter(PlaceHolder)");
        LivesText = go_HUD.GetComponent<TextMeshProUGUI>();

        if (scene.name != "hub_level")
        {
            if (isDead == 0)
            {
                CC.enabled = false;
                SaveCurPos.x = PlayerPrefs.GetFloat("CurPosX", SaveCurPos.x);
                SaveCurPos.y = PlayerPrefs.GetFloat("CurPosY", SaveCurPos.y);
                SaveCurPos.z = PlayerPrefs.GetFloat("CurPosZ", SaveCurPos.z);

                SaveCurRot.x = PlayerPrefs.GetFloat("CurRotX", SaveCurRot.x);
                SaveCurRot.y = PlayerPrefs.GetFloat("CurRotY", SaveCurRot.y);
                SaveCurRot.z = PlayerPrefs.GetFloat("CurRotZ", SaveCurRot.z);

                curCheckpointName = PlayerPrefs.GetString("curCheckpointName", curCheckpointName);

                GameObject go_CheckPoint = GameObject.Find(curCheckpointName);
                if (go_CheckPoint != null)
                {
                    curCheckPointGO = go_CheckPoint;
                    curCheckPointGO.SetActive(false);
                }

                if ((SaveCurPos.y != 0 && SaveCurPos.x != 0) || (SaveCurPos.z != 0 && SaveCurPos.x != 0) || (SaveCurPos.y != 0 && SaveCurPos.z != 0))
                {
                    gameObject.transform.position = SaveCurPos;
                    gameObject.transform.Rotate(SaveCurRot);
                }
                else
                {
                    SaveCheckPoint();
                }
                CC.enabled = true;
            }
            SaveCheckPoint();
            isDead = 0;

            HighLevel = PlayerPrefs.GetInt("HighLevel");

            if (CurLevel < HighLevel)
                PlayerPrefs.SetInt("HighLevel", HighLevel);
        }
        else
        {
            HubIslandPos.x = PlayerPrefs.GetFloat("HubIslandPosX", HubIslandPos.x);
            HubIslandPos.y = PlayerPrefs.GetFloat("HubIslandPosY", HubIslandPos.y);
            HubIslandPos.z = PlayerPrefs.GetFloat("HubIslandPosZ", HubIslandPos.z);

            HubIslandRot.x = PlayerPrefs.GetFloat("HubIslandRotX", HubIslandRot.x);
            HubIslandRot.y = PlayerPrefs.GetFloat("HubIslandRotY", HubIslandRot.y);
            HubIslandRot.z = PlayerPrefs.GetFloat("HubIslandRotZ", HubIslandRot.z);

            PlayerPrefs.SetFloat("CurPosX", 0);
            PlayerPrefs.SetFloat("CurPosY", 0);
            PlayerPrefs.SetFloat("CurPosZ", 0);

            PlayerPrefs.SetFloat("CurRotX", 0);
            PlayerPrefs.SetFloat("CurRotY", 0);
            PlayerPrefs.SetFloat("CurRotZ", 0);

            PlayerPrefs.SetInt("Lives", 3);
            gameObject.transform.position = HubIslandPos;
            gameObject.transform.Rotate(HubIslandRot);

            curCheckpointName = "";
            PlayerPrefs.SetString("curCheckpointName", curCheckpointName);
        }
        Debug.Log(gameObject.transform.position);
        LivesText.text = Lives.ToString();
    }

    private GameObject curCheckPointGO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            curCheckpointName = other.gameObject.name;
            PlayerPrefs.SetString("curCheckpointName", curCheckpointName);
            GameObject go_CheckPoint = GameObject.Find(curCheckpointName);
            curCheckPointGO = go_CheckPoint;

            SaveCheckPoint();
        }

        if (other.gameObject.tag == "Water")
            Invoke("CheckLives", .75f);

        if (other.gameObject.name == "endTrigger")
            CompletedLevel();
    }

    private void SaveCheckPoint()
    {
        SaveCurPos = transform.position;
        SaveCurRot.x = transform.eulerAngles.x;
        SaveCurRot.y = transform.eulerAngles.y;
        SaveCurRot.z = transform.eulerAngles.z;

        Debug.Log(SaveCurRot);

        PlayerPrefs.SetFloat("CurPosX", SaveCurPos.x);
        PlayerPrefs.SetFloat("CurPosY", SaveCurPos.y);
        PlayerPrefs.SetFloat("CurPosZ", SaveCurPos.z);

        PlayerPrefs.SetFloat("CurRotX", SaveCurRot.x);
        PlayerPrefs.SetFloat("CurRotY", SaveCurRot.y);
        PlayerPrefs.SetFloat("CurRotZ", SaveCurRot.z);

        if (curCheckPointGO != null)
            curCheckPointGO.SetActive(false);
    }

    public void CompletedLevel()
    {
        if (CurLevel == HighLevel)
            HighLevel++;
        else
            return;

        PlayerPrefs.SetInt("HighLevel", HighLevel);
    }

    public void SaveHubLocation()
    {
        HubIslandPos = transform.position;
        HubIslandRot.x = transform.eulerAngles.x;
        HubIslandRot.y = transform.eulerAngles.y;
        HubIslandRot.z = transform.eulerAngles.z;

        PlayerPrefs.SetFloat("HubIslandPosX", HubIslandPos.x);
        PlayerPrefs.SetFloat("HubIslandPosY", HubIslandPos.y);
        PlayerPrefs.SetFloat("HubIslandPosZ", HubIslandPos.z);

        PlayerPrefs.SetFloat("HubIslandRotX", HubIslandRot.x);
        PlayerPrefs.SetFloat("HubIslandRotY", HubIslandRot.y);
        PlayerPrefs.SetFloat("HubIslandRotZ", HubIslandRot.z);
    }

    private void CheckLives()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "hub_level")
        {
            Lives--;
            PlayerPrefs.SetInt("Lives", Lives);
        }

        if (Lives == 0)
        {
            isDead = 1;
            PlayerPrefs.SetFloat("CurPosX", 0);
            PlayerPrefs.SetFloat("CurPosY", 0);
            PlayerPrefs.SetFloat("CurPosZ", 0);

            PlayerPrefs.SetFloat("CurRotX", 0);
            PlayerPrefs.SetFloat("CurRotY", 0);
            PlayerPrefs.SetFloat("CurRotZ", 0);
            GameManager.instance.LoadScene("hub_level");
            PlayerPrefs.SetInt("Lives", 3);
            return;
        }

        SceneManager.LoadScene(scene.name);
    }
}