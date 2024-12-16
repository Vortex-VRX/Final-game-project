using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distroy_back_city : MonoBehaviour

{

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.z > transform.position.z + 50.495f) 
        {
            City_Spawner.instance.Spawn_City();
            Destroy(this.gameObject);
        }
    }
}
