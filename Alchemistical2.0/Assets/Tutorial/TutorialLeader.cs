using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLeader : MonoBehaviour
{
    public int tPoint;

    public GameObject tStart;

    public List<TutorialField> tList;

    public float startTime = 10;
    private bool startBool = true;

    private void Update()
    {
        if (startBool)
        {
            startTime -= Time.deltaTime;

            if ( startTime <= 0)
            {
                Time.timeScale = 0.2f;
                startBool = false;
                tStart.SetActive(true);
            }
        }
    }

    public void Skip()
    {
        tStart.SetActive(false);
        Time.timeScale = 1;
    }

    public void TStart()
    {
        tStart.SetActive(false);

        foreach(TutorialField TF in tList)
        {
            //TF.UIElement.SetActive(false);
        }

        tList[0].gameObject.SetActive(true);
        tList[0].PointOut();
    }

    public void NextTPoint()
    {
        tList[tPoint].HideOut();
        tPoint++;
        if ( tPoint == tList.Count)
        {
            Debug.Log("start game");
            Time.timeScale = 1;
        }
        tList[tPoint].gameObject.SetActive(true);
        tList[tPoint].PointOut();
    }
}
