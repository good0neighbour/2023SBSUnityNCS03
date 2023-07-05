using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EditorWindow를 상속받은 클래스는
//유니티 에디터 확장 기능의 일부다.
//그러므로 게임앱에 포함되어 빌드될 수 있다.
//<-- 이 스크립트가 Editor폴더에 위치하지 않으면 빌드 시 에러가 난다.
//  ( 즉, Editor폴더에 위치한 스크립트는 빌드 시 포함되지 않는다 )

//#if UNITY_EDITOR
using UnityEditor;

public class ExamEditorWindow : EditorWindow
{
    
}
//#endif