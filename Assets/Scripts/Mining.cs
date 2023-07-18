using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mining : MonoBehaviour
{
    [SerializeField] private Tilemap dirtTilemap, grassTilemap, stoneTilemap, ironTilemap;
    [SerializeField] private float castDistance = 10f;
    [SerializeField] Transform raycastPoint;
    private RaycastHit2D hit;
    private Vector3 Direction;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastDirection();
        }
    }

    void RaycastDirection()
    {
        hit = Physics2D.Raycast(raycastPoint.position, Direction, castDistance);
        if (hit.collider)
        {
            dirtTilemap.SetTile(new Vector3Int((int) 0, (int) 0, 0), null);
            grassTilemap.SetTile(new Vector3Int((int) 0, (int) 0, 0), null);
            stoneTilemap.SetTile(new Vector3Int((int) 0, (int) 0, 0), null);
            ironTilemap.SetTile(new Vector3Int((int) 0, (int) 0, 0), null);
        }
    }
}
