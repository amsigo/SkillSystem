public enum UnitType
{
    Hero,
    Enemy
}

public enum SkillEffectType
{
    //Attack
    Damage,

    //Recovery
    RecoveryHP,

}

public enum SkillEffectTarget
{
    Caster,
    Enemy
}

public enum UnitFSMState
{
    Idle,
    Move,
    Hit,
    Attack,
    Die
}

public enum MoveDir
{
    Left,
    Right
}