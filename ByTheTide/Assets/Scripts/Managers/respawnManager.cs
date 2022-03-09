using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    public void resetPlayer(Transform lastObj)
    {
      var newObj = Instantiate(playerPrefab, lastObj.transform);
    }
}
