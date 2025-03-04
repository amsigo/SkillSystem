using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : Singleton<SkillManager>
{
    IEnumerator SkillCoroutine(Unit caster, Unit target, SkillData skillData)
    {
        List<SkillEffectData> skillEffectDataList = GameTableManager.Instance.SkillEffectTable.GetSkillEffectDataList(skillData.skillNo);

        foreach(var skillEffectData in skillEffectDataList)
        {
            SkillEffectAPI.CallSkillAPI(skillEffectData, caster, target);
        }

        yield return null;
    }
}