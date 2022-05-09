using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : States
{
    public AttackState(EnemyAI _aiScript, GameObject _npc) : base(_aiScript, _npc)
    {
        State = STATE.ATTACK;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (aiScript.CanAttackTarget())
        {
            //Keep Attacking
        }
        else
        {
            //Goto Idle state
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
