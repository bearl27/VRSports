using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    public GameObject blockPrefab;
    public int rows = 5;
    public int columns = 10;
    public float blockWidth = 2.2f;
    public float blockHeight = 1.0f;

    void Start()
    {
        CreateBlockWall();
    }

    void CreateBlockWall()
    {
        Vector3 startPosition = new Vector3(
            -(columns - 1) * blockWidth / 2,
            (rows - 1) * blockHeight / 2,
            0
        );

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 blockPosition = new Vector3(
                    startPosition.x + col * blockWidth,
                    startPosition.y - row * blockHeight,
                    0
                );

                Instantiate(blockPrefab, blockPosition, Quaternion.identity);
            }
        }
    }
}