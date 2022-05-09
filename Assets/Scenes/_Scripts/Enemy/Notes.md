# Enemy AI
## Hierarchy
> DestructibleObject
>> EnemyAI
>>> Stationary  
>>> StationaryAttack (Stationary + Attacking)  
>>> Moving  
>>> MovingAttack (Moving + Attacking)

---
### EnemyAI

**Functions**
- Move()
- Flip()
- CanSeeTarget()
- CanAttackTarget()
- isOnEdge()

***Move***  

    direction = isFacingRight ? 1 : -1;
    rb.velocity = new Vector2(direction*speed,0)

Change the direction of enemy when the in idle state
Check the target waypoint or the target -> if the target is to the right of enemy a

***Flip*** 

    isFacingRight = !isFacingRight
    rotation.y = isFacingRight ? 0 : 180


***CanSeeTarget***

    CanSeeTarget(target)
        ^
        |
    CanSeeTarget()

`chaseRange`
Raycast to enemy with a `chaseRange` distance

