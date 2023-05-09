using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem : MonoBehaviour
{
    Rigidbody2D mRigid = null;

    [SerializeField]    //<-- 유니티 에디터 상에 노출
    float mScalarSpeed = 0.0f;  //속력

    //선형보간할 두 벡터
    Vector2 tA = Vector2.zero;
    Vector2 tB = Vector2.zero;

    float tWeight = 0.0f;   //가중치

    // Start is called before the first frame update
    void Start()
    {
        mRigid = GetComponent<Rigidbody2D>();

        Vector2 tVelocity = Vector2.zero;

        //랜덤하게 방향 결정
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
        //감속
        if (tWeight < 1f)
        {
            //임의의 수치로 증가, 시간기반 진행
            tWeight += 1f * Time.deltaTime;
        }
        else
        {
            tWeight = 1f;
        }
        //선형보간으로 만들어진 속도를 설정
        Vector2 t = Vector2.Lerp(tA, tB, tWeight);
        mRigid.velocity = t;
    }
}
