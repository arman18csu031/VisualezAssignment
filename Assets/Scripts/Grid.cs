using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject gridPrefab;
    [SerializeField] int gridSize;
    public LoadTextures loadtexture;
    private GameObject[,] grid = new GameObject[8,8]; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateGrid", 2f);
        CreateGrid(); 
    }
    void CreateGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = Instantiate(gridPrefab, new Vector3(i, j, 0), Quaternion.identity);
                if (i % 2 != 0 && j % 2 != 0 || i % 2 == 0 && j % 2 == 0)
                {
                    grid[i,j].GetComponent<SpriteRenderer>().sprite = loadtexture.sprite[0];
                }
                else
                {
                    grid[i, j].GetComponent<SpriteRenderer>().sprite = loadtexture.sprite[1];
                }
            }
        }
    }
    void ApplyingTexture(GameObject _grid, int spriteIndex)
    {

        _grid.GetComponent<SpriteRenderer>().sprite = loadtexture.sprite[spriteIndex];

        
    }

}
