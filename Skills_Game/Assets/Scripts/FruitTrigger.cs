using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTrigger : MonoBehaviour
{
    GardenerScript gardener;

    // Start is called before the first frame update
    void Start()
    {
        gardener = FindObjectOfType<GardenerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        gardener.livingFruit--;
    }
}
