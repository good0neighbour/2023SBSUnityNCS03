using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UGUI�� ����ϱ� ����
using UnityEngine.UI;
//TextMeshPro�� ����ϱ� ����
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
    //����UI���� �Լ�
    public void UpdateScore(int tScore)
    {
        string tString = $"SCORE {tScore.ToString()}";
        mpTxtScore.text = tString;
    }
}
