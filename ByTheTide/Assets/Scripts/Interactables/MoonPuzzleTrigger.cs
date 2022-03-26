using UnityEngine;

public class MoonPuzzleTrigger : MonoBehaviour
{
    public int digit = 1;
    public MoonPuzzleScript moonPuzzle;
    private GameObject ParticleEffect;

    private void OnTriggerEnter(Collider col)
    {
        PlayerPrefs.SetInt("CurIndex", digit);
        moonPuzzle.SetCurIndex(digit);
        moonPuzzle.CheckOrder();
        moonPuzzle.SetPrevIndex(digit);
        Instantiate(Resources.Load ( "PuzzleEffect" ), transform.position, transform.rotation);
    }
}
