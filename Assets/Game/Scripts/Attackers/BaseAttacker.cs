using UnityEngine;

public class BaseAttacker : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private int currentLife;
    [SerializeField]
    private int damageCaused;
    [SerializeField]
    private int baseLife;

    private float baseSpeed;
    private int isMoving;

    // Represent the current target that the monster is hitting
    private BaseDefender baseDefender;

    // Use this for initialization
    private void Start()
    {
        baseSpeed = 0.5f;
        currentLife = baseLife;
        currentSpeed = baseSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * isMoving * Time.deltaTime);
    }

    protected virtual void Attack()
    {
        // If defender is still alive, keep attacking
        if (baseDefender)
        {
            CauseDamage();
        }
        else // Otherwise, stop attacking and start moving again
        {
            animator.SetBool("IsAttacking", false);
            isMoving = 1;
        }
    }

    protected void CauseDamage()
    {
        baseDefender.ReceiveDamage(damageCaused);
    }

    public void ReceiveDamage(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Defender")
        {
            baseDefender = collision.GetComponent<BaseDefender>();

            // Stop moving
            isMoving = 0;
            animator.SetBool("IsAttacking", true);
        }
    }

    #region Movement speed methods

    private void IsMoving(int value)
    {
        isMoving = value;
    }

    protected void ChangeSpeed(float newSpeed)
    {
        // Change speed itself
        currentSpeed = newSpeed;

        // Change walk animation speed
        animator.SetFloat("SpeedMultiplier", (currentSpeed / baseSpeed));
    }

    public void DebuffSpeed(int debuffPercent)
    {
        float newSpeed = 0.3f;

        // TODO: Implement logic

        ChangeSpeed(newSpeed);
    }

    public void BuffSpeed(int buffPercent)
    {
        float newSpeed = 0.7f;

        // TODO: Implement logic

        ChangeSpeed(newSpeed);
    }

    #endregion Movement speed methods
}