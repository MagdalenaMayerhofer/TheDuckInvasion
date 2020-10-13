using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public GameObject rubberDuckPrefab;
    float creationIntervall = 60;

    // Start is called before the first frame update
    void Start()
    {
        Utils.CreateRubberDuckInstance(rubberDuckPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        creationIntervall--;

        if (creationIntervall == 0)
        {
            creationIntervall = 60;
            Utils.CreateRubberDuckInstance(rubberDuckPrefab);
        }
    }
}
