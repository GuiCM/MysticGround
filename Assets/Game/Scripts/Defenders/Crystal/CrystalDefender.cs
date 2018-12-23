using UnityEngine;

public class CrystalDefender : BaseEntity
{
    [Range(10f, 30f)]
    public float timeToGenerateNewCrystal;

    protected override void Start()
    {
        base.Start();
        timeToGenerateNewCrystal = 20f;

        InvokeRepeating("GenerateCrystal", timeToGenerateNewCrystal, timeToGenerateNewCrystal);
    }

    public void GenerateCrystal()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CrystalGenerated"))
        {
            ResetGeneration();
        }

        animator.SetTrigger("GenerateCrystal");
    }

    public void CollectResource()
    {
        print("Adiciona gold no player.");
    }

    public void ResetGeneration()
    {
        animator.SetTrigger("CrystalPieceCollected");
        CollectResource();
    }
}