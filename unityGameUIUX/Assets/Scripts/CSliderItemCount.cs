using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSliderItemCount : MonoBehaviour
{
    public static CSliderItemCount Instance;

    [SerializeField]
    private Slider mSlider = null;

    [SerializeField]
    private TMP_Text mText = null;

    [SerializeField]
    private GameObject mTheEnd = null;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mText.text = "0/8";
        mSlider.maxValue = 8.0f;
        mSlider.value = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        mSlider.value = GameManager.Instance.ItemNum;
        mText.text = $"{GameManager.Instance.ItemNum}/ 8";
        if (8 <= GameManager.Instance.ItemNum)
        {
            mTheEnd.SetActive(true);
        }
    }
}
