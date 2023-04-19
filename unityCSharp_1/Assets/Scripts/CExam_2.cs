/*
    포인터

    C#에서도 포인터를 사용할 수 있다.
    ( 특수한 경우를 위해 마련되어 있다. 일반적으로는 안 써도 된다 )

*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //'비트맵 데이터'를 수정한다고 가정


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
        //비트맵 수정 가정
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

    //비트맵에 임의의 수정을 가하는 함수라고 가정

    /*
        unsafe

        클래스나 클래스의 멤버 또는 문장 블럭에 unsafe예약어를 붙이면
        해당 범위 안에서는

        포인터 타입을 이용해서
        메모리에 대해 C++스타일 연산을 수행가능하다
    */
    unsafe void DoApplyFilter(int[,] tBitmap)
    {
        //선형적인 전체 크기를 구한다
        int tLength = tBitmap.Length;

        //fixed     managed 객체를 메모리에 고정한다
        /*
            C#에서는 가비지 컬렉터가
            필요없는 메모리를 수거하고
            단편화된 메모리를 정리하는 작업이 수시로 일어난다
            그러므로 fixed하지 않으면 managed객체의 주소값이 수시로 바뀐다
            그러므로 고정해놓고 주소값을 얻어야 한다
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
