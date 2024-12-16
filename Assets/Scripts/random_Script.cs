using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_Script : MonoBehaviour
{

    public GameObject[] difficulty;
    public bool isDefault;
    // Start is called before the first frame update
    void Start()
    {
        if (!isDefault)
        {   
        int random_value = Random.Range(0,difficulty.Length);
        difficulty[random_value].gameObject.SetActive(true);
        }
    }
}
