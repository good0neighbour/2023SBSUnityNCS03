using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem : MonoBehaviour
{
    Rigidbody2D mRigid = null;

    [SerializeField]    //<-- ����Ƽ ������ �� ����
    float mScalarSpeed = 0.0f;  //�ӷ�

    //���������� �� ����
    Vector2 tA = Vector2.zero;
    Vector2 tB = Vector2.zero;

    float tWeight = 0.0f;   //����ġ

    // Start is called before the first frame update
    void Start()
    {
        mRigid = GetComponent<Rigidbody2D>();

        Vector2 tVelocity = Vector2.zero;

        //�����ϰ� ���� ����
        float tDegree = Random.Range(0.0f, 360.0f);
        tVelocity.x = 1.0f * Mathf.Cos(tDegree * Mathf.Deg2Rad);
        tVelocity.y = 1.0f * Mathf.Sin(tDegree * Mathf.Deg2Rad);

        tVelocity = tVelocity * mScalarSpeed;

        mRigid.AddForce(tVelocity, ForceMode2D.Impulse);

        tA = tVelocity;
        tB = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //����
        if (tWeight < 1f)
        {
            //������ ��ġ�� ����, �ð���� ����
            tWeight += 1f * Time.deltaTime;
        }
        else
        {
            tWeight = 1f;
        }
        //������������ ������� �ӵ��� ����
        Vector2 t = Vector2.Lerp(tA, tB, tWeight);
        mRigid.velocity = t;
    }
}
