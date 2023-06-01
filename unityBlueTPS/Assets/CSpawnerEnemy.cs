using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawnerEnemy : MonoBehaviour
{
    //프리팹 링크
    [SerializeField]
    GameObject PFEnemy = null;

    //코루틴 함수: IEnumerator리턴타입 + 반복제어구조 + yield return
    IEnumerator OnSpawnEnemy()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(5f);    //yield return 끝나지 않았지만 리턴할께

            Debug.Log("OnSpawnEnemy");

            Vector3 tPosition = this.transform.position;
            tPosition.y = 1.0f;
            Instantiate<GameObject>(PFEnemy, tPosition, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("OnSpawnEnemy");

        //일정 시간 간격으로 적 생성
        //InvokeRepeating("OnSpawnEnemy", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnSpawnEnemy()
    //{
    //    Debug.Log("OnSpawnEnemy");

    //    Vector3 tPosition = this.transform.position;
    //    tPosition.y = 1.0f;


    //    Instantiate<GameObject>(PFEnemy, tPosition, Quaternion.identity);
    //}
}
