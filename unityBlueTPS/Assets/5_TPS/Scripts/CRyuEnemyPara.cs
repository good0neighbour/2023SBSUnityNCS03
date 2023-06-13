using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuEnemyPara : MonoBehaviour
{
    //����ź ������ ��ũ
    [SerializeField]
    GameObject PFGrenade = null;

    //����ź �߻�����
    [SerializeField]
    GameObject mPosFire = null;

    //����ź ź������
    [SerializeField]
    GameObject mTarget = null;

    //����ź ��ô
    public void DoFire()
    {
        //��ô �ӵ� ���ϱ�
        Vector3 tVelocity = Vector3.zero;   //��ô �ӵ�

        //zx���޼��� ���͸� ������
        //��������
        Vector3 tTargetPos = mTarget.transform.position;
        tTargetPos.y = 0f;
        //��������
        Vector3 tStartPos = mPosFire.transform.position;
        tStartPos.y = 0f;

        //������ ũ���� ������ ������ ����
        Vector3 tZXVector = tTargetPos - tStartPos;
        //tZXVecter = tZXVecter.normalized;   //����ȭ

        //45�� ����
        tVelocity = (tZXVector.normalized + Vector3.up).normalized;
        //ZX��鿡�� ���������� �������� ������ �Ÿ�
        float tDZX = tZXVector.magnitude;
        float tDY = tTargetPos.y - tStartPos.y; //y�࿡�� ���������� �������� ������ �Ÿ�
        float tCos = Mathf.Cos(45f * Mathf.Deg2Rad);
        float tSin = Mathf.Sin(45f * Mathf.Deg2Rad);
        float tTan = tSin / tCos;
        //45���� �����Ͽ� �ʱ�ӷ��� ���Ѵ�
        float tScalarSpeed = (tDZX / tCos) * Mathf.Sqrt((-1f) * 9.8f / (2f * (tDY - tTan * tDZX)));

        //�ӵ� ����
        tVelocity = tVelocity * tScalarSpeed;

        //����ź ����
        GameObject tGrenade = Instantiate<GameObject>(PFGrenade, this.mPosFire.transform.position, Quaternion.identity);
        tGrenade.GetComponent<Rigidbody>().AddForce(tVelocity, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        mTarget = FindObjectOfType<CPChar_1>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
