using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemy : MonoBehaviour
{
    public GameObject PFExplosion = null;
    public CItem PFItem = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
        trigger
            i) 충돌
            ii) 물리작용 X


        collision
            i) 충돌
            ii) 물리작용 O
    */

    /*
        현재 설정은 다음과 같다.

        Bullet
            Collider
                IsTrigger on
            Rigidbody2D

        Enemy
            Collider
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");

        if (collision.CompareTag("tagBullet"))
        {
            //적제거( 메모리 해지 )
            Destroy(gameObject);
            //탄환제거( 메모리 해지 )
            Destroy(collision.gameObject);

            //폭발 애니메이션 효과 만들기
            Instantiate<GameObject>(PFExplosion, this.transform.position, Quaternion.identity);

            //아이템 생성
            Instantiate<CItem>(PFItem, this.transform.position, Quaternion.identity);
        }
    }


}
