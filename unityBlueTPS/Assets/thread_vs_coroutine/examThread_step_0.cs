using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������: �����帧�� �ּҴ���
//���μ���: N���� ������ ����
//�������� ����� ���� ū ������
//  ���� ����( ���ÿ� ���� �����帧�� ���� )�� ���� '�����ð��� ���귮'�� ���̷� �ϴ� ���̴�.
/*
    coroutine vs thread

    �� ���� ��������� �������� �ۼ��غ���


    MainThread 1��
        subThread 1��

    �� ���� �ۼ�

*/

using System.Threading; //C#���� �����ϴ� ������ ���� Ŭ������ �Լ��� ����ϱ� ����

public class examThread_step_0 : MonoBehaviour
{
    bool mThreadLoop = false;

    //������ Ŭ����( �����帧�� �ּҴ����� Ŭ������ ����� �غ��ص� ��)
    Thread mThread = null;

    //�̺�Ʈ �Լ��� ��������� �ֽ�����Main Thread��.
    // Start is called before the first frame update
    void Start()
    {
        //5�� �Ŀ� ������ ������ ����
        Invoke("ryuBeginThread", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    //�����带 �����ϴ� �Լ�
    void ryuBeginThread()
    {
        mThreadLoop = true;
        //Dispatch�Լ��� ������ �Լ��� ���, ������ ����
        mThread = new Thread(new ThreadStart(Dispatch));
        mThread.Name = "ryu";
        //������ ���� (������ �����帧 ���� )
        mThread.Start();
    }

    //������ �Լ�( ������ �����帧�� ����ϴ� �Լ� )
    void Dispatch()
    {
        Debug.Log("Dispatch ThreadFunction Start");

        //�ݺ������
        while (mThreadLoop)
        {
            Debug.Log($"Thread is running. {mThread.ManagedThreadId.ToString()}, name: {mThread.Name}");

            Thread.Sleep(5);//������ ��� ��� (5/1000��)
        }

        Debug.Log("Dispatch ThreadFunction End");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Abort Thread"))
        {
            //.NET Framework������ ������ ���� ����, ( ���Ḧ �ݵ�� ���������� �ʴ´� )
            // test �뵵�� ����Ͽ�����, �����δ� �������� �ʴ� �������̴�.
            //( join�� �̿��Ͽ� ��� �����尡 ����Ǿ����� üũ����. )

            //������ ���� ����
            mThread.Abort();
        }
    }

}
