using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenerScript : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject Boss;
    public GameObject zombies;
    public Transform[] Zompositions;
    public bool TriggerZombie;
    public int livingFruit = 3;
    public List<GameObject> zombys;
    public Transform bossSpawn;
    bool BossSpawned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        
         if (livingFruit == 0 && !TriggerZombie)
         {
            for (int b = 0; b < Zompositions.Length; b++)
            {
                zombys.Add(Instantiate(zombies, Zompositions[b].position, Quaternion.identity));                          
            }
            TriggerZombie= true;
         }

         if (TriggerZombie && zombys.Count == 0 && !BossSpawned)
         {
            Instantiate(Boss, bossSpawn.position, Quaternion.identity);
            BossSpawned= true;
         }
        
         for (int i = 0; i < zombys.Count; i++)
         {
            if (zombys[i] == null)
            {
                zombys.RemoveAt(i);
            }
         }
    }
}
