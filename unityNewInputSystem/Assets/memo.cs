/*

    New Input System


    예전 방식의 Input클래스를 이용한 키입력에 따른 처리 코드

    if (Input.GetKey(KeyCode.UpArrow))
    {
        //임의의 처리
    }
    //<-- 너무 구체적( 키보드가 있다고 가정하고, 위쪽 화살표가 있다고 가정하고 그것에 대한 입력이 있다고 가정하고 )이다.

    //<-- 이러한 코드는 너무 구체적이라서
    //임의의 여러가지 경우를 모두 대비할 수 없다.
    //게다가 소스코드 상에 위치하고 있어 수정이 발생할 수밖에 없다.


    //<-- 보다 일반화한 입력처리 시스템을 만들어놓은 것이 InputSystem이다.

    //다음과 같은 것을 조합하여 짝지어 일반화시킨 것이다.
    //n개 종류의 플랫폼 ---- n개 종류의 입력방식 ------ 임의의 처리
    


*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
