/*
    '�̱��� ����'�� �����غ���
    singleton pattern
    <-- ��ü�� �ִ� ���������� 1���� �����ϴ� ���� ������ ����

    ���� ������ ù ��° ����


    i) mpInst�� static�� �����Ѵ�
    ii) �����ڴ� public�� �ƴϴ�
    iii)GetInst �Լ� �ȿ��� ��ü�� 1���� ���������ϴ� �Ǵ� ������ �����Ѵ�
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgr
{
    private static CRyuMgr mpInst = null;

    //������ ���� ����( �� ���⼭�� �����ϰ� �ϱ� ���� �̹����� ���ؼ��� �����Ѵ� )
    //  Sprite: UI�� Unity2D���� ��밡���ϵ��� ����Ƽ���� �з��Ͽ� �������� Texture ����
    public Sprite[] mSprites = null;



    //�κ��丮 ���� ( ȹ�� ������ ��� ���� )
    public List<CItemInfo> mInventory = new List<CItemInfo>();

    
    public void CreateRyu()
    {
        //ResourcesŬ������
        //Ư�� ������ Resources������ �Բ� ����Ѵ�.
        //'����'�� '�ּ�'�� ��ũ��Ʈ �󿡼� '�޸�'�� '�ν��Ͻ�'�� �ε��ϴ� ���̴�.
        mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }

    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }
    //1���� �ν��Ͻ�ȭ�Ѵ�
    public static CRyuMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CRyuMgr();
        }

        return mpInst;
    }
}


/*
    C#���� ��ü ���� �ܰ�

    ������ Ÿ������
    'ù ��°' �ν��Ͻ�'�� ������ ��
    ����Ǵ� ������ ������ ����.

    �������� �ܰ�

        i) ���� ������ �������(�޸�)�� 0���� �ʱ�ȭ
        ii) ���� ������ ���� �ʱ�ȭ ������ ����

        iii) ���� ������ ����
            ���࿡ ��Ӱ�����
            ��) ���̽� Ŭ������ ���� ������ ����
            ��) �ڽ��� ���� ������ ����

    ============
    �ν��Ͻ� ���� �ܰ�

        i) �ν��Ͻ� ������ �������(�޸�)�� 0���� �ʱ�ȭ
        ii) �ν��Ͻ� ������ ���� �ʱ�ȭ ������ ����

        iii) �ν��Ͻ� ������ ����
            ���࿡ ��Ӱ�����
            ��) ���̽� Ŭ������ �ν��Ͻ� ������ ����
            ��) �ڽ��� �ν��Ͻ� ������ ����

*/