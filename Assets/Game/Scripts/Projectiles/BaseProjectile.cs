using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField]
    private float currentSpeed;

    private IDefender defender;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
    }

    public void SetDefender(IDefender defender)
    {
        this.defender = defender;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attacker")
        {
            defender.CauseDamage(collision.GetComponent<BaseAttacker>());

            Destroy(gameObject);
        }
    }
}