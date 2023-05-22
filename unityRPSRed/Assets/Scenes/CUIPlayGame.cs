using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    //win: 0 lose: 1 draw: 2
    int[,] mTableWinLoseDraw = new int[3, 3]
    {
        { 2, 0, 1 },
        { 1, 2, 0 },
        { 0, 1, 2 },
    };

    int tPlayerRSP = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBtnScissor()
    {
        tPlayerRSP = 0;

        int tEnemyRSP = DecideEnemyRSP();
        DecideWinLoseDraw(tPlayerRSP, tEnemyRSP);
    }
    public void OnClickBtnRock()
    {
        tPlayerRSP = 1;

        int tEnemyRSP = DecideEnemyRSP();
        DecideWinLoseDraw(tPlayerRSP, tEnemyRSP);
    }
    public void OnClickBtnPaper()
    {
        tPlayerRSP = 2;

        int tEnemyRSP = DecideEnemyRSP();
        DecideWinLoseDraw(tPlayerRSP, tEnemyRSP);
    }

    int DecideEnemyRSP()
    {
        int tResult = 0;

        tResult = Random.Range(0, 3);
        Debug.Log($"player {tPlayerRSP.ToString()}, enemy {tResult.ToString()}");

        return tResult;
    }

    void DecideWinLoseDraw(int tP_RSP, int tE_RSP)
    {
        switch (mTableWinLoseDraw[tE_RSP, tP_RSP])
        {
            case 0:
                {
                    Debug.Log("player Win");
                }
                break;
            case 1:
                {
                    Debug.Log("player Lose");
                }
                break;
            case 2:
                {
                    Debug.Log("DRAW");
                }
                break;
        }
    }
}
