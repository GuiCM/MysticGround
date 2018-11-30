using UnityEngine;

public class Player : MonoBehaviour
{
    public BaseDefender SelectedDefender { get; private set; }

    public int Currency
    {
        get
        {
            return currency;
        }
        private set
        {
            currency = value;
        }
    }

    [SerializeField]
    private GameObject[] defenders;
    [SerializeField]
    private int currency;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SelectedDefender = defenders[0].GetComponent<BaseDefender>();
        }
    }

    public bool HaveMoney()
    {
        return currency >= SelectedDefender.Price;
    }

    public void ResetSelectedDefender()
    {
        SelectedDefender = null;
    }

    public void ChangeCurrency()
    {
        if (SelectedDefender != null)
        {
            currency -= SelectedDefender.Price;
        }
    }
}