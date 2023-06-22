using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���÷���Reflection: ���� �߿� Ÿ�Կ� ���� ������ ��ȸ�� �� �ִ� ���
using System.Reflection;
/*

    attribute����

    �����������( Ŭ����, �������, ����Լ�, ..)�� ����
    '�ΰ����� ����'�� ��Ƶδ� �����̴�.(�̸��׸� Serializable )

    �� ���ô� �� �߿�����
    custom attribute�� ����� ������ ���캸��.




    ����Ƽ �����ʹ�
    ����Ƽ ������ ���ǵ� �Ӽ��� �ؼ��ؼ�
    ����Ƽ �����Ϳ��� ��� ���̴��� ���� �����Ͽ� �����ش�
*/


class CTest
{
    //Doit�Լ��� �ΰ����� ������ CRyuAttribute �Ӽ��� �����Ͽ� �߰��Ͽ���
    [CRyuAttribute("strength", _Value = "1004")]
    public void Doit()
    {
        Debug.Log("CTest.Doit");
    }
}

//System.Attribute Ŭ������ ��ӹ޾�
//����� ���� attribute�� �����
class CRyuAttribute: System.Attribute
{
    string mString = "";
    string mValue = "";

    //�Ű����� �ִ� ������
    public CRyuAttribute(string tString)
    {
        mString = tString;
    }
    //������Ƽ
    public string _Value
    {
        get
        {
            return $"{mString} : {mValue}";
        }
        set
        {
            mValue = value;
        }
    }
}




public class examCustomAttribute : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        CTest tTest = new CTest();
        tTest.Doit();

        //typeof ������ : Ÿ�Կ� ���� ������ ��ȸ�� �� �ִ� ������
        //              <--���÷��� ��� �߿� �ϳ���
        //���� �߿�, �Լ� �������� ����
        MethodInfo[] tArray = typeof(CTest).GetMethods();

        foreach (var t in tArray)
        {
            Debug.Log(t);
            //�Լ��� �ΰ����� ��������� �Ӽ� ������ ǥ��
            object[] tObjects = t.GetCustomAttributes(false);
            foreach (CRyuAttribute tObject in tObjects)
            {
                Debug.Log(tObject._Value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
