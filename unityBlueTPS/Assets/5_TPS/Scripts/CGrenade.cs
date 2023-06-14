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



        }
    }
}
