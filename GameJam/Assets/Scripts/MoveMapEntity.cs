using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toolbox;
using System.Linq;

public class MoveMapEntity : MonoBehaviour
{
    [Header("Deplacements possible par chaque cube dans sont axe Z")]
    [SerializeField] List<float> deplacements;

    private List<Transform> childrens;


    /// <summary>
    /// permet de bouger individuellement les cubes selon les mouvements disponibles
    /// </summary>
    [ContextMenu("MoveCubes")]
    public void Movecubes()
    {
        GetAllChildren();

        Vector3 position = Vector3.zero;

        foreach (Transform cube  in childrens)
        {
            position = cube.position;
            position += (cube.forward * deplacements[ToolBox.RandomBetween(0, deplacements.Count - 1)]);
            cube.position = position;
        }
    }

    /// <summary>
    /// Va rechercher les enfants
    /// </summary>
    private void GetAllChildren()
    {
        childrens = gameObject.GetComponentsInChildren<Transform>().ToList<Transform>();
        childrens.RemoveAt(0); // Remove le gmaeobject parent (celui ou on est actuellement) de la list
    }
}
