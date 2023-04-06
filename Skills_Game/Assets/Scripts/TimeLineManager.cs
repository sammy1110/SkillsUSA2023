using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineManager : MonoBehaviour
{

    PlayableDirector playabale;

    public GameObject clone;
    public GameObject player;
    public Vector3 playPos;

    // Start is called before the first frame update
    void Start()
    {
        playabale= GetComponent<PlayableDirector>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playabale.playableAsset.duration <= playabale.time)
        {
            player.transform.position = playPos;

            Destroy(clone);
            Destroy(gameObject);
        }

        if (Time.time > 10)
        {
            Destroy(clone);
            Destroy(gameObject);
        }
    }
}
