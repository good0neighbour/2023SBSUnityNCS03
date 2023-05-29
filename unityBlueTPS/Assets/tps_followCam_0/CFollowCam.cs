using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCam : MonoBehaviour
{
    [SerializeField]
    GameObject mLookAtObj = null;


    [SerializeField]
    float mDistance = 1.5f; //�Ĺ�Ÿ�
    [SerializeField]
    float mHeight = 1.5f;   //���Ÿ�

    [SerializeField]
    float mDampTrace = 10.0f;    //


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //���� ���ǿ� ����,. ���� ������Ʈ�� ������ �������� ������ �ϴ� �Լ�
    //�ý����� ���ɿ� ���� ȣ�� Ƚ���� ����ȴ�.
    void Update()
    {
        
    }

    //FixedUpdate
    //���� ����� ���� �Լ�
    //���� �������� ȣ��ǹǷ� ȣ��Ƚ���� �����ϴ�

    //��� Update�� ȣ��� ���Ŀ� ȣ��Ǵ� �����Լ���.
    //ī�޶� ��ũ�� ���⼭ ���� ���̴�.
    //�ֳ��ϸ� ī�޶� ������ ������� ���� ���̱� �����̴�.
    private void LateUpdate()
    {
        //������: ���������� ��� ��ŭ ������ �ִ����� ���� ����
        Vector3 tOffset = (-1.0f) * mLookAtObj.transform.forward * mDistance + Vector3.up * mHeight;
        Vector3 tPosition = mLookAtObj.transform.position + tOffset;
        //����ġ
        float tWeight = mDampTrace * Time.deltaTime;

        //��������
        this.transform.position = Vector3.Lerp(
            this.transform.position,    //0
            tPosition,                  //1
            tWeight);                   //����ġ


        //�ٶ󺸴� ���� ����
        this.transform.LookAt(mLookAtObj.transform.position);
    }
}
