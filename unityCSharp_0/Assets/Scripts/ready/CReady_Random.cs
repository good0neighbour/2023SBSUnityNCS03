using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ����

*/

//MonoBehaviour�� ���
//MonoBehaviour ���ӿ�����Ʈ�� ������ ��ũ��Ʈ ������Ʈ�� �� Ŭ������ ��ӹ޾ƾ� �Ѵ�
public class CReady_Random : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tDice = 0;

        tDice = DoRollDice();

        Debug.Log("DoRollDice: " + tDice.ToString());
    }

    //Update Method(�Լ�) ������ ����� ���̴�
    //  �� �����ӿ� �Ͼ�� ���ӿ�����Ʈ�� ������ �Լ��� ����� ���� ��

    // Update is called once per frame
    void Update()
    {
        
    }

    public int DoRollDice()
    {
        int tResult = 0;
        //UnityEngine�� RandomŬ����
        tResult = Random.Range(1, 6 + 1);

        return tResult;
    }


}
