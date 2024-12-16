using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class City_Spawner : MonoBehaviour
{

    public static City_Spawner instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] GameObject City_Tile;
    [SerializeField] Transform spawn_pos;
    
    void Start()
    {
        
    }
    public void Spawn_City()
    {
        Instantiate(City_Tile,spawn_pos.position,quaternion.identity);
        spawn_pos.position = new Vector3(spawn_pos.transform.position.x,spawn_pos.transform.position.y,spawn_pos.transform.position.z + 58f);
    }

private void OnDestroy()
{
    Destroy(instance);
}

}
