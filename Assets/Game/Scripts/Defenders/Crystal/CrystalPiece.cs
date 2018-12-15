using UnityEngine;

public class CrystalPiece : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void OnMouseDown()
    {
        animator.SetTrigger("CrystalPieceCollected");
        GetComponentInParent<CrystalDefender>().CollectResource();
    }
}