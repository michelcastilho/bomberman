using UnityEngine;
using UnityEngine.Tilemaps;

public class bombSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    public Vector3 worldPos;

    [SerializeField]
    public Vector3Int cell;

    public Tilemap tilemap;

    public GameObject bombPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cell = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPos = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
        }
    }
}
