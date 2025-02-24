using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    IEnumerator SkillCoroutine(Unit caster, Unit target, SkillData skillData)
    {
        List<SkillEffectData> skillEffectDataList = GameTableManager.Instance.SkillEffectTable.GetSkillEffectDataList(skillData.skillNo);

        foreach(var skillEffectData in skillEffectDataList)
        {
            //skillEffectData.
        }

        yield return null;
    }
}