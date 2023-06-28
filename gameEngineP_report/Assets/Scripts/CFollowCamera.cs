using UnityEngine;

public class CFollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 mPositionOffset = Vector3.zero;
    [SerializeField] private Vector3 mLookAtOffset = Vector3.zero;
    [SerializeField] private float mCameraWeight = 0.5f;
    [SerializeField] private Transform mActor = null;
    private float mRaidanToDegree = 180.0f / Mathf.PI;

    private void Update()
    {
        // 카메라 상하 회전
        Quaternion tRotationX = Quaternion.Euler(-Input.GetAxis("Mouse Y"), 0.0f, 0.0f);
        mPositionOffset = tRotationX * mPositionOffset;
        mLookAtOffset = tRotationX * mLookAtOffset;

        // 카메라 위치
        transform.localPosition = Vector3.Lerp(transform.localPosition, mActor.localPosition + mActor.rotation * mPositionOffset, mCameraWeight);

        // 카메라 방향
        Vector3 tGap = mActor.localPosition + mActor.rotation * mLookAtOffset - transform.localPosition;
        float tZ = 0.0f;
        float tY = Mathf.Atan(tGap.x / tGap.z);
        float tX = -Mathf.Atan(tGap.y / (tGap.x * Mathf.Sin(tY) + tGap.z * Mathf.Cos(tY))) * mRaidanToDegree;

        if (0.0f > tGap.z)
        {
            tX = 180.0f + tX;
            tZ = 180.0f;
        }
        
        transform.localRotation = Quaternion.Euler(tX, tY * mRaidanToDegree, tZ);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(mActor.localPosition + mActor.rotation * mLookAtOffset, 0.1f);
    }
}
