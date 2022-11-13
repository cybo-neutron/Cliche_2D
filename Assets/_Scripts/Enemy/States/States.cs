using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum STATE
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK
}

public enum STAGE
{
    ENTER,
    UPDATE,
    EXIT
}

public class States
{
    public STATE State;
    public STAGE Stage;

    protected EnemyAI aiScript;
    protected GameObject npc;
    protected States nextState;

    public States(EnemyAI _aiScript, GameObject _npc)
    {
        aiScript = _aiScript;
        npc = _npc;
        Stage = STAGE.ENTER;
    }

    public States Process()
    {
        if (Stage == STAGE.ENTER) Enter();
        else if (Stage == STAGE.UPDATE) Update();
        else
        {
            Exit();
            return nextState;
        }

        return this;
    }

    public virtual void Enter()
    {
        Stage = STAGE.UPDATE;
    }

    public virtual void Update()
    {
        Stage = STAGE.UPDATE;

    }

    public virtual void Exit()
    {
        Stage = STAGE.EXIT;

    }
}
