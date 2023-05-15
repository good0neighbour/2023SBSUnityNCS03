using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    // 유니티 에디터 노출 변수
    [SerializeField]
    GameObject PFBullet = null;

    //해당 클래스 내에서 사용하기 위해 멤버변수로 선언
    CUIPlayGame mUI = null;


    [SerializeField]
    GameObject mFirePos = null; //탄환 발사 위치

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
        //step_1
        //시작?시 검색하므로, 매번 검색하는 경우보다 낫다.
        //mUI = FindObjectOfType<CUIPlayGame>();
    }


    float tH;
    //렌더링에 관한 갱신 이벤트 함수
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
        tH = Input.GetAxis("Horizontal");
        //상방 화살표 입력에 기반한 점프, 물리엔진의 기능 기반
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Vector3 tJumpForce = Vector3.up * 12f;
            mRigidBody.AddForce(tJumpForce, ForceMode2D.Impulse);
        }

        //스페이스 바 입력에 기반한 탄환발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tBullet = Instantiate<GameObject>(PFBullet,
                //this.transform.position,
                mFirePos.transform.position,
                Quaternion.identity);

            //만약 이 검색이 싫다면, 미리 CBullet을 만들고 해당 스크립트에서 연동해두자.
            Vector3 tBulletForce = mDirFire * 20f;  //주인공 캐릭터의 방향에 따라 발사방향 결정
            tBullet.GetComponent<Rigidbody2D>().AddForce(tBulletForce, ForceMode2D.Impulse);
        }

        //이동변환 함수를 이용한 이동
        //시간 기반 진행, x축 이동
        //Vector3 tVelocity = Vector3.right * tH * mScalarSpeed * Time.deltaTime;
        //this.transform.Translate(tVelocity, Space.Self);

        //물리작용에 근거한 이동 코드
        //<-- 시간단위 1초에 기반한 코드이므로 Time.deltaTime을 제거했다.
        Vector3 tVelocity = Vector3.right * tH * mScalarSpeed;  //<--x축에 힘 성분 적용
        tVelocity.y = mRigidBody.velocity.y;                //<--y축에 힘 성분 적영

        //강체의 속도를 직접 지정하자.
        this.mRigidBody.velocity = tVelocity;


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




        

    }

    //물리 작용에 관한 갱신 이벤트 함수

    //편법
    //물리작용에 관한 갱신 주기와 이동변환 갱신 주기를 맞춰, 옆 벽면에 덜덜거리는 현상을 해결할 수도 있다.
    //하지만, 편법이다.
    private void FixedUpdate()
    {
        //Vector3 tVelocity = Vector3.right * tH * mScalarSpeed * Time.deltaTime;
        //this.transform.Translate(tVelocity, Space.Self);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("tagMovePlatform"))
        {
            //충돌이 시작되는 시점에
            //이동플랫폼으로 부모로 하여 transform의 계층구조를 하위에 두겠다.
            this.transform.SetParent(collision.gameObject.transform);


            //UI갱신
            //step_0
            //FindObjectOfType 타입으로 '검색'해서 해당 게임오브젝트를 찾아준다.
            //씬그래프(실제로는 트리자료구조)를 검색해야 되는 비용이 든다.
            //      추정컨데 O(n)
            //CUIPlayGame tUI = FindObjectOfType<CUIPlayGame>();
            //if (null != tUI)
            //{
            //    tUI.BuildUI();
            //}

            //step_1
            //mUI.BuildUI();

            //step_2
            //전역적인 성격을 가지는 델리게이트를 사용하여 간접호출하였다
            //<-- 검색 비용이 들지 않는다
            CUIPlayGame.mAction();  //간접호출
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //충돌이 종료되는 시점에
        //이동플랫폼으로 부모로 하여 transform의 계층구조를 제거하겠다.
        this.transform.SetParent(null);
    }


}
