using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkillEffectAPI
{
    public void CallSkillAPI(SkillEffectData skillEffectData)
    {
        switch(skillEffectData.effectType)
        {
            case SkillEffectType.Damage:
                Damage();
                break;

            case SkillEffectType.RecoveryHP:
                RecoveryHP();
                break;
        }
    }
}