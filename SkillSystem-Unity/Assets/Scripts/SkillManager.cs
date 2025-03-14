using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : Singleton<SkillManager>
{
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();

    private void Awake()
    {
        StartCoroutine(ProcessQueue());
    }

    IEnumerator ProcessQueue()
    {
        while (true)
        {
            if(coroutineQueue.Count > 0)
                yield return StartCoroutine(coroutineQueue.Dequeue());

            yield return null;
        }
    }

    IEnumerator SkillCoroutine(Unit caster, Unit target, SkillData skillData)
    {
        List<SkillEffectData> skillEffectDataList = GameTableManager.Instance.SkillEffectTable.GetSkillEffectDataList(skillData.skillNo);

        foreach(var skillEffectData in skillEffectDataList)
        {
            SkillEffectAPI.CallSkillAPI(skillEffectData, caster, target);
        }

        yield return null;
    }

    public void CastSkill(Unit caster, int skillNo)
    {
        SkillData skillData = GameTableManager.Instance.SkillTable.GetSkillData(skillNo);

        if (skillData != null)
        {
            switch(skillData.target)
            {
                case SkillEffectTarget.Caster:
                    coroutineQueue.Enqueue(SkillCoroutine(caster, caster, skillData));
                    break;

                case SkillEffectTarget.Enemy:
                    Unit target = caster.FindTarget(skillData.attackRange);

                    if(target)
                        coroutineQueue.Enqueue(SkillCoroutine(caster, target, skillData));
                    break;
            }
        }
    }
}