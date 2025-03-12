using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitHpBar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    [SerializeField]
    private TextMeshProUGUI hpText;

    private float hpFillAmount = 1f;
    private float lerpSpeed = 0.1f;

    private void Awake()
    {
        hpFillAmount = 1f;
    }

    private void Update()
    {
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, hpFillAmount, Time.deltaTime*10);
    }

    public void UpdateHpBar(int currentHp, int maxHp)
    {
        hpFillAmount = (float)currentHp / (float)maxHp;

        hpText.text = string.Format("{0}/{1}", currentHp, maxHp);
    }
}