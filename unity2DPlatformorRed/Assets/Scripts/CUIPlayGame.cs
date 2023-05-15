using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using System;   //Action����� ����

public class CUIPlayGame : MonoBehaviour
{
    //static: High Frequency Heap �޸𸮿� ��ġ��Ų��.<--�������� ������ ������
    //Action: ���� �븮��delegate, ���ν��� ����( ���ϰ��� ���� ���� ) <-- vs Function �Լ�����( ���ϰ��� �ִ� ���� )

    //�������� ������ delegate <-- ���� ȣ�� ����, ��ü
    public static Action mAction = null;


    [SerializeField]
    TMPro.TMP_Text mTxtStatus = null;

    // Start is called before the first frame update
    void Start()
    {
        //���� �� Action ��������Ʈ�� ����
        mAction = () =>
        {
            //���ϴ� �Լ� ȣ��
            BuildUI();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //UI������� ������ ���� �Լ�
    public void BuildUI()
    {
        Debug.Log("<color='red'>CUIPlayGame.BuildUI</Color>");

        mTxtStatus.text = "GOOD";
    }
    public void OnClickBtnTest()
    {
        Debug.Log("<color='blue'>CUIPlayGame.OnClickBtnTest</Color>");
    }
}
