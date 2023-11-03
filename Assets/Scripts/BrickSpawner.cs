using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class BrickSpawner : MonoBehaviour
{
 

    [SerializeField]
    int rows, cols;
   

    [SerializeField]
    float xDistanceBeetweenBricks = 1, yDistanceBeetweenBricks = -0.3f;

    [SerializeField]
    GameObject brickPrefab;

    void Start()
    {
        Gamemanager.gamemanager.setSpawnedBricks(rows * cols);
        SpawnBricks();
       
    }

    void SpawnBricks()
    {
        for (int i = 0; i < rows; i++)                      //spawno i bricks partendo da un brick di partenza e, in base alla sua posizione, genero il brick successivo che è distanziato 1 orizzontalmente e -0,3 verticalmente (con il meno perchè verso il basso)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector2 newBrickPosition = new Vector2(transform.position.x + (j * xDistanceBeetweenBricks), transform.position.y + (i * yDistanceBeetweenBricks));

                GameObject.Instantiate(brickPrefab, newBrickPosition, Quaternion.identity, transform);  //instanzio il brick nuovo con la posizione che mi genero di volta in volta

                
            }
        }
    }

    void Update()
    {
        
    }
}
