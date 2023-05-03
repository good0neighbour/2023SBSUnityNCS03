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
        //슬라임 한 마리 동적 생성
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

        //슬라임이 생성될 위치를 랜덤하게 선택한다.
        int tIndex = Random.Range(0, mPositions.Count);

        Vector3 tPosSpawn = mPositions[tIndex].transform.position;
        tPosSpawn.y = 0.0f;

        Debug.Log($"tPosSpawn: {tPosSpawn.ToString()}");




        //한 순간에 하나의 슬라임만 존재하도록 하기 위해
        if (null != mpCurSlime)
        {
            //Destroy '유니티의 게임오브젝트'를 삭제하는 함수다.
            Destroy(mpCurSlime.gameObject);
        }

        //슬라임 한 마리 동적 생성
        //Instantiate '유니티의 게임오브젝트'를 동적으로 생성하는 함수다.( new로 생성하지 않는다 )
        //mpCurrentSlime = Instantiate<CSlime>(PFSlime, tPosSpawn, Quaternion.identity);

        //적 종류를 랜덤하게 설정
        int tEnemyType = Random.Range(0, PFEnemy.Length);
        //랜덤하게 결정된 종류대로 적 생성
        mpCurSlime = Instantiate<CEnemy>(PFEnemy[tEnemyType], tPosSpawn, Quaternion.identity);
    }
}
