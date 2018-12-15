using UnityEngine;

/// <summary>
/// Represent the most basic entity on the field, with no attacking behaviour.
/// </summary>
public class BaseEntity : MonoBehaviour
{

    public int Price
    {
        get
        {
            return price;
        }
    }

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected int baseLife;
    [SerializeField]
    protected int currentLife;
    [SerializeField]
    private int price;

    // Use this for initialization
    protected virtual void Start()
    {
        currentLife = baseLife;
    }

    public void ReceiveDamage(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}