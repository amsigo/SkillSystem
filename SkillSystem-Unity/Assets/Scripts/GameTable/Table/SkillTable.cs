using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillData
{
    public int skillNo;
    public SkillEffectType effectType;
    public SkillEffectTarget target;
    public int value;
}

[System.Serializable]
public class SkillTableRow
{
    public int skillNo;
    public string effectType;
    public string target;
    public int value;
}

public class SkillTable : BaseTable
{
    SkillTableRow[] skillTableRows;
    Dictionary<int, SkillData> skillDataDict = new Dictionary<int, SkillData>();

    public override void Parsing(string jsonPath)
    {
        base.Parsing(jsonPath);

        skillTableRows = JsonHelper.FromJson<SkillTableRow>(json);
        skillDataDict = ConvertListToDict();
    }

    Dictionary<int, SkillData> ConvertListToDict()
    {
        Dictionary<int, SkillData> dict = new Dictionary<int, SkillData>();

        foreach(var row in skillTableRows)
        {
            int key = row.skillNo;

            SkillData skillData = new SkillData();
            skillData.skillNo = row.skillNo;
            skillData.effectType = EnumUtil<SkillEffectType>.Parse(row.effectType);
            skillData.target = EnumUtil<SkillEffectTarget>.Parse(row.target);
            skillData.value = row.value;

            if (!dict.ContainsKey(key))
                dict.Add(key, skillData);
        }

        return dict;
    }

    public SkillData GetSkillData(int skillNo)
    {
        if(skillDataDict.ContainsKey(skillNo))
            return skillDataDict[skillNo];

        return null;
    }
}