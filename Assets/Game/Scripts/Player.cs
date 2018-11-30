using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] defenders;

    public GameObject selectedDefender;

    private bool canPlaceDefender;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            canPlaceDefender = true;
            selectedDefender = defenders[0];
        }
    }

    private void OnMouseDown()
    {

    }
}