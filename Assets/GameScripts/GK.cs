using UnityEngine;

public class GK : MonoBehaviour
{
    Animator goalKeeper;
    public int[] Pos;
    public int Move;
    public int index;

    void Start()
    {
        goalKeeper = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(Move == 0)
            Reset();
        if(Move == 1)
            SaveR();
        if(Move == 2)
            SaveL();
    }

    public void GoalMove()
    {
        index = Random.Range(0, Pos.Length);
        Move = Pos[index];
    }

    public void Reset()
    {
        goalKeeper.SetFloat("Save", 0f);
    }

    public void SaveR()
    {
        goalKeeper.SetFloat("Save", 0.5f);
    }

    public void SaveL()
    {
        goalKeeper.SetFloat("Save", 1f);
    }

}
