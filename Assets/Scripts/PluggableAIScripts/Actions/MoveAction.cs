using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class MoveAction : Activity
{
    [SerializeField] private GameObject parent;
    private BoxCollider2D col;
    private Rigidbody2D rb;
    private Vector2 pos;
    private float speed = 5f;
    private bool playerDetected;
    private void Awake()
    {
        OnDrawGizmos();
        playerDetected = false;
        rb.GetComponent<Rigidbody2D>();
        col.GetComponent<BoxCollider2D>();
        pos = parent.transform.position;
    }

    public override void Act(StateController controller)
    {
        MovementBehaviour();
    }

    private void MovementBehaviour()
    {
        if (playerDetected)
        {
            PlayerInvolvedBehaviour();
        }
        else
        {
            PatrolBehaviour();
        }
    }

    private void PatrolBehaviour()
    {
        rb.MovePosition(Vector2.right);
    }

    private void PlayerInvolvedBehaviour()
    {
        Collider2D[] player =  Physics2D.OverlapCircleAll(pos, 4f);

        foreach (var p in player)
        {
            if (p.gameObject.CompareTag("Player"))
            {
                playerDetected = true;
                Debug.Log("hey player how are you");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, 0.5f);
    }
}
