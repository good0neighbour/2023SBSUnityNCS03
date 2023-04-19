/*
    ������

    C#������ �����͸� ����� �� �ִ�.
    ( Ư���� ��츦 ���� ���õǾ� �ִ�. �Ϲ������δ� �� �ᵵ �ȴ� )

*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //'��Ʈ�� ������'�� �����Ѵٰ� ����


        int[,] tBitmap = new int[48, 48];

        //before
        Debug.Log("=====Bitmap before");
        for (int tRow = 0; tRow < tBitmap.GetLength(0); ++tRow)
        {
            for (int tCol = 0; tCol < tBitmap.GetLength(0); ++tCol)
            {
                Debug.Log(tBitmap[tRow, tCol].ToString());
            }
        }

        #region RAW_POINTER_FUNC
        //��Ʈ�� ���� ����
        DoApplyFilter(tBitmap);
        #endregion

        //after
        Debug.Log("=====Bitmap after");
        for (int tRow = 0; tRow < tBitmap.GetLength(0); ++tRow)
        {
            for (int tCol = 0; tCol < tBitmap.GetLength(0); ++tCol)
            {
                Debug.Log(tBitmap[tRow, tCol].ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //��Ʈ�ʿ� ������ ������ ���ϴ� �Լ���� ����

    /*
        unsafe

        Ŭ������ Ŭ������ ��� �Ǵ� ���� ���� unsafe���� ���̸�
        �ش� ���� �ȿ�����

        ������ Ÿ���� �̿��ؼ�
        �޸𸮿� ���� C++��Ÿ�� ������ ���డ���ϴ�
    */
    unsafe void DoApplyFilter(int[,] tBitmap)
    {
        //�������� ��ü ũ�⸦ ���Ѵ�
        int tLength = tBitmap.Length;

        //fixed     managed ��ü�� �޸𸮿� �����Ѵ�
        /*
            C#������ ������ �÷��Ͱ�
            �ʿ���� �޸𸮸� �����ϰ�
            ����ȭ�� �޸𸮸� �����ϴ� �۾��� ���÷� �Ͼ��
            �׷��Ƿ� fixed���� ������ managed��ü�� �ּҰ��� ���÷� �ٲ��
            �׷��Ƿ� �����س��� �ּҰ��� ���� �Ѵ�
        */
        fixed (int* pBitmap = tBitmap)
        {
            int* tpPtr = pBitmap;

            for (int ti = 0; ti < tLength; ++ti)
            {
                *tpPtr++ &= 0xFF;
            }
        }

    }
}
