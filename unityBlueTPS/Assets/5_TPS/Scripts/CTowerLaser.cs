using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtowerLaser : MonoBehaviour
{
    //파티클 프래핍 링크
    [SerializeField]
    GameObject PFEfxSpark = null;



    [SerializeField]
    GameObject mHead = null;

    [SerializeField]
    GameObject mPosFire = null;

    [SerializeField]
    GameObject mTarget = null;

    [SerializeField]
    LineRenderer mLineRenderer = null;



    // Start is called before the first frame update
    void Start()
    {
        //라인 렌더러 컴포넌트 얻기
        mLineRenderer = mPosFire.GetComponent<LineRenderer>();

        mTarget = FindObjectOfType<CPChar_1>().gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        //응시: 포신mHead이 타겟을 바라보게 하자
        //case 0
        //Vector3 tDir = mTarget.transform.position - mHead.transform.position;
        //mHead.transform.forward = tDir.normalized;

        //case 1
        //Vector3 tDir = mTarget.transform.position - mHead.transform.position;
        //mHead.transform.rotation = Quaternion.LookRotation(tDir.normalized);

        //case 2
        Vector3 tDir = mTarget.transform.position - mHead.transform.position;
        Quaternion tA = Quaternion.LookRotation(mHead.transform.forward);
        Quaternion tB = Quaternion.LookRotation(tDir.normalized);
        //두 사원수 간에 구면선형보간
        mHead.transform.rotation = Quaternion.Slerp(tA, tB, 2f * Time.deltaTime);


        //반직선에 의한 충돌 검출
        RaycastHit tHit;
        if (Physics.Raycast(mPosFire.transform.position, mPosFire.transform.forward, out tHit, Mathf.Infinity))
        {
            //파티클 적용

            //Vector3 testP = new Vector3(0f, 0f, -5f);

            //GameObject tEfx = Instantiate<GameObject>(PFEfxSpark, testP, Quaternion.identity);
            //충돌 지점 표면의 법선벡터를 따라 회전
            Quaternion tRot = Quaternion.LookRotation(tHit.normal);
            GameObject tEfx = Instantiate<GameObject>(PFEfxSpark, tHit.point, tRot);
            Destroy(tEfx, 1f);


            //레이저 외관 출력
            Vector3 tStart = mPosFire.transform.position;
            Vector3 tEnd = tHit.point;

            mLineRenderer.SetPosition(0, tStart);
            mLineRenderer.SetPosition(1, tEnd);
        }
        else
        {
            Vector3 tStart = mPosFire.transform.position;
            Vector3 tDirFire = mPosFire.transform.forward;//mPosFire.transform.position - mHead.transform.position;
            tDirFire = tDirFire.normalized;
        
            Vector3 tEnd = tStart + tDirFire * 100f;//mTarget.transform.position;

            mLineRenderer.SetPosition(0, tStart);
            mLineRenderer.SetPosition(1, tEnd);
        }



        //레이저 외관 표현

        //Vector3 tStart = mPosFire.transform.position;
        //Vector3 tDirFire = mPosFire.transform.position - mHead.transform.position;
        //tDirFire = tDirFire.normalized;
        
        //Vector3 tEnd = tStart + tDirFire * 100f;//mTarget.transform.position;

        //mLineRenderer.SetPosition(0, tStart);
        //mLineRenderer.SetPosition(1, tEnd);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(mPosFire.transform.position, mPosFire.transform.forward * 100f);
    }

}
