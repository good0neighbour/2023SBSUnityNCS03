using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReady_Array : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //배열은 '참조 타입'이다
        //그래서 만들어지는 객체는 참조객체라고 한다
        //배열의 선언
        int[] tArray = null;

        //배열의 생성
        //new예약어로 생성, 참조객체는 힙에 만들어진다
        //동적할당한 객체를 해제하는 코드를 쓰지 않아도 된다.
        //garbage collector에 의해 자동수거garbage collection된다.
        tArray = new int[5];
        //인덱스 접근 연산자
        tArray[0] = 4;
        tArray[1] = 0;
        tArray[2] = 1;
        tArray[3] = 2;
        tArray[4] = 3;
        //객체이므로 멤버함수,... 등이 있다. 배열의 크기를 알려주는 것도 있다.
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
