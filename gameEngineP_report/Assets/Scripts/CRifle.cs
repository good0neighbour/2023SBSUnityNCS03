using UnityEngine;

public class CRifle : MonoBehaviour
{
    private ParticleSystem.EmissionModule mEmission;
    private CBehaviourTree mBehaviourTree = new CBehaviourTree();

    private void Awake()
    {
        // �ڽ� ������Ʈ�κ��� ��ƼŬ�ý����� emission ����
        mEmission = GetComponentInChildren<ParticleSystem>().emission;

        // �ൿƮ�� ����
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
