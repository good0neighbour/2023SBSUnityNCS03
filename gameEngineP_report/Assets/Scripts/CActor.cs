using UnityEngine;

public class CActor : MonoBehaviour
{
    private Animator mAnimator = null;
    private float mMovingForward = 0.0f;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (1.0f < mMovingForward)
            {
                mMovingForward += Time.deltaTime;
                if (1.0f > mMovingForward)
                {
                    mMovingForward = 1.0f;
                }
            }
        }
    }
}
