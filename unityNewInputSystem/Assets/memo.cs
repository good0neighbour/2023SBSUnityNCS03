/*

    New Input System


    ���� ����� InputŬ������ �̿��� Ű�Է¿� ���� ó�� �ڵ�

    if (Input.GetKey(KeyCode.UpArrow))
    {
        //������ ó��
    }
    //<-- �ʹ� ��ü��( Ű���尡 �ִٰ� �����ϰ�, ���� ȭ��ǥ�� �ִٰ� �����ϰ� �װͿ� ���� �Է��� �ִٰ� �����ϰ� )�̴�.

    //<-- �̷��� �ڵ�� �ʹ� ��ü���̶�
    //������ �������� ��츦 ��� ����� �� ����.
    //�Դٰ� �ҽ��ڵ� �� ��ġ�ϰ� �־� ������ �߻��� ���ۿ� ����.


    //<-- �̷��� �������� �ذ��ϱ� ����
        ���� �Ϲ�ȭ�� �Է�ó�� �ý����� �������� ���� InputSystem�̴�.

    //�̸��׸�, ������ ���� ���� �����Ͽ� ¦���� '�Ϲ�ȭ'��Ų ���̴�.
    //n�� ������ �÷��� ---- m�� ������ �Է¹�� ------ ������ ó��






    InputAction�ּ�
        ActionMaps  //<--�׼��� ����
            Actions 0   //<--�׼�: '�߻�ȭ�� �Է�-���� �Է�'�� ��
                : Binding
                    Binding
                    Binding
            Actions 1
                : Binding
            ...
    


    Scheme: '������ �÷����� ������ �Է��� ����'���� ���� 'ī�װ�'�� ��Ű���� ����Ͽ���.

        PlayerInput������Ʈ���� schema�� ���ð����ϴ�.
            <-- �̰��� �ش� ������Ʈ�� � �÷������� ����ǳĿ� ���� �����ϸ� �ȴ�.
                WindowPC <---- controlSchemaWinPC
                Android <---- controlSchemaAndroid
                ...
            <--Any�� �θ� ����Ƽ�� �˾Ƽ� �������ش�.
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
