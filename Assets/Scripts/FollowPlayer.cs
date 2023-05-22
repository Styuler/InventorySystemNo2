using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{ 
    [SerializeField] private Transform Player;

    private void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, -10);
    }
}
