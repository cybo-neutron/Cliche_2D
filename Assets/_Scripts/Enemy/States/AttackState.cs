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
        Debug.Log("Attack");
    }

    public override void Update()
    {
        base.Update();

        if (aiScript.CanAttackTarget())
        {
            //Keep Attacking
            if (!aiScript.coroutineHelper.isTimerRunning())
            {
                aiScript.coroutineHelper.StartTimer(aiScript.fireRate);
                aiScript.gunController.Shoot();
            }
        }
        else
        {
            //Goto Idle state
            nextState = new IdleState(aiScript, npc);
            Stage = STAGE.EXIT;
        }
    }

    public override void Exit()
    {
        aiScript.coroutineHelper.StopTimer();
        base.Exit();
    }
}
