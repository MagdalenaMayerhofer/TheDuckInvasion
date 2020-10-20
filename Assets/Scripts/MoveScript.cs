using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed;

    public bool movingEnabled = true;

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    private void Start()
    {
        if (CharacterInformation.Character.Grandma == CharacterInformation.character)
        {
            speed = new Vector2(speed.x / 2, speed.y / 2);
        }
    }

    void Update()
    {
        if (movingEnabled)
        {
            // 2 - Movement
            movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        } else
        {
            movement = new Vector2(0, 0);
        }
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();


        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }
}