using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class SkillEffectAPI
{
    public static void Damage(Unit caster, Unit target, int damage)
    {
        if(caster == target)
            target.Damage(damage, false);
        else
            target.Damage(damage);
    }
}