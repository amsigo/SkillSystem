using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHp = 100;
    public int hp = 100;
    public int speed = 10;

    public MoveDir currentDir;

    private FSMMachine<Unit> unitFsm = new FSMMachine<Unit>();

    [SerializeField]
    private Animator unitAnimator;

    [SerializeField]
    private UnitHpBar hpbar;

    public int Hp => hp;

    public FSMMachine<Unit> UnitFSM => unitFsm;

    public Animator UnitAnimator => unitAnimator;

    private void Awake()
    {
        unitFsm.RegistState(UnitFSMState.Idle, new IdleState(this));
        unitFsm.RegistState(UnitFSMState.Move, new MoveState(this));
        unitFsm.RegistState(UnitFSMState.Hit, new HitState(this));
        unitFsm.RegistState(UnitFSMState.Attack, new AttackState(this));
        unitFsm.RegistState(UnitFSMState.Die, new DieState(this));

        Debug.Log("RegistState");
    }

    private void Start()
    {
        hpbar.UpdateHpBar(hp, maxHp);

        unitFsm.FSMStart(UnitFSMState.Idle);

        Debug.Log("FSMStart");
    }

    protected virtual void Update()
    {
        unitFsm.UpdateFSM();
    }

    public virtual Unit FindTarget(float attackRange)
    {
        int unitLayer = 1 << gameObject.layer;

        RaycastHit2D hit;

        if(currentDir == MoveDir.Left)
            hit = Physics2D.Raycast(transform.position, Vector2.left, attackRange, ~unitLayer);

        else
            hit = Physics2D.Raycast(transform.position, Vector2.right, attackRange, ~unitLayer);

        if (hit.collider != null)
        {
            Unit targetUnit = hit.collider.GetComponentInParent<Unit>();
            return targetUnit;
        }

        return null;
    }

    public virtual void Move(MoveDir dir)
    {
        currentDir = dir;
        unitFsm.ChangeState(UnitFSMState.Move);

        switch(dir)
        {
            case MoveDir.Left:
                unitAnimator.transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
                break;

            case MoveDir.Right:
                unitAnimator.transform.localRotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(1 * speed * Time.deltaTime, 0, 0);
                break;
        }
    }

    public virtual void Damage(int damage, bool bHitAni = true)
    {
        if(bHitAni)
            unitFsm.ChangeState(UnitFSMState.Hit);

        hp -= damage;

        if(hp < 0)
            hp = 0;

        hpbar.UpdateHpBar(hp, maxHp);
    }

    public virtual void RecoveryHp(int recoveryValue)
    {
        hp += recoveryValue;

        if (hp > maxHp)
            hp = maxHp;

        hpbar.UpdateHpBar(hp, maxHp);
    }
}

public class IdleState : FSMState<Unit>
{
    public IdleState(Unit unit) : base(unit)
    {

    }

    public override void OnEnter()
    {
        root.UnitAnimator.Play("Idle");
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}

public class MoveState : FSMState<Unit>
{
    public MoveState(Unit unit) : base(unit)
    {
        
    }

    public override void OnEnter()
    {
        root.UnitAnimator.Play("Move");
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}

public class HitState : FSMState<Unit>
{
    public HitState(Unit unit) : base(unit)
    {

    }

    public override void OnEnter()
    {
        root.UnitAnimator.Play("Hit");
    }

    public override void OnUpdate()
    {
        AnimatorStateInfo stateInfo = root.UnitAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Hit") && stateInfo.normalizedTime >= 1.0f)
        {
            root.UnitFSM.ChangeState(UnitFSMState.Idle);
        }
    }

    public override void OnExit()
    {

    }
}

public class AttackState : FSMState<Unit>
{
    public AttackState(Unit unit) : base(unit)
    {

    }

    public override void OnEnter()
    {
        root.UnitAnimator.Play("Attack");
    }

    public override void OnUpdate()
    {
        AnimatorStateInfo stateInfo = root.UnitAnimator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 1.0f)
        {
            root.UnitFSM.ChangeState(UnitFSMState.Idle);
        }
    }

    public override void OnExit()
    {

    }
}

public class DieState : FSMState<Unit>
{
    public DieState(Unit unit) : base(unit)
    {

    }

    public override void OnEnter()
    {
        root.UnitAnimator.Play("Die");
    }

    public override void OnUpdate()
    {

    }

    public override void OnExit()
    {

    }
}