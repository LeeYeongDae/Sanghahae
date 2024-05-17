using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap : MonoBehaviour
{
    GridLayout gridLayout;
    public Tilemap tilemap;

    void onMouseOver()
    {
        try
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 3.5f);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.zero);

            if (this.tilemap = hit.transform.GetComponent<Tilemap>())
            {
                this.tilemap.RefreshAllTiles();

                int x, y;
                x = this.gridLayout.WorldToCell(ray.origin).x;
                y = this.gridLayout.WorldToCell(ray.origin).y;

                Vector3Int v3Int = new Vector3Int(x, y, 0);
            }
        }
        catch (NullReferenceException)
        {

        }
    }

    private void RefreshAllTiles()
    {
        throw new NotImplementedException();
    }

    void onMouseExit()
    {
        this.tilemap.RefreshAllTiles();
    }

}
