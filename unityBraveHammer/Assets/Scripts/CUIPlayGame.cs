using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UGUI를 사용하기 위해
using UnityEngine.UI;
//TextMeshPro를 사용하기 위해
using TMPro;

public class CUIPlayGame : MonoBehaviour
{
    public TMPro.TMP_Text mpTxtScore = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //점수UI갱신 함수
    public void UpdateScore(int tScore)
    {
        string tString = $"SCORE {tScore.ToString()}";
        mpTxtScore.text = tString;
    }
}
