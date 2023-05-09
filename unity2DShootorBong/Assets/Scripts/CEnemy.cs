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
            i) �浹
            ii) �����ۿ� X


        collision
            i) �浹
            ii) �����ۿ� O
    */

    /*
        ���� ������ ������ ����.

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
            //������( �޸� ���� )
            Destroy(gameObject);
            //źȯ����( �޸� ���� )
            Destroy(collision.gameObject);

            //���� �ִϸ��̼� ȿ�� �����
            Instantiate<GameObject>(PFExplosion, this.transform.position, Quaternion.identity);

            //������ ����
            Instantiate<CItem>(PFItem, this.transform.position, Quaternion.identity);
        }
    }


}
