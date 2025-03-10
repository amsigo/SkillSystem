using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class SkillEffectAPI
{
    public static void RecoveryHP(Unit caster, Unit target, int damage)
    {
        target.RecoveryHp(damage);
    }
}