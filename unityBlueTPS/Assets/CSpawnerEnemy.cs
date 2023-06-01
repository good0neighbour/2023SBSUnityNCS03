using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawnerEnemy : MonoBehaviour
{
    //������ ��ũ
    [SerializeField]
    GameObject PFEnemy = null;

    //�ڷ�ƾ �Լ�: IEnumerator����Ÿ�� + �ݺ������ + yield return
    IEnumerator OnSpawnEnemy()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(5f);    //yield return ������ �ʾ����� �����Ҳ�

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

        //���� �ð� �������� �� ����
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
