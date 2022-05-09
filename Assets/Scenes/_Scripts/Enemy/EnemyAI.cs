using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Environment
{
    public Transform[] waypoints;
}

[RequireComponent(typeof(CoroutineHelper))]
public class EnemyAI : DestructibleObject
{

    [Header("Properties")]
    public float speed;
    public float chaseRange;
    public float attackRange;
    bool isFacingRight;

    public GameObject target;
    [SerializeField] States currState;

    public CoroutineHelper coroutineHelper;
    public Environment env;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currState = new IdleState(this, this.gameObject);
        coroutineHelper = GetComponent<CoroutineHelper>();
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currState = currState.Process();
    }


    #region  CanSeeTarget and CanAttackTarget
    bool CanSeeTarget(Transform _target)
    {

        return false;
    }

    public bool CanSeeTarget()
    {

        return CanSeeTarget(target.transform);
    }

    bool CanAttackTarget(Transform _target)
    {
        return false;
    }

    public bool CanAttackTarget()
    {
        return CanAttackTarget(target.transform);
    }

    #endregion

    #region  Move Towards Target
    public void MoveTowards(Transform targetObject)
    {
        //find Direction
        //change the velocity
        if (canMove())
        {
            int direction = findDirection(targetObject);
            //Handle Flip
            if (direction > 0 && !isFacingRight)
                Flip();
            else if (direction < 0 && isFacingRight)
                Flip();

            rb.velocity = new Vector2(direction * speed * Time.deltaTime, 0f);
        }
    }

    bool canMove()
    {
        //Cast ray to detect ground
        //if any of the ray doesn't strike the ground
        //stop the player
        //if moving right check for the last ray
        // if moving right check the first ray
        return true;
    }

    int findDirection(Transform targetObject)
    {
        if (targetObject.position.x > transform.position.x)
            return 1;
        return -1;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        float rotationY = isFacingRight ? 0 : 180;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    #endregion

}
