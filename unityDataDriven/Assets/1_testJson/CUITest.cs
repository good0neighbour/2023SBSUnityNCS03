using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    JSON JavaScript Object Notation
    ������ �ڹٽ�ũ��Ʈ ���� ������Ʈ ������ ǥ���� �� ���� �����̾���.
    ������ ������ �������� �ؽ�Ʈ ������ ���� �԰��̴�.

    xml�� ��ü�Ѵ�

    �ֿ� ���� ������Ҵ� ������ ����.

    {}      ������Ʈ�� ��Ÿ����
    Ű:��   ������ �����͸� ������
    Ű      �� ���ڿ��̴�. ū����ǥ�� ���Ѵ�
    []      �ſ��� ��Ÿ����.
    ������ �����ʹ� ,�� ����
    �迭�� ���ҵ� ,�� ����


    JSON�԰��� �뼼�� �� ������
    �ؽ�Ʈ ������ �������� ������ ���̳ʸ� ������ �������� �������� �������� ã�ұ� �����̴�.

*/

public class CUITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //json --> ����� ���� Ŭ���� Ÿ���� ��ü
    public void OnClickBtnFromJson()
    {
        //�ҽ��ڵ� ���� ���ڿ� ���·� ���� json�԰��� �ؽ�Ʈ ������
        string tJson = @"{
                ""mName"":""��ǳ��"",
                ""mStringList"":
                [
                    ""weapon_0"",
                    ""weapon_1""
                ],
                ""mLevel"":10,
                ""mExp"":1024
            }";

        //JsonUtility:����Ƽ���� �����ϴ� Json Ŭ����
        //�Ḻ̌��� �� ���ش�.
        CRyuTestInfo tInfo = JsonUtility.FromJson<CRyuTestInfo>(tJson);

        //���
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }
    // ����� ���� Ŭ���� Ÿ���� ��ü --> json
    public void OnClickBtnToJson()
    {
        CRyuTestInfo tInfo = new CRyuTestInfo();
        tInfo.mName = "�˺�����";
        tInfo.mLevel = 7;
        tInfo.mExp = 2048;
        tInfo.mStringList = new List<string>();
        tInfo.mStringList.Add("weapon_777");
        tInfo.mStringList.Add("weapon_999");

        //json������ ����
        string tJson = JsonUtility.ToJson(tInfo);

        //���
        Debug.Log(tJson);
    }

    //Json������ �����
    public void OnClickBtnOverwriteFromJson()
    {
        //������ ������
        string tJson = @"{
                ""mName"":""��ǳ��"",
                ""mStringList"":
                [
                    ""weapon_0"",
                    ""weapon_1""
                ],
                ""mLevel"":10,
                ""mExp"":1024
            }";

        //JsonUtility:����Ƽ���� �����ϴ� Json Ŭ����
        //�Ḻ̌��� �� ���ش�.
        CRyuTestInfo tInfo = JsonUtility.FromJson<CRyuTestInfo>(tJson);

        //���
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }

        //������ �����
        string tJson_1 = @"{
                ""mName"":""�˺�����"",
                ""mStringList"":
                [
                    ""weapon_333"",
                    ""weapon_99""
                ],
                ""mLevel"":7,
                ""mExp"":5000
            }";


        //tInfo�� tJson_1�� �����͸� ������.
        JsonUtility.FromJsonOverwrite(tJson_1, tInfo);

        //���
        Debug.Log("================");
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }
}
