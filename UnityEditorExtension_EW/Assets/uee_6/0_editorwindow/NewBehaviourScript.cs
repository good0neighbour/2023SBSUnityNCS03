using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MonoBehaviour를 상속받은 클래스는
    Editor폴더에 위치하면 베대로 작동하지 않는다( 게임오브젝트의 스크립트 컴포넌트로 사용 불가 )


*/
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //MonoBehaviour를 상속받은 NewBehaviourScript가 Editor폴더 바깥에 있으면
        //Editor폴더 안쪽에 위치한 ExamEditorWindow를 알 수 없다
#if UNITY_EDITOR
        EditorWindow.GetWindow<ExamEditorWindow>(true);
#endif


        //<--dll은 C#에서 중간단계 결과물의 확장자다.(어셈블리)
        //<--빌드 시에 생성되는 Assembly-CSharp.dll에서는 UnityEditor.dll에의 탐조가 발생하지 않기 때문에 빌드 에러가 발생


        /*
            즉, 정리하면

            빌드(개임앱을 만들어내는 것) 결과물에는
            유니티 에디터 확장 윈도우가 포함되면 안됨
            <--Assem

            유니티 에디터 확장을 위한 부분에는
            게임앱을 위한 (이를테면 Mono )기능이 포함되면 안됨
            <--UnityEditor.dll

            즉, 중간결과물의 영역이 다름
        */



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
