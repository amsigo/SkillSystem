using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class SkillEffectAPI
{
    public static void CallSkillAPI(SkillEffectData skillEffectData, Unit caster, Unit target)
    {
        Unit skillTarget = null;

        switch (skillEffectData.target)
        {
            case SkillEffectTarget.Caster:
                skillTarget = caster;
                break;

            case SkillEffectTarget.Enemy:
                skillTarget = target;
                break;
        }

        switch (skillEffectData.effectType)
        {
            case SkillEffectType.Damage:
                Damage(caster, skillTarget, skillEffectData.value);
                break;

            case SkillEffectType.RecoveryHP:
                RecoveryHP(caster, skillTarget, skillEffectData.value);
                break;
        }
    }
}