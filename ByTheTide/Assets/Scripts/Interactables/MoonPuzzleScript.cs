using UnityEngine;

public class MoonPuzzleScript : MonoBehaviour
{
    private int prevIndex = 0;
    private int curIndex = 0;

    public TideScript tide;
    
    public int GetPrevIndex() { return prevIndex; }
    public int GetCurIndex() { return curIndex; }

    public void SetPrevIndex(int i) { prevIndex = i; }
    public void SetCurIndex(int i) { curIndex = i; }

    public void CheckOrder()
    {
        if (curIndex - prevIndex != 1)
            tide.SetHighTide(true);
        else
            Debug.Log("CorrectAnswer " + curIndex);
    }
}
