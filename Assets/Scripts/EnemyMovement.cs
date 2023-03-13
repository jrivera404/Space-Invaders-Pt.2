using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float leftRightSpeed;
    bool WeShouldGoRight = true;
    Vector3 dropAmount = new Vector3(0,-1,0);
    public Transform myTransform;
    float boundaryLeft = -5.6f;
    float boundaryRight = 5.6f;

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x >= boundaryRight) || (transform.position.x <= boundaryLeft))
        {
            WeShouldGoRight = !WeShouldGoRight;
            DropALevel();
            print("Switching directions; now moving " + (WeShouldGoRight ? "Right" : "Left"));
        }

        Move(WeShouldGoRight);
    }

    void Move(bool moveRight)
    {
        float movementX = moveRight ? leftRightSpeed : -leftRightSpeed;
        transform.Translate(new Vector3(movementX * Time.deltaTime, 0, 0));
    }

    void DropALevel()
    {
        transform.Translate(dropAmount);
    }
}
