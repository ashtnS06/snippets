using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Camera minimapCamera; // Reference to the minimap camera

    void LateUpdate()
    {
        Vector3 newPosition = player.position; // Get player's position
        newPosition.z = -10; // Set the camera's z position

        minimapCamera.transform.position = newPosition; // Update camera position to follow player
    }
}