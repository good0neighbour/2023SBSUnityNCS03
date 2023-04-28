/*
    ���

    const vs readonly


    ������ Ÿ�� ���
        const������ �����.

        <-- ������ ������ ����� ��ü�ȴ�.

        ��) ����� ������, enum, null, ���ڿ�( ""�� ����� �� )

    ��Ÿ�� ���
        readonly������ �����.

        i)��Ÿ�ӿ� �����ڿ��� �ʱ�ȭ�� �����ϴ�.
            ( ������ Ÿ�� ����� ������ �ÿ� ��� ������ ��ü�ǹǷ� �׷� �� ����. ������ �� ���ȭ ǥ���� ���� )
        ii) � Ÿ�԰��� ��� �����ϴ�
            ( ������ Ÿ�� ����� ������ �ÿ� ���� �����Ǿ�� �ϹǷ� �̸� ������� ������ �� �ִ� Ÿ���� ��쿡�� �����ϴ� )
        iii) �ν��Ͻ����� �ٸ� ���� ���� ���� �ִ�.
            ( �����ڿ��� ��쿡 ���� �ٸ��� �Է¹޾� �ʱ�ȭ ����, �� ���Ŀ��� ���� �Ұ� )

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_6 : MonoBehaviour
{
    //������ Ÿ�� ��� <--const����� ���
    public const int mConstInt = 777;
    //�� Ÿ�� ��� <--readonly����� ���
    public readonly int mReadonlyInt = 999;


    CExam_6(int tReadonlyInt)
    {
        //mConstInt = tReadonlyInt;   //<-- ������ ����� �ȵ�.
        mReadonlyInt = tReadonlyInt;    //<-- ��Ÿ�� ����� �����ڿ��� �ʱ�ȭ ����
    }

    // Start is called before the first frame update
    void Start()
    {
        //mConstInt = 7;    <--�ȵ�
        Debug.Log($"const {mConstInt.ToString()}");

        //mReadonlyInt = 9; <--�ȵ�
        Debug.Log($"readonly {mReadonlyInt.ToString()}");



        //������ Ÿ�� ����� ������ �޼ҵ�(�Լ�)�ȿ��� ���� ����
        const float tGravity = 9.8f;
        //��Ÿ�� ����� ������ �޼ҵ�(�Լ�)�ȿ��� ����Ұ�
        //readonly float tGRAVITY = 9.8f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
