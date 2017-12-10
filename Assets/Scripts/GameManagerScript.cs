using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject[] scrambled, solved;
    private int held = -1, score = 0;
    private bool[] partSolvedStatus = { false, false, false, false, false, false, false, false, false, false, false, false };
    
    public void CheckSolvedPart(int index)
    {
        if (index == held && !partSolvedStatus[index])
        {
            partSolvedStatus[index] = true;
            scrambled[index].GetComponent<MeshRenderer>().enabled = false;
            solved[index].GetComponent<MeshRenderer>().enabled = true;
            if(++score >= 12)
            {
                EndGame();
            }
        }
    }

    public void SetHeld(int index)
    {
        held = index;
    }

    public void Unhold()
    {
        held = -1;
    }

    private void EndGame()
    {
        Debug.Log("END!!!");
    }
}
