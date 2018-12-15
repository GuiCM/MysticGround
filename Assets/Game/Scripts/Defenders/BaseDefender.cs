using UnityEngine;

/// <summary>
/// Represents a base defender that CAN ATTACK.
/// </summary>
public class BaseDefender : BaseEntity, IDefender
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private int damageCaused;

    private GameObject projectileHolder;

    private int layerMaskRayCast;
    private float distanceRay;
    private Vector3 initialRayPosition;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        layerMaskRayCast = LayerMask.GetMask("Attacker");
        initialRayPosition = transform.position;
        distanceRay = 8.15f - transform.position.x;

        projectileHolder = GameObject.Find("ProjectilesHolder");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsAttacking", HasEnemyInLine());
    }

    private void Attack()
    {
        BaseProjectile baseProjectile = Instantiate(projectile, transform.position, Quaternion.identity, projectileHolder.transform).GetComponent<BaseProjectile>();
        baseProjectile.SetDefender(this);
    }

    public virtual void CauseDamage(BaseAttacker baseAttacker)
    {
        baseAttacker.ReceiveDamage(damageCaused);
    }

    private bool HasEnemyInLine()
    {
        if (Physics2D.Raycast(initialRayPosition, Vector2.right, distanceRay, layerMaskRayCast))
        {
            return true;
        }

        return false;
    }
}