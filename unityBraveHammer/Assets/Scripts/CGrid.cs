using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrid : MonoBehaviour
{
    public List<GameObject> mPositions = new List<GameObject>();



    public CSlime PFSlime = null;

    //private CSlime mpCurrentSlime = null;
    public CSlime mpCurrentSlime = null;

    // Start is called before the first frame update
    void Start()
    {
        //������ �� ���� ���� ����
        //mpCurrentSlime = Instantiate<CSlime>(PFSlime, Vector3.zero, Quaternion.identity);

        InvokeRepeating("OnTimerEnemyAppear", 2.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTimerEnemyAppear()
    {
        Debug.Log("OnTimerEnemyAppear");

        //�������� ������ ��ġ�� �����ϰ� �����Ѵ�.
        int tIndex = Random.Range(0, mPositions.Count);

        Vector3 tPosSpawn = mPositions[tIndex].transform.position;
        tPosSpawn.y = 0.0f;

        Debug.Log($"tPosSpawn: {tPosSpawn.ToString()}");




        //�� ������ �ϳ��� �����Ӹ� �����ϵ��� �ϱ� ����
        if (null != mpCurrentSlime)
        {
            //Destroy '����Ƽ�� ���ӿ�����Ʈ'�� �����ϴ� �Լ���.
            Destroy(mpCurrentSlime.gameObject);
        }

        //������ �� ���� ���� ����
        //Instantiate '����Ƽ�� ���ӿ�����Ʈ'�� �������� �����ϴ� �Լ���.( new�� �������� �ʴ´� )
        mpCurrentSlime = Instantiate<CSlime>(PFSlime, tPosSpawn, Quaternion.identity);
    }
}
