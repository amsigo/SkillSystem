using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectData
{
    public int skillNo;
    public SkillEffectType effectType;
    public SkillEffectTarget target;
    public int value;
}

[System.Serializable]
public class SkillEffectTableRow
{
    public int skillNo;
    public string effectType;
    public string target;
    public int value;
}

public class SkillEffectTable : BaseTable
{
    SkillEffectTableRow[] skillEffectTableRows;
    Dictionary<int, List<SkillEffectData>> skillEffectDataDict = new Dictionary<int, List<SkillEffectData>>();

    public override void Parsing(string jsonPath)
    {
        base.Parsing(jsonPath);

        skillEffectTableRows = JsonHelper.FromJson<SkillEffectTableRow>(json);
        skillEffectDataDict = ConvertListToDict();
    }

    Dictionary<int, List<SkillEffectData>> ConvertListToDict()
    {
        Dictionary<int, List<SkillEffectData>> dict = new Dictionary<int, List<SkillEffectData>>();

        foreach(var row in skillEffectTableRows)
        {
            int key = row.skillNo;

            SkillEffectData skillEffectData = new SkillEffectData();
            skillEffectData.skillNo = row.skillNo;
            skillEffectData.effectType = EnumUtil<SkillEffectType>.Parse(row.effectType);
            skillEffectData.target = EnumUtil<SkillEffectTarget>.Parse(row.target);
            skillEffectData.value = row.value;


            if (!dict.ContainsKey(key))
                dict.Add(key, new List<SkillEffectData>());

            dict[key].Add(skillEffectData);
        }

        return dict;
    }

    public List<SkillEffectData> GetSkillEffectDataList(int skillNo)
    {
        if (skillEffectDataDict.ContainsKey(skillNo))
            return skillEffectDataDict[skillNo];

        else
        {
            Debug.LogError("Skill 데이터가 존재하지 않습니다.");
            return null;
        }
    }
}