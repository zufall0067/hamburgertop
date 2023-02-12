using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject prefab;
    private GameManager gameManager;
    public float prefabHeight;

    void Start()
    {
        gameManager = GameManager.Instance;

        prefab = gameManager.burgers[0];

        prefabHeight = prefab.GetComponent<BoxCollider>().size.y * 1000;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {   
            Instantiate(prefab,this.transform.position, Quaternion.identity);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + prefabHeight, transform.position.z), 0.001f);
            prefab = gameManager.burgers[Random.Range(1, gameManager.burgers.Length)];
        }
    }
}
