using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridSizeX = 10;
    public int gridSizeY = 10;
    public float tileSize = 1f;

    public float tileLife = 10f;
    
    //Start は、MonoBehaviour が作成された後、Update の最初の実行前に 1 回呼び出されます。
    void Start()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                GameObject tempTile = Instantiate(tilePrefab, new Vector3(x * tileSize, 0, y * tileSize), Quaternion.identity, transform);
                tempTile.transform.parent = this.gameObject.transform;
                tempTile.GetComponent<Tile>().life = tileLife;
            }
        }
    }
}
