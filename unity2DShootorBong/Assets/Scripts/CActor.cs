using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    //프리팹 링크
    [SerializeField]
    CBullet PFBullet = null;



    float mHorizontal = 0f;
    float mVertical = 0f;

    [SerializeField]    //유니티 에디터 상에 노출시켜서 값을 수정해보기 위해 <--빠른 반복개발을 위해
    float tScalarSpeed = 0f;   //속력
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis 연속된 값으로 가, 감속 되는(변화되는) 형태로 값이 들어온다.
        //mHorizontal = Input.GetAxis("Horizontal");  //[-1, 1]
        //mVertical = Input.GetAxis("Vertical");      //[-1, 1]

        //Input.GetAxisRaw 불연속된 값의 형태로 들어온다.
        mHorizontal = Input.GetAxisRaw("Horizontal");  //[-1, 1]
        mVertical = Input.GetAxisRaw("Vertical");      //[-1, 1]

        //Debug.Log(mVertical.ToString());

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //탄환 게임 오브젝트를 동적으로 생성
            //제어를 위해 참조변수에 담아둠
            CBullet tBullet = Instantiate<CBullet>(PFBullet, this.transform.position, Quaternion.identity);

            //Physics2D: Unity2D의 물리기능 이용
            //unity에서는 길이 1unit는 1m, mass 1은 1kg, 시간은 1sec
            tBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            //ForceMode2D.Impulse 명시한 힘을 해당 프레임 순간에서 모두 주고 싶다면 이 모드를 쓰면 된다
            //  vs ForceMode2D.Force는 1초에 맞춰져 있는 옵션이다.<-- 원래 물리 세팅
            //F = ma
        }




        //순수한 방향 구하기
        //벡터의 스칼라 곱셈, 벡터끼리의 덧셈, 데카르트 곱
        //임의의 크기의 임의의 방향의 벡터
        Vector3 tVelocity = Vector3.right * mHorizontal + Vector3.up * mVertical;
        tVelocity = tVelocity.normalized;   //벡터의 정규화

        //시간기반 진행, 로컬좌표계 기준
        this.transform.Translate(tVelocity * tScalarSpeed * Time.deltaTime, Space.Self);

    }
}
