using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    coroutine
    co + routine ���� + ����

    ������(��������)�� �ƴ�����
    �������� ������ ����ϴ� �����̴�.( ������ ���������� �ƴϴ�. �׷��� ���̱⸸ �Ѵ�. )

    �ۼ������ �����ϰ� ������� �ִ�.
*/
public class examCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ryuBeginCoroutine", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    void ryuBeginCoroutine()
    {
        StartCoroutine(OnExamDoit());
    }

    //step_0
    /*
    IEnumerator OnExamDoit()    //<-- StartCoroutine�� ���� �Լ� ȣ��
    {
        Debug.Log("OnExamDoit");

        yield return null;
        //�� �Լ��� ���ǰ� ������ �ʾ����� �ϴ� ���� �帧�� �纸�Ͽ� ����
        //�� ������ �帧�� �� ������ ���� �Ŀ� �ٽ� �� �������� ���ƿ��� ���� �ٽ�
        //( <--yield return �Ŀ� null�� �� ���� �� �����Ӹ��ٶ�� �ǹ̴� )

        Debug.Log("//---OnExamDoit");
    }//������� ���� �ش� �ڷ�ƾ �Լ��� ȣ���� ����
    */

    //step_1
    IEnumerator OnExamDoit()    //<-- StartCoroutine�� ���� �Լ� ȣ��
    {
        //�ݺ�������� ����
        for (; ; )
        {
            Debug.Log("OnExamDoit");

            yield return null;
            //�� �Լ��� ���ǰ� ������ �ʾ����� �ϴ� ���� �帧�� �纸�Ͽ� ����
            //�� ������ �帧�� �� ������ ���� �Ŀ� �ٽ� �� �������� ���ƿ��� ���� �ٽ�
            //( <--yield return �Ŀ� null�� �� ���� �� �����Ӹ��ٶ�� �ǹ̴� )

            Debug.Log("//---OnExamDoit");
        }

    }//������� ���� �ش� �ڷ�ƾ �Լ��� ȣ���� ����
}
