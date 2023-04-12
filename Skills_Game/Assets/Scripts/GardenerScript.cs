using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenerScript : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject zombies;
    public Transform[] Zompositions;
    public bool TriggerZombie;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; fruits[i] == null; i++)
        {
            if (i == 3 && !TriggerZombie)
            {
                for (int b = 0; b < Zompositions.Length; b++)
                {
                    Instantiate(zombies, Zompositions[b].position, Quaternion.identity);
                }
                TriggerZombie= true;
                Destroy(gameObject);
            }
        }
    }
}
