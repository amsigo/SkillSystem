using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTableManager : Singleton<GameTableManager>
{
    private readonly string gameTablePath = "GameTable";

    private SkillTable skillTable = new SkillTable();

    private SkillEffectTable skillEffectTable = new SkillEffectTable();

    private LocalizingTable localizingTable = new LocalizingTable();

    public SkillTable SkillTable => skillTable;

    public SkillEffectTable SkillEffectTable => skillEffectTable;

    public LocalizingTable LocalizingTable => localizingTable;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        ParsingTable();
    }

    void ParsingTable()
    {
        skillTable.Parsing(gameTablePath + "/Skill");
        skillEffectTable.Parsing(gameTablePath + "/skillEffect");
        localizingTable.Parsing(gameTablePath + "/Localizing");
    }
}