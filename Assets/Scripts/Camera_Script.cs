using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player's transform

    void LateUpdate()
    {
        // Update the camera's position to follow the player's z position and adjust y and z as needed
        transform.position = new Vector3(transform.position.x, transform.position.y  , player.position.z - 8f);
    }
}
