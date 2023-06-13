using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuEnemyPara : MonoBehaviour
{
    //수류탄 프리팹 링크
    [SerializeField]
    GameObject PFGrenade = null;

    //수류탄 발생지점
    [SerializeField]
    GameObject mPosFire = null;

    //수류탄 탄착지점
    [SerializeField]
    GameObject mTarget = null;

    //수류탄 투척
    public void DoFire()
    {
        //투척 속도 구하기
        Vector3 tVelocity = Vector3.zero;   //투척 속도

        //zx평면메서의 벡터를 구하자
        //목적지점
        Vector3 tTargetPos = mTarget.transform.position;
        tTargetPos.y = 0f;
        //시작지점
        Vector3 tStartPos = mPosFire.transform.position;
        tStartPos.y = 0f;

        //임의의 크기의 임의의 방향의 벡터
        Vector3 tZXVector = tTargetPos - tStartPos;
        //tZXVecter = tZXVecter.normalized;   //정규화

        //45도 가정
        tVelocity = (tZXVector.normalized + Vector3.up).normalized;
        //ZX평면에서 시작지점과 목적지점 사이의 거리
        float tDZX = tZXVector.magnitude;
        float tDY = tTargetPos.y - tStartPos.y; //y축에서 시작지점과 목적지점 사이의 거리
        float tCos = Mathf.Cos(45f * Mathf.Deg2Rad);
        float tSin = Mathf.Sin(45f * Mathf.Deg2Rad);
        float tTan = tSin / tCos;
        //45도를 가정하여 초기속력을 구한다
        float tScalarSpeed = (tDZX / tCos) * Mathf.Sqrt((-1f) * 9.8f / (2f * (tDY - tTan * tDZX)));

        //속도 결정
        tVelocity = tVelocity * tScalarSpeed;

        //수류탄 생성
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
