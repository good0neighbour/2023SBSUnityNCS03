/*
    PlayerPrefsŬ����

    ����Ƽ���� �����ϴ�
    �÷��� ������ '����', '�ҷ�����' ( save, load ) ���
    ���� Ŭ����

    <--�߻�ȭ�� ���·� ��ũ�� save, load ��� ������ �Ѵ�.
    <--local file ����̴�.
    <--���� �����͸� ������ �� �ִ�.


    int, float, string Ÿ���� ������� ����� �غ�Ǿ� �ִ�.
    ������ �����Ǵ� setter, getter�Լ��� ���õǾ��ִ�.


    'Ű:�� key:value ��'�� ������ �������� �����͸� �ٷ��.

*/

/*
����
    SortedDictionary: '����Ž��Ʈ�� �ڷᱸ��'�� �÷������� ����� ���� ���̴�.
    Dictionary: '�ؽ� �ڷᱸ��'�� �������� ���̴�

    Ű:�� ���� �����͸� ���ҷ� �ٷ��

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLoadSave : MonoBehaviour
{
    //'�÷��� ���� ������'�� ����

    string mPlayerName = "";
    int mLevel = 0;
    int mExp = 0;

    float mPosition = 0.0f;


    private void OnGUI()
    {
        GUIStyle tStyle = new GUIStyle();
        tStyle.fontSize = 36;

        GUI.Label(new Rect(0, 150 + 0, 250, 50), $"�÷��̾� �̸�: {mPlayerName}");
        GUI.Label(new Rect(0, 150 + 50, 250, 50), $"����: {mLevel.ToString()}");
        GUI.Label(new Rect(0, 150 + 100, 250, 50), $"����ġ: {mExp.ToString()}");
        GUI.Label(new Rect(0, 150 + 150, 250, 50), $"��ġ: {mPosition.ToString()}");


        if (GUI.Button(new Rect(0, 0, 150, 50), "NEW"))
        {
            OnClickNew();
        }
        if (GUI.Button(new Rect(0, 50, 150, 50), "SAVE"))
        {
            OnClickSave();
        }
        if (GUI.Button(new Rect(150, 50, 150, 50), "LOAD"))
        {
            OnClickLoad();
        }

        if (GUI.Button(new Rect(0, 100, 150, 50), "Play it"))
        {
            OnPlayit();
        }


        if (GUI.Button(new Rect(150, 100, 150, 50), "test Clear"))
        {
            //����� �����͸� ��� �����.
            //disk
            PlayerPrefs.DeleteAll();

            //memory
            OnClickNew();
        }

    }

    void OnClickNew()
    {
        //�޸𸮿� �ִ� �÷��̰��� �����͸� �ʱ�ȭ�Ͽ� �غ�
        mPlayerName = "";
        mLevel = 0;
        mExp = 0;

        mPosition = 0.0f;
    }

    void OnClickSave()
    {
        //memory ----> disk
        //disk�� ���� ��ִ´�(�����Ѵ�)��� �����̹Ƿ� Setter���
        //  PlayerPrefs�� Ű�� ���ڿ� Ÿ���� ����Ѵ�.
        //  ���⼭�� �ϰ����� ǥ���� ���� ���� �̸��� �����.
        PlayerPrefs.SetString("mPlayerName", mPlayerName);
        PlayerPrefs.SetInt("mLevel", mLevel);
        PlayerPrefs.SetInt("mExp", mExp);
        PlayerPrefs.SetFloat("mPosition", mPosition);


        //��ũ�� ���Ϸ� ���� ���οϷ�<--disk�� ����
        //  : ��ũ�� IO��ġ�� cpu�ٿ������ �ӵ����� �־� �̷��� ����� ����.
        PlayerPrefs.Save();
    }

    void OnClickLoad()
    {
        //disk ----> memory
        //disk�� ���� �о�´�(��´�)��� �����̹Ƿ� Getter���
        //  PlayerPrefs�� Ű�� ���ڿ� Ÿ���� ����Ѵ�.
        //  ���⼭�� �ϰ����� ǥ���� ���� ���� �̸��� �����.
        mPlayerName = PlayerPrefs.GetString("mPlayerName", "");//<--�� ��° �Ű��������� �⺻���� ����.
        //�⺻��: ���Ͽ��� �����͸� ���� ���ϸ� '�⺻��'�� ����
        mLevel = PlayerPrefs.GetInt("mLevel", 0);
        mExp = PlayerPrefs.GetInt("mExp", 0);
        mPosition = PlayerPrefs.GetFloat("mPosition", 0f);
    }
    void OnPlayit()
    {
        //���� �÷��̸� ������
        mPlayerName = "pokpoongryu";

        mExp += 10;
        mLevel = (int)(mExp / 100);

        mPosition += 25f;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
