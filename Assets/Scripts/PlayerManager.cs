using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float tiempoEntreSaltos = 1.0f;
    private Vector3 nextPoint;
    private bool moving = false;
    private string lastMovement = "";

    private void Update()
    {
        if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.Q) && !lastMovement.Equals("right-down"))
            {
                MoveDiagonal(-1, 1);
                lastMovement = "left-up";
            }
            else if (Input.GetKeyDown(KeyCode.E) && !lastMovement.Equals("left-down"))
            {
                MoveDiagonal(1, 1);
                lastMovement = "right-up";
            }
            else if (Input.GetKeyDown(KeyCode.A) && !lastMovement.Equals("right-up"))
            {
                MoveDiagonal(-1, -1);
                lastMovement = "left-down";
            }
            else if (Input.GetKeyDown(KeyCode.D) && !lastMovement.Equals("left-up"))
            {
                MoveDiagonal(1, -1);
                lastMovement = "right-down";
            }
        }

        if (moving)
        {
            float step = Time.deltaTime / tiempoEntreSaltos;
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, step);
            if (transform.position == nextPoint)
            {
                moving = false;
            }
        }
    }

    private void MoveDiagonal(int xOffset, int yOffset)
    {
        nextPoint = transform.position + new Vector3(xOffset, yOffset, 0);
        moving = true;
    }
}
