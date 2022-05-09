using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : States
{


    public IdleState(EnemyAI _aiScript, GameObject _npc) : base(_aiScript, _npc)
    {
        State = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idle state");
        aiScript.coroutineHelper.StartTimer(1f);
    }

    public override void Update()
    {
        base.Update();


        if (aiScript.coroutineHelper.isTimerRunning())
        {
            //Stay idle
        }
        else
        {
            nextState = new PatrolState(aiScript, npc);
            Stage = STAGE.EXIT;
        }

    }

    public override void Exit()
    {
        base.Exit();
    }


}
