using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MonoBehaviour�� ��ӹ��� Ŭ������
    Editor������ ��ġ�ϸ� ����� �۵����� �ʴ´�( ���ӿ�����Ʈ�� ��ũ��Ʈ ������Ʈ�� ��� �Ұ� )


*/
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //MonoBehaviour�� ��ӹ��� NewBehaviourScript�� Editor���� �ٱ��� ������
        //Editor���� ���ʿ� ��ġ�� ExamEditorWindow�� �� �� ����
#if UNITY_EDITOR
        EditorWindow.GetWindow<ExamEditorWindow>(true);
#endif


        //<--dll�� C#���� �߰��ܰ� ������� Ȯ���ڴ�.(�����)
        //<--���� �ÿ� �����Ǵ� Assembly-CSharp.dll������ UnityEditor.dll���� Ž���� �߻����� �ʱ� ������ ���� ������ �߻�


        /*
            ��, �����ϸ�

            ����(���Ӿ��� ������ ��) ���������
            ����Ƽ ������ Ȯ�� �����찡 ���ԵǸ� �ȵ�
            <--Assem

            ����Ƽ ������ Ȯ���� ���� �κп���
            ���Ӿ��� ���� (�̸��׸� Mono )����� ���ԵǸ� �ȵ�
            <--UnityEditor.dll

            ��, �߰�������� ������ �ٸ�
        */



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
