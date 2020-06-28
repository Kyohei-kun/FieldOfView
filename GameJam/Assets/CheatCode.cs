using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCode : MonoBehaviour
{
    private Disappear[] visibleObjects;

    // Start is called before the first frame update
    void Start()
    {
        visibleObjects = FindObjectsOfType<Disappear>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            foreach (Disappear item in visibleObjects)
            {
                item.ObjectVisibleState(true);
            }
        }
    }
}
