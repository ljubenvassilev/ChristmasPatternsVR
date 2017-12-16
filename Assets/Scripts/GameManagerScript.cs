using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public GameObject[] scrambled, solved;
    public GameObject start, retry, reset, tree, scrambledTree, solvedTree, timer;
    private int held = -1, score;
    private bool[] partSolvedStatus;
    private Vector3[] initialPositions;
    private float startTime, max = 120;
    
    void Start()
    {
        initialPositions = new Vector3[12];
    }

    void Update()
    {
        if (timer.activeInHierarchy)
        {
            float rem = max - (Time.time - startTime);
            string remaining = rem.ToString("f0");
            timer.GetComponent<TextMesh>().text = remaining;
            if (rem < 1)
            {
                retry.SetActive(true);
                EndGame();
            }
        }
    }

    public void CheckSolvedPart(int index)
    {
        if (index == held && !partSolvedStatus[index])
        {
            partSolvedStatus[index] = true;
            scrambled[held].GetComponent<DDObject>().HandleGazeTriggerEnd();
            scrambled[index].GetComponent<MeshRenderer>().enabled = false;
            solved[index].GetComponent<MeshRenderer>().enabled = true;
            max += 5;
            if(++score >= 12)
            {
                reset.SetActive(true);
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
        for(int i = 0; i <= 11; i++)
        {
            scrambled[i].transform.position = initialPositions[i];
            scrambled[i].GetComponent<MeshRenderer>().enabled = true;
            solved[i].GetComponent<MeshRenderer>().enabled = false;
        }        
        scrambledTree.SetActive(false);
        solvedTree.SetActive(false);
        tree.SetActive(false);
        timer.SetActive(false);
    }

    public void StartGame()
    {
        start.SetActive(false);
        reset.SetActive(false);
        retry.SetActive(false);
        scrambledTree.SetActive(true);
        solvedTree.SetActive(true);
        tree.SetActive(true);
        for (int i = 0; i <= 11; i++)
        {
            initialPositions[i] = scrambled[i].transform.position;
        }
        startTime = Time.time;
        partSolvedStatus = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false };
        score = 0;
        max = 120;
        timer.SetActive(true);
    }
}
