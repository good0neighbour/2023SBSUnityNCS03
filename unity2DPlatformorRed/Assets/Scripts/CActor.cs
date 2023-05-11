using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    [SerializeField]
    GameObject PFBullet = null;


    [SerializeField]
    float mScalarSpeed = 2.0f;

    SpriteRenderer mSprRdr = null;
    Rigidbody2D mRigidBody = null;

    //클래스 내부에서 사용되는 변수
    //탄환발사방향, 기본은 오른쪽 방향
    Vector3 mDirFire = Vector3.right;

    private void Awake()
    {
        //미리 검색하여 찾아두자.
        //소스코드에서 연동해두면, 만약의 경우에 소스코드만 있으면 복구된다.
        mSprRdr = this.GetComponentInChildren<SpriteRenderer>();
        mRigidBody = this.GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
            게임엔진에서 일반적으로 물체의 이동을 만드는 방식은
                대개 다음과 같다.
            i) 좌표를 직접 지정
            ii) 제공되는 이동 함수를 사용하는 방식
            iii) F = ma에 의한 방식

            iv) 에니메이션으로 만드는 방식
        */

        //축입력 기반
        float tH = Input.GetAxis("Horizontal");


        //시간 기반 진행, x축 이동
        Vector3 tVelocity = Vector3.right * tH * mScalarSpeed * Time.deltaTime;

        this.transform.Translate(tVelocity, Space.Self);


        //벡터의 내적을 이용한 두 벡터의 위치관계의 대수적 판단
        Vector3 tMoveDir = tVelocity.normalized;    //정규화
        if (Vector3.Dot(tMoveDir, Vector3.right) >= 1.0f)
        {
            //오른쪽 방향으로 이동하고 있다
            mSprRdr.flipX = false;
            //원본 이미지가 오르쪽 방향으로 만들어져 있으므로 뒤집지 않는다

            //탄환발사 방향 결정
            mDirFire = Vector3.right;
        }
        else if (Vector3.Dot(tMoveDir, Vector3.right) <= -1.0f)
        {
            //왼쪽 방향으로 이동하고 있다
            mSprRdr.flipX = true;
            //원본 이미지가 오르쪽 방향으로 만들어져 있으므로 뒤집는다

            //탄환발사 방향 결정
            mDirFire = Vector3.left;
        }




        //상방 화살표 입력에 기반한 점프, 물리엔진의 기능 기반
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Vector3 tJumpForce = Vector3.up * 10f;
            mRigidBody.AddForce(tJumpForce, ForceMode2D.Impulse);
        }

        //스페이스 바 입력에 기반한 탄환발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tBullet = Instantiate<GameObject>(PFBullet, this.transform.position, Quaternion.identity);

            //만약 이 검색이 싫다면, 미리 CBullet을 만들고 해당 스크립트에서 연동해두자.
            Vector3 tBulletForce = mDirFire * 20f;  //주인공 캐릭터의 방향에 따라 발사방향 결정
            tBullet.GetComponent<Rigidbody2D>().AddForce(tBulletForce, ForceMode2D.Impulse);
        }
    }
}
