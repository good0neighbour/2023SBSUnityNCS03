using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawnerEnemy : MonoBehaviour
{
    //������ ��ũ
    [SerializeField]
    GameObject PFEnemy = null;

    //�ڷ�ƾ �Լ��� �̿��� '������ �����帧 ����' �����:
    //                  IEnumerator����Ÿ�� + �ݺ������ + yield return
    IEnumerator OnSpawnEnemy()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(5f);    //yield return ������ �ʾ����� �����Ҳ�
            //<-- new WaitForSeconds(5f)5�� �ð� �Ŀ� �� �������� �ٽ� �ڷ�ƾ ������ �帧�� ���ƿ´�.

            /*
                ���� ������ ����ϱ� ���� �����̴�.
                ������ �帧�� ���������� �̷������ �������� ������ �䳻�� ���̸�
                ���� ���������� �̷������ ���� �ƴϴ�.
            */

            Debug.Log("OnSpawnEnemy");

            Vector3 tPosition = this.transform.position;
            //tPosition.y = 1.0f;
            Instantiate<GameObject>(PFEnemy, tPosition, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("OnSpawnEnemy");   //���ڿ��� �̿��Ͽ� �ڷ�ƾ �Լ��� ����
        StartCoroutine(OnSpawnEnemy());     //�ڷ�ƾ�� ����ȣ��?�� ����Ͽ� �ڷ�ƾ �Լ��� ����
        //<-- �� ��° ����� ���Ѵ�
        //  �ֳ��ϸ�, ù ��° ���ڿ��� �̿��ϴ� ����� ���� ��� �Ұ����ϴ�.



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
