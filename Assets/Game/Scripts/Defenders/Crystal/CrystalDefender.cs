using System;

public class CrystalDefender : BaseEntity
{
    public float timeToGenerateNewCrystal;

    protected override void Start()
    {
        base.Start();
        timeToGenerateNewCrystal = 20f;

        print(DateTime.Now.ToLongTimeString());
        InvokeRepeating("GenerateCrystal", timeToGenerateNewCrystal, timeToGenerateNewCrystal);
    }

    public void GenerateCrystal()
    {
        print(DateTime.Now.ToLongTimeString());
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