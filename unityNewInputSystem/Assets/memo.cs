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


    //<-- 이러한 문제점을 해결하기 위해
        보다 일반화한 입력처리 시스템을 만들어놓은 것이 InputSystem이다.

    //이를테면, 다음과 같은 것을 조합하여 짝지어 '일반화'시킨 것이다.
    //n개 종류의 플랫폼 ---- m개 종류의 입력방식 ------ 임의의 처리






    InputAction애셋
        ActionMaps  //<--액션의 집합
            Actions 0   //<--액션: '추상화된 입력-실제 입력'의 쌍
                : Binding
                    Binding
                    Binding
            Actions 1
                : Binding
            ...
    


    Scheme: '임의의 플랫폼에 임의의 입력을 조합'시켜 놓은 '카테고리'를 스키마로 명명하였다.

        PlayerInput컴포넌트에서 schema를 선택가능하다.
            <-- 이것은 해당 프로젝트가 어떤 플랫폼으로 빌드되냐에 따라 선택하면 된다.
                WindowPC <---- controlSchemaWinPC
                Android <---- controlSchemaAndroid
                ...
            <--Any로 두면 유니티가 알아서 선택해준다.
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
