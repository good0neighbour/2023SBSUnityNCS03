using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReady_Array : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�迭�� '���� Ÿ��'�̴�
        //�׷��� ��������� ��ü�� ������ü��� �Ѵ�
        //�迭�� ����
        int[] tArray = null;

        //�迭�� ����
        //new������ ����, ������ü�� ���� ���������
        //�����Ҵ��� ��ü�� �����ϴ� �ڵ带 ���� �ʾƵ� �ȴ�.
        //garbage collector�� ���� �ڵ�����garbage collection�ȴ�.
        tArray = new int[5];
        //�ε��� ���� ������
        tArray[0] = 4;
        tArray[1] = 0;
        tArray[2] = 1;
        tArray[3] = 2;
        tArray[4] = 3;
        //��ü�̹Ƿ� ����Լ�,... ���� �ִ�. �迭�� ũ�⸦ �˷��ִ� �͵� �ִ�.
        for (int ti = 0; ti < tArray.Length; ++ti)
        {
            Debug.Log(tArray[ti].ToString());
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
