using UnityEngine;

public class PlayableAreaManager : SingletonType<PlayableAreaManager>
{
    private RectTransform playableAreaRect;

    [SerializeField]
    private int leftOffset;
    [SerializeField]
    private int bottomOffset;
    [SerializeField]
    private float unitMeasure;
    [SerializeField]
    private float currentPlayableAreaWidth;
    [SerializeField]
    private float currentPlayableAreaHeigth;

    private int nativeWidth = 1920;
    private int nativeHeigth = 1080;

    private byte[,] fieldUnits;

    private void Start()
    {
        fieldUnits = new byte[5, 10];
        playableAreaRect = GetComponent<RectTransform>();
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