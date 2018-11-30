using UnityEngine;

public class BaseDefender : MonoBehaviour, IDefender
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject projectile;    
    [SerializeField]
    private int currentLife;
    [SerializeField]
    private int damageCaused;
    [SerializeField]
    private int baseLife;

    private GameObject projectileHolder;

    private int layerMaskRayCast;
    private float distanceRay;
    private Vector3 initialRayPosition;

    // Use this for initialization
    void Start()
    {
        currentLife = baseLife;

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

    public void ReceiveDamage(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
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