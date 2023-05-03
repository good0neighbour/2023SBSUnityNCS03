using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrid : MonoBehaviour
{
    public List<GameObject> mPositions = new List<GameObject>();
    
    public CEnemy[] PFEnemy = new CEnemy[3];

    private CEnemy mpCurSlime = null;

    private float mSpawnTime = 2.0f;

    public float _SpawnTime
    {
        get
        {
            return mSpawnTime;
        }
        set
        {
            mSpawnTime = value;
            CancelInvoke();
            InvokeRepeating("OnTimerEnemyAppear", mSpawnTime, mSpawnTime);
            CUIPlayGame.Instance.SpawnTimeUpdate(mSpawnTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //������ �� ���� ���� ����
        //mpCurrentSlime = Instantiate<CSlime>(PFSlime, Vector3.zero, Quaternion.identity);

        InvokeRepeating("OnTimerEnemyAppear", mSpawnTime, mSpawnTime);
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
        if (null != mpCurSlime)
        {
            //Destroy '����Ƽ�� ���ӿ�����Ʈ'�� �����ϴ� �Լ���.
            Destroy(mpCurSlime.gameObject);
        }

        //������ �� ���� ���� ����
        //Instantiate '����Ƽ�� ���ӿ�����Ʈ'�� �������� �����ϴ� �Լ���.( new�� �������� �ʴ´� )
        //mpCurrentSlime = Instantiate<CSlime>(PFSlime, tPosSpawn, Quaternion.identity);

        //�� ������ �����ϰ� ����
        int tEnemyType = Random.Range(0, PFEnemy.Length);
        //�����ϰ� ������ ������� �� ����
        mpCurSlime = Instantiate<CEnemy>(PFEnemy[tEnemyType], tPosSpawn, Quaternion.identity);
    }
}
