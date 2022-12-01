using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Environment
{
    public Transform[] waypoints;
}
[System.Serializable]
public class EdgeDetection
{
    public Transform[] legs;
    public float detectorLength;
}

[RequireComponent(typeof(CoroutineHelper))]
public class EnemyAI : DestructibleObject
{

    [Header("Properties")]
    public float speed;
    public float chaseRange;
    public float attackRange;
    public float fireRate;
    bool isFacingRight;
    [SerializeField] States currState;

    public CoroutineHelper coroutineHelper;
    [Header("Environment Variables")]
    public GameObject target;
    public Environment env;
    public EdgeDetection edgeDetection;
    public LayerMask groundLayer;
    public LayerMask targetDetectionLayer;
    Rigidbody2D rb;
    public EnemyGunController gunController;

    //check for ground
    GroundCheck groundCheck;
    [SerializeField] bool isOnGround = false;
    float _initialGravity;

    void Start()
    {
        currState = new IdleState(this, this.gameObject);
        coroutineHelper = GetComponent<CoroutineHelper>();
        isFacingRight = true;
        rb = GetComponent<Rigidbody2D>();

        _initialGravity = rb.gravityScale;
        groundCheck = GetComponent<GroundCheck>();
        

    }

    // Update is called once per frame
    void Update()
    {
        currState = currState.Process();
        if(groundCheck.isGrounded())
        {
            rb.gravityScale = 0;
        }else{
            rb.gravityScale = _initialGravity;
        }
    }


    #region  CanSeeTarget and CanAttackTarget
    bool CanSeeTarget(Transform _target)
    {
        Vector2 direction = (_target.position - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        float uangle = Vector2.Angle( (isFacingRight ? 1 : -1)* Vector2.right,direction);

        if(uangle>0f && uangle<45f)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, chaseRange, targetDetectionLayer);
            Debug.DrawRay(transform.position, direction * chaseRange, Color.green);

            if (hit.collider != null)
            {

                if (hit.transform.gameObject.layer == target.gameObject.layer)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    return true;
                }
            }

        }

        return false;
    }

    public bool CanSeeTarget()
    {
        if (target != null)
            return CanSeeTarget(target.transform);
        return false;
    }

    bool CanAttackTarget(Transform _target)
    {
        if (CanSeeTarget(_target) && Vector2.Distance(_target.position, transform.position) < attackRange)
        { 
            return true;
        }

        return false;
    }

    public bool CanAttackTarget()
    {
        if (target != null)
            return CanAttackTarget(target.transform);
        return false;
    }

    #endregion

    #region  Move Towards Target
    public void MoveTowards(Transform targetObject)
    {
        int direction = findDirection(targetObject);
        //Handle Flip
        if (direction > 0 && !isFacingRight)
            Flip();
        else if (direction < 0 && isFacingRight)
            Flip();

        //change the velocity
        if (canMove())
        {
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, 0f);

        }
    }

    /*
        In chase state the enemy will be moving towards the player
    */
    public void MoveTowardPlayer()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > 0.2f)
            MoveTowards(target.transform);
    }

    public bool canMove()
    {
        //Cast ray to detect ground
        //if any of the ray doesn't strike the ground
        //stop the player
        //if moving right check for the last ray
        // if moving right check the first ray
        RaycastHit2D hit = Physics2D.Raycast(edgeDetection.legs[1].position, Vector2.down, edgeDetection.detectorLength, groundLayer);

        if (hit.collider == null)
        {
            return false;
        }

        return true;
    }

    int findDirection(Transform targetObject)
    {
        if (targetObject.position.x > transform.position.x)
            return 1;
        return -1;
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;

        float rotationY = isFacingRight ? 0 : 180;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    #endregion

}
