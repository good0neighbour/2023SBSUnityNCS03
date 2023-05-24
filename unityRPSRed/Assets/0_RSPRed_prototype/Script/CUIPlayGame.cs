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

    [SerializeField]
    CUnit[] mUnits = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    void OnAniRSP()
    {
        //가위바위보 동작을 취한다
        foreach (var t in mUnits)
        {
            t.DoAniRSP();
        }

        //대화상자를 닫는다
        this.Hide();
    }

    public void OnClickBtnScissor()
    {
        tPlayerRSP = 0;

        int tEnemyRSP = DecideEnemyRSP();
        DecideWinLoseDraw(tPlayerRSP, tEnemyRSP);

        OnAniRSP();
    }
    public void OnClickBtnRock()
    {
        tPlayerRSP = 1;

        int tEnemyRSP = DecideEnemyRSP();
        DecideWinLoseDraw(tPlayerRSP, tEnemyRSP);

        OnAniRSP();
    }
    public void OnClickBtnPaper()
    {
        tPlayerRSP = 2;

        int tEnemyRSP = DecideEnemyRSP();
        DecideWinLoseDraw(tPlayerRSP, tEnemyRSP);

        OnAniRSP();
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
