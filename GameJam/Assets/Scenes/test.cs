using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class test : MonoBehaviour
{
    [SerializeField] List<Transform> cubes;

    Vector3 position = Vector3.zero;

    float decal = 0.5f;

    private void Start()
    {
        GetAllChhildren();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveCubes(decal);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveCubes(-decal);
        }
    }

    private void MoveCubes(float decal)
    {
        foreach (Transform cube in cubes)
        {
            Debug.Log(cube.gameObject.name + " ----- " + cube.position);

            position = cube.position;
            position += (cube.forward * decal);
            cube.position = position;

        }
    }

    private void GetAllChhildren()
    {
        cubes = GetComponentsInChildren<Transform>().ToList<Transform>();
        cubes.RemoveAt(0);
    }
}
