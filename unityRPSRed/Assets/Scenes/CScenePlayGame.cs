using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour
{
    ////win: 0 lose: 1 draw: 2
    //int[,] mTableWinLoseDraw = new int[3, 3]
    //{
    //    { 2, 0, 1 },
    //    { 1, 2, 0 },
    //    { 0, 1, 2 },
    //};


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnGUI()
    //{
    //    //가위:0 바위:1 보:2
        
    //    int tPlayerRSP = 0;

    //    int tEnemyRSP = 0;

    //    bool tIsInput = false;

    //    //플레이어의 가위바위보 결정
    //    if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Kai"))
    //    {
    //        tPlayerRSP = 0;

    //        tIsInput = true;
    //    }
    //    if (GUI.Button(new Rect(100f, 0f, 100f, 100f), "Bai"))
    //    {
    //        tPlayerRSP = 1;

    //        tIsInput = true;
    //    }
    //    if (GUI.Button(new Rect(200f, 0f, 100f, 100f), "Bo"))
    //    {
    //        tPlayerRSP = 2;

    //        tIsInput = true;
    //    }

    //    if (tIsInput)
    //    {
    //        //적의 가위바위보 결정
    //        tEnemyRSP = Random.Range(0, 3);
    //        Debug.Log($"player {tPlayerRSP.ToString()}, enemy {tEnemyRSP.ToString()}");

    //        switch (mTableWinLoseDraw[tEnemyRSP, tPlayerRSP])
    //        {
    //            case 0:
    //                {
    //                    Debug.Log("player Win");
    //                }
    //                break;
    //            case 1:
    //                {
    //                    Debug.Log("player Lose");
    //                }
    //                break;
    //            case 2:
    //                {
    //                    Debug.Log("DRAW");
    //                }
    //                break;
    //        }
    //    }

    //}
}
