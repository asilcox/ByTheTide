using UnityEngine;

public class MoonPuzzleScript : MonoBehaviour
{
    private int prevIndex = 0;
    private int curIndex = 0;
    private int SaveIndex;

    public TideScript tide;
    
    public int GetPrevIndex() { return prevIndex; }
    public int GetCurIndex() { return curIndex; }

    public void SetPrevIndex(int i) { prevIndex = i; }
    public void SetCurIndex(int i) { curIndex = i; }

    private void Start()
    {
        curIndex = PlayerPrefs.GetInt("CurIndex");
        Debug.Log("totals = " + (curIndex - prevIndex));
        if (curIndex != 0)
        {
            prevIndex = curIndex - 1;
            CheckOrder();
        }
    }

    public void CheckOrder()
    {
        Debug.Log("totals = " + (curIndex - prevIndex));

        if (curIndex - prevIndex != 1)
            tide.SetHighTide(true);
        else
            Debug.Log("CorrectAnswer " + curIndex);
    }
}
