using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Unit
{
    protected override void Update()
    {
        base.Update();

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Move(MoveDir.Left);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            UnitFSM.ChangeState(UnitFSMState.Idle);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(MoveDir.Right);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            UnitFSM.ChangeState(UnitFSMState.Idle);
        }

        if (UnitFSM.CurrentState.Equals(UnitFSMState.Idle) || UnitFSM.CurrentState.Equals(UnitFSMState.Move))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                UnitFSM.ChangeState(UnitFSMState.Attack);

                SkillManager.
            }
        }
    }
}