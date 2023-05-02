using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrMono : MonoBehaviour
{
    //�����͸� ���������� �����Ѵٰ� ����
    //�� ��ġ �ø��� ���� ����
    public int mScore = 0;

    private static CRyuMgrMono mpInst = null;
    //���� �� �Ҵ��� ���� �ƴϴ�.
    //�����ڿ��� �Ҵ��� �͵� �ƴϴ�.
    //<-- �׷��Ƿ� readonly�� �������� �ʾҴ�.

    //������Ƽ
    public static CRyuMgrMono GetInst
    {
        get
        {
            if (null == mpInst)
            {
                //FindObjectOfType<T>()
                //�ش� Ŭ���� ��ũ��Ʈ ������Ʈ�� ������ ���ӿ�����Ʈ�� �˻��Ͽ� ã�� ���̴�.
                mpInst = FindObjectOfType<CRyuMgrMono>() as CRyuMgrMono;
            }

            return mpInst;
        }
    }

    //���ӿ�����Ʈ�� �����Ǹ� ���� ���� ȣ��Ǵ� �̺�Ʈ �Լ�
    //( MonoVehaviour�� ������ ���� ������ �Ѵٶ�� ���� �ȴ� )
    private void Awake()
    {
        if(null == mpInst)
        {
            mpInst = this;
        }
        else if(null != mpInst)
        {
            //Destroy
            //����Ƽ���� �غ��ص�, ���ӿ�����Ʈ�� �Ҹ� ��Ű�� �Լ�
            Destroy(this.gameObject);
        }

        //DontDestroyOnLoad
        //����Ƽ���� �غ��ص�, ���ӿ�����Ʈ�� ������Ű�� �Լ�( �̸��׸� ��� ��ȯ�ÿ��� �������� �ʰ� ���� )
        DontDestroyOnLoad(this.gameObject);
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