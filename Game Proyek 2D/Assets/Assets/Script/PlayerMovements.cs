using System.Collections;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector2 input;

    public LayerMask solidObjectsLayer; // Untuk deteksi dinding atau benda solid

    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Biar nggak bisa diagonal
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                Vector3 targetPos = transform.position + new Vector3(input.x, input.y, 0);

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }
}
