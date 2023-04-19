using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    전처리기 지시자 preprocessor directive

        코드의 특정 영역에 대한
        추가적인 정보를 컴파일러에게 제공한다

*/

public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#region EXAM_REGION
        int tA = 0;
        int tB = 0;
        #endregion


        //조건부 컴파일
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
#endif

#if UNITY_STANDALONE_WIN
        Debug.Log("Unity StandaloneWin");
#endif

#if UNITY_ANDROID
        Debug.Log("Unity Android");
#endif


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
