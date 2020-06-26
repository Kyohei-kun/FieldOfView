using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;
using TreeEditor;
using Toolbox;

public class EntityMapCreator : MonoBehaviour
{
    [SerializeField] private GameObject preform;

    [Tooltip("A cocher sur la preform sert de sol")]
    [SerializeField] private bool isTheGround;

    [Space] [SerializeField] private List<GameObject> prefabsCubes;


    private MoveMapEntity moveMapEntity;


    void Start()
    {
            GenerateCubesPrefab();
    }

    [ContextMenu("GenerateCubes")]
    private void GenerateCubesPrefab()
    {
        GameObject temp = Instantiate(prefabsCubes[ToolBox.RandomBetween(0, prefabsCubes.Count - 1)]);
        temp.transform.position = transform.position;
        temp.transform.SetParent(transform);
        temp.transform.rotation = transform.rotation;

        Destroy(preform);

        temp.GetComponent<MoveMapEntity>().IsTheGround = isTheGround;
        //Une fois créée on lui demande de bouger individuellement ses cubes.
        temp.GetComponent<MoveMapEntity>().Movecubes();
        
    }
}
