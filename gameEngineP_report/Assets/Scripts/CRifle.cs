using UnityEngine;

public class CRifle : MonoBehaviour
{
    private ParticleSystem.EmissionModule mEmission;
    private CBehaviourTree mBehaviourTree = new CBehaviourTree();

    private void Awake()
    {
        // 자식 오브젝트로부터 파티클시스템의 emission 참조
        mEmission = GetComponentInChildren<ParticleSystem>().emission;

        // 행동트리 생성
        mBehaviourTree
            .Selector()

                .Sequence()
                    .Action(() =>
                    {
                        if (Input.GetMouseButton(0))
                        {
                            return CBehaviourTree.EStatus.SUCCEEDED;
                        }
                        else
                        {
                            return CBehaviourTree.EStatus.FAILED;
                        }
                    })
                    .Action(() =>
                    {
                        mEmission.rateOverTime = 10.0f;
                        return CBehaviourTree.EStatus.SUCCEEDED;
                    })
                .Escape()

                .Sequence()
                    .Action(() =>
                    {
                        mEmission.rateOverTime = 0.0f;
                        return CBehaviourTree.EStatus.SUCCEEDED;
                    })
                .Escape()

            .Escape();
    }

    private void Update()
    {
        mBehaviourTree.Execute();
    }
}
