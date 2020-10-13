using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float creationIntervall = 120;

    // Start is called before the first frame update
    void Start()
    {
        Utils.Instance.CreateRubberDuckInstance();
    }

    // Update is called once per frame
    void Update()
    {
        creationIntervall--;

        if (creationIntervall == 0)
        {
            creationIntervall = 120;
            Utils.Instance.CreateRubberDuckInstance();
        }
    }
}
