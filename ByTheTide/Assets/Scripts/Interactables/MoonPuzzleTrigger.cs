using UnityEngine;

public class MoonPuzzleTrigger : MonoBehaviour
{
    public int digit = 1;
    public MoonPuzzleScript moonPuzzle;

    private void OnTriggerEnter(Collider col)
    {
        PlayerPrefs.SetInt("CurIndex", digit);
        moonPuzzle.SetCurIndex(digit);
        moonPuzzle.CheckOrder();
        moonPuzzle.SetPrevIndex(digit);
    }
}
