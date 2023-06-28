using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Gizmo �����: ���� ���۽� ����ϴ�( �ð���, �������� ������ �ִ� ) �ΰ����� ��ü
    <-- �ð��� ������� ���信�� �� �� �ְ� ���ִ� �ΰ����� ������.


    ���⼭�� ������ ���캸�Ҵ� ������ �ٽ� �ѹ� ��������.
*/

public class testGizmo_0 : MonoBehaviour
{

    //MonoBehaviour�� �غ�� ������ ���� �̺�Ʈ �Լ��� �ִ�.
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 1f);//�����//<--[0, 1]�� ����ȭ
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.2f);
        //localScale: ������ǥ�� �� ������
        //lossyScale: ������ǥ�� �� ������

        //Gizmos.color = new Color32(255, 255, 0, 255); //8��Ʈ�� �� ������ ��Ÿ����. �� [0, 255]
        //Gizmos.DrawWireSphere(this.transform.position, 1.2f);
    }
    //MonoBehaviur�� �غ�� ������ ���� �̺�Ʈ �Լ��� �ִ�.
    //���� �� ����� ����
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
