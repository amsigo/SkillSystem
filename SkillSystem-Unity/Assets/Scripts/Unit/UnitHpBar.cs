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

    public void UpdateHpBar(int currentHp, int maxHp)
    {
        float hpFillAmount = (float)currentHp / (float)maxHp;

        fillImage.fillAmount = hpFillAmount;
    }
}