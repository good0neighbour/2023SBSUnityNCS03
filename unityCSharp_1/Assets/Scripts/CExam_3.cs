using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ��ó���� ������ preprocessor directive

        �ڵ��� Ư�� ������ ����
        �߰����� ������ �����Ϸ����� �����Ѵ�

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


        //���Ǻ� ������
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
