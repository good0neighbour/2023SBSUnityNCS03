using UnityEngine;

public class CFollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 mPositionOffset = Vector3.zero;
    [SerializeField] private Vector3 mLookAtOffset = Vector3.zero;
    [SerializeField] private Transform mActor = null;
    private float mRaidanToDegree = 180.0f / Mathf.PI;

    private void Update()
    {
        // 카메라 위치
        transform.localPosition = mActor.localPosition + mActor.rotation * mPositionOffset;

        // 카메라 회전
        float tX;
        float tY;
        float tZ;
        Vector3 tGap = mActor.localPosition + mLookAtOffset - transform.localPosition;

        if (0.0f > tGap.z)
        {
            tX = 180.0f - Mathf.Atan(tGap.y / tGap.z) * mRaidanToDegree;
            tY = 180.0f + Mathf.Atan(tGap.x / tGap.z) * mRaidanToDegree;
            tZ = 180.0f;
        }
        else
        {
            tX = -Mathf.Atan(tGap.y / tGap.z) * mRaidanToDegree;
            tY = Mathf.Atan(tGap.x / tGap.z) * mRaidanToDegree;
            tZ = 0.0f;
        }

        transform.localRotation = Quaternion.Euler(tX, tY, tZ);
    }
}
