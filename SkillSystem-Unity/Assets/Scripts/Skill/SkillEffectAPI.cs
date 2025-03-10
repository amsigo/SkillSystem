using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class SkillEffectAPI
{
    public static void CallSkillAPI(SkillEffectData skillEffectData, Unit caster, Unit target)
    {
        switch(skillEffectData.effectType)
        {
            case SkillEffectType.Damage:
                Damage(caster, target, skillEffectData.value);
                break;

            case SkillEffectType.RecoveryHP:
                RecoveryHP(caster, target, skillEffectData.value);
                break;
        }
    }
}