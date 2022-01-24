using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class obstacleDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    public Vector3Int originCell;
    [SerializeField]
    public Tilemap tilemapWall;
    [SerializeField]
    public Tilemap tilemapObstacle;

    [SerializeField]
    public Tile wallTile;
    [SerializeField]
    public Tile destructibleTile;

    [SerializeField]
    public GameObject explosionPrefab;

    public void Explode(Vector2 worldPos){
        originCell = tilemapWall.WorldToCell(worldPos);

        ExplodeCell(originCell);
		if (ExplodeCell(originCell + new Vector3Int(1, 0, 0)))
		{
			ExplodeCell(originCell + new Vector3Int(2, 0, 0));
		}
		
		if (ExplodeCell(originCell + new Vector3Int(0, 1, 0)))
		{
			ExplodeCell(originCell + new Vector3Int(0, 2, 0));
		}
		
		if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0)))
		{
			ExplodeCell(originCell + new Vector3Int(-2, 0, 0));
		}
		
		if (ExplodeCell(originCell + new Vector3Int(0, -1, 0)))
		{
			ExplodeCell(originCell + new Vector3Int(0, -2, 0));
		}
    }

    bool ExplodeCell (Vector3Int cell){
        Tile tile = tilemapWall.GetTile<Tile>(cell);

        if(tile == wallTile){
            return false;
        }
        tile = tilemapObstacle.GetTile<Tile>(cell);
        if(tile == destructibleTile){
            tilemapObstacle.SetTile(cell, null);
        }
        
        Vector3 pos = tilemapWall.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, pos, Quaternion.identity);
        
        return true;
    }
}
