using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject prefab;
    private GameManager gameManager;
    private Vector3 mousePos;
    private Vector3 transPos;
    private Vector3 targetPos;
    public float prefabHeight;
    public Camera mainCamera;

    void Start()
    {
        gameManager = GameManager.Instance;

        prefab = gameManager.burgers[0];

        prefabHeight = prefab.GetComponent<BoxCollider>().size.y * 1000;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            transPos = Camera.main.ScreenToWorldPoint(mousePos);
            targetPos = new Vector3(transPos.x, transform.position.y, transPos.y);
            this.gameObject.transform.position = targetPos;
        }

        if(Input.GetMouseButtonUp(0)) 
        {   
            Instantiate(prefab,this.transform.position, Quaternion.identity);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + prefabHeight, transform.position.z), 0.001f);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + prefabHeight, mainCamera.transform.position.z), 0.001f);
            prefab = gameManager.burgers[Random.Range(1, gameManager.burgers.Length)];
        }
    }
}
