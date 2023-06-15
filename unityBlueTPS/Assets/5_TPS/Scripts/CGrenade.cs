using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrenade : MonoBehaviour
{
    //폭발 효과 파티클 프리팹 링크
    [SerializeField]
    GameObject PFfxExplosion = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("tagFloor"))
        {
            //수류탄 삭제
            Debug.Log("<color='red'>Destroy Grenade</color>");
            Destroy(this.gameObject);

            //폭발 파티클 생성
            GameObject tEfx = Instantiate(PFfxExplosion, this.transform.position, Quaternion. identity);
            Destroy(tEfx, 2f);    //2초 후에 삭제

            //폭발력 적용

            //힘을 적용할 물체를 검색하자
            //  해당 함수에 레이어 번호를 입력할 시에는 '비트연산자를 이용한 표기'를 쓴다
            //  <--'메모리를 절약'하기 위한 방법이다.
            /*
                이를테면
                3번 레이어와 6번 레이어를 동시에 체크하고 싶다면
                이 두 개를 정수int라고 가정하면 총 4 * 2 = 8byte가 필요하다
                하지만 비트연산자를 이용하면

                1<<3|1<<6으로 표현하면
                1byte안에 두 개의 표현을 모두 담을 수 있다.
            */
            Collider[] tColliders = Physics.OverlapSphere(this.transform.position, 10f, 1 << 3 | 1 << 6);

            foreach (var t in tColliders)
            {
                Debug.Log("---ryuTest---");

                var tR = t.GetComponent<Rigidbody>();

                tR.AddExplosionForce(1500f, this.transform.position, 10f, 1200f);

            }

        }
    }
}
