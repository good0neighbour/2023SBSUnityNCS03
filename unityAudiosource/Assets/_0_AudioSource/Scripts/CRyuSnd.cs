using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuSnd : MonoBehaviour
{
    private void Awake()
    {
        //AudioSource������Ʈ�� �����Ͽ� ���

        //N���� AudioSource������Ʈ�� ����
        AudioSource[]tASs = GetComponents<AudioSource>();
        foreach (var t in tASs)
        {
            //AudioSource������Ʈ�� ���
            CRyuSndMgr.GetInst().DoRegist(t);
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        //AudioSource������Ʈ���� ������ �÷��̿� ���� ����� �����Ѵ�
        //GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
