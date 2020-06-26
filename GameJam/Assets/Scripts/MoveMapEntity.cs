using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toolbox;
using System.Linq;

public class MoveMapEntity : MonoBehaviour
{
    [Tooltip("Déplacements possible par chaque cubes sur sont axe Z")]
    [SerializeField] private List<float> deplacements;


    [Tooltip("A cocher sur la preform sert de sol")]
    [SerializeField] private bool isTheGround;
    
    
    [Tooltip("Déplacements possible par chaque cubes sur sont axe Z Si il s'agit du sol")]
    [SerializeField] private List<float> deplacementsGround;


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
            int index = ToolBox.RandomBetween(0, (isTheGround? deplacementsGround.Count: deplacements.Count)- 1);
            position += (cube.forward * (isTheGround? deplacementsGround[index] : deplacements[index]));
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
    public bool IsTheGround { get => isTheGround; set => isTheGround = value; }
}
