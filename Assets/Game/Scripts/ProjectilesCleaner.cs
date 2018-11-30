using UnityEngine;

public class ProjectilesCleaner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}