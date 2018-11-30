using UnityEngine;

public class PlayableAreaManager : SingletonType<PlayableAreaManager>
{
    [SerializeField]
    private Transform defendersHolder;
    private RectTransform playableAreaRect;
    private Player player;

    private int leftOffset;
    private int bottomOffset;
    private float unitMeasure;
    private float currentPlayableAreaWidth;
    private float currentPlayableAreaHeigth;

    private int nativeWidth = 1920;
    private int nativeHeigth = 1080;

    private byte[,] fieldUnits;

    private void Awake()
    {
        playableAreaRect = GetComponent<RectTransform>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        fieldUnits = new byte[5, 10];
        SetCurrentPlayableAreaSize();
    }

    private void SetCurrentPlayableAreaSize()
    {
        currentPlayableAreaWidth = ((Screen.width * playableAreaRect.sizeDelta.x) / nativeWidth);
        currentPlayableAreaHeigth = ((Screen.height * playableAreaRect.sizeDelta.y) / nativeHeigth);

        unitMeasure = (currentPlayableAreaWidth / 10);

        Vector3 posInPixels = Camera.main.WorldToScreenPoint(transform.position);

        leftOffset = (int)(posInPixels.x - (currentPlayableAreaWidth / 2));
        bottomOffset = (int)(posInPixels.y - (currentPlayableAreaHeigth / 2));
    }

    private void OnMouseDown()
    {
        // First, check if have some defender selected to place
        if (player.SelectedDefender != null)
        {
            // Then check if the player has currency enough
            if (player.HaveMoney())
            {
                PlaceDefender();

                player.ChangeCurrency();
                player.ResetSelectedDefender();
            }
        }
        else
        {
            print("Nothing selected.");
        }
    }

    private void PlaceDefender()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 coordinates = GetCoordinateNormalized(mousePos);
        Vector2 position = GetCoordinate(coordinates);

        fieldUnits[(int)coordinates.y, (int)coordinates.x] = 1;

        Instantiate(player.SelectedDefender.gameObject, new Vector3(position.x, position.y, 5), Quaternion.identity, defendersHolder);
    }

    public Vector2 GetCoordinateNormalized(Vector2 position)
    {
        Vector2 coordinateNormalized;

        coordinateNormalized.x = Mathf.FloorToInt((position.x - leftOffset) / unitMeasure);
        coordinateNormalized.y = Mathf.FloorToInt((position.y - bottomOffset) / unitMeasure);

        return coordinateNormalized;
    }

    public Vector2 GetCoordinate(Vector2 coordinateNormalized)
    {
        Vector2 coordinate;
        coordinate.x = (coordinateNormalized.x * unitMeasure) + leftOffset + (unitMeasure / 2);
        coordinate.y = (coordinateNormalized.y * unitMeasure) + bottomOffset + (unitMeasure / 2);

        return Camera.main.ScreenToWorldPoint(coordinate);
    }
}