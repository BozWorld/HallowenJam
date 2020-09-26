using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private float timer = 0;
    private Player player;

    [SerializeField]
    private Turns turns;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    private Vector2 GetMovementInput()
    {
        Vector2 axis = new Vector2(0, 0);

        if (Input.GetKeyDown(KeyCode.Z))
            axis.y = 1;
        else if (Input.GetKeyDown(KeyCode.S))
            axis.y = -1;
        else if (Input.GetKeyDown(KeyCode.D))
            axis.x = 1;
        else if (Input.GetKeyDown(KeyCode.Q))
            axis.x = -1;

        return axis;
    }

    private Collider2D GetFrontEntity(Vector2 direction)
    {
        Collider2D[] frontEntity;

        frontEntity = Physics2D.OverlapCircleAll(new Vector2(transform.position.x + player.GetSquareSize() * direction.x, transform.position.y + player.GetSquareSize() * direction.y), 0.5f);

        if (frontEntity.Length != 0)
            return frontEntity[0];

        return null;
    }

    private Collider2D GetSameSquareEntity()
    {
        Collider2D[] sameSquareEntity;

        sameSquareEntity = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 0.5f);

        if (sameSquareEntity.Length > 1)
            return sameSquareEntity[1];

        return null;
    }

    private Collider2D GetRaycastHit()
    {
        RaycastHit2D hit = new RaycastHit2D();
        List<Vector2> directions = new List<Vector2>()
        {
            Vector2.up,
            Vector2.down,
            Vector2.right,
            Vector2.left
        };

        for (int i = 0;  i < 4; i ++)
        {
            hit = Physics2D.Raycast(transform.position, directions[i]);
            MovableEntity entity = null;

            if (hit.collider != null)
            {
                entity = hit.collider.gameObject.GetComponent<MovableEntity>();
            }

            if (entity != null && entity.InteractOnRaycast())
            {
                if (entity.GetDirection().x == -directions[i].x && entity.GetDirection().y == -directions[i].y)
                    return hit.collider;
            }
        }

        return null;
    }

    private void Update()
    {
        Vector2 movementInput = GetMovementInput();
        Collider2D sameSquareEntity = GetSameSquareEntity();
        Collider2D raycastHit = GetRaycastHit();

        timer += Time.deltaTime;

        if (movementInput.x != 0 || movementInput.y != 0 && !player.IsEntityMoving() && timer > 0.2f)
        {
            Collider2D frontEntity = GetFrontEntity(movementInput);

            player.canChangeMinionCount2 = true;
            if (frontEntity == null || frontEntity.gameObject.GetComponent<LevelEntity>().CanGoThrough())
            {
                player.MoveEntity(movementInput, false);
                turns.turns += 1;
            }
            else
            {
                player.MoveEntity(movementInput, true);
            }

            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && timer > 0.2f)
        {
            timer = 0;
            turns.turns += 1;
            Collider2D frontEntity = GetFrontEntity(player.GetDirection());

            if (frontEntity != null)
                frontEntity.gameObject.GetComponent<LevelEntity>().Interact(player);
        }

        if (sameSquareEntity != null && sameSquareEntity.gameObject.GetComponent<LevelEntity>().InteractOnSameSquare())
            sameSquareEntity.gameObject.GetComponent<LevelEntity>().Interact(player);
        if (raycastHit != null)
            raycastHit.gameObject.GetComponent<LevelEntity>().Interact(player);
    }
}
