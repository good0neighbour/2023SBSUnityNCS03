using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/*

만드는 방법:

ScriptableObject를 상속받은 클래스로 스크립트를 작성하고
CreateInstance 함수를 이용하여 메모리에 인스턴스 생성 후
AssetDatabase의 CreateAsset함수를 이용하여 애셋으로 저장하고
Refresh한다.

*/


public class ExamAsset_1 : ScriptableObject//<--상속
{
    public int mTest = 999;

#if UNITY_EDITOR
    [MenuItem("Example/Create ExamAsset_1")]
    static void CreateExamAsset_1()
    {
        var tExamAsset_1 = CreateInstance<ExamAsset_1>();  //메모리에 인스턴스를 하나 만든다

        AssetDatabase.CreateAsset(tExamAsset_1, "Assets/ExamAsset_1.asset");//디스크에 애셋 파일로 저장한다
        AssetDatabase.Refresh();    //애셋데이터베이스 갱신
    }
#endif
}
