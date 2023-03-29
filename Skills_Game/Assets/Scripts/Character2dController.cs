using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Character2dController : MonoBehaviour
{
    public float MovementSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;
    public static bool hasFrog;
    public static bool hasFruit;
    public bool canFire = true;
    public float firecoolDown = 0.5f;
    public string direction;
    public GameObject bulletPrefab;
    public string animationState;
    public string currentWeapon;
    public GameObject[] fruits;
    public int fruitIndex;

    Vector2 movement;

    public Inventory inventory;


    public void Start()
    {
        transform.position = SceneSwitcher.globalspawn;
        direction = "Backward";
    }
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            if (movement.y > 0) 
            {
                direction = "Forward";
                animator.SetInteger("Direction", 1);
            }
            else if (movement.y < 0) 
            {
                direction = "Backward";
                animator.SetInteger("Direction", 0);
            }
            else if (movement.x > 0)
            {
                direction = "Right";
                animator.SetInteger("Direction", 2);
            }
            else if (movement.x < 0)
            {
                direction = "Left";
                animator.SetInteger("Direction", 3);
            }

            animator.speed = 1;
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.speed = 0;
            animator.SetBool("isMoving", false);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (hasFrog)
        {
            animator.SetLayerWeight(1, 1);
        }

        if(hasFruit && Input.GetKey(KeyCode.Mouse0) && canFire && !Inventory.isOpen) 
        {
            StartCoroutine(restockFruit());
            Shoot();         
        }

        if(direction != animationState)
        {
            animationState = direction;
            animator.SetTrigger(animationState);
        }
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime);
    }

    IEnumerator restockFruit()
    {
        yield return new WaitForSeconds(firecoolDown);
        canFire = true;
    }

    public void Shoot()
    {
        canFire = false;     

        switch (currentWeapon)
        {
            case "Apple":
                if (Inventory.appleAmmo > 0)
                {
                    Inventory.appleAmmo -= 1;
                    fruitIndex = 0;
                    inventory.fruitBeGone("Apple");
                }
                else
                {
                    return;
                }
                break;

            case "Cherries":
                if (Inventory.cherryAmmo > 0)
                {
                    Inventory.cherryAmmo -= 1;
                    fruitIndex = 1;
                    inventory.fruitBeGone("Cherries");
                    Debug.Log("Fire Cherry: " + Inventory.cherryAmmo);
                }
                else
                {
                    Debug.Log("failed");
                    return;
                }
                break;
            default:
                return;
        }

        if (direction == "Forward")
        {
            Instantiate(fruits[fruitIndex], transform.position + Vector3.up, Quaternion.identity, null);
        }
        else if (direction == "Backward")
        {
            Instantiate(fruits[fruitIndex], transform.position + Vector3.down, Quaternion.Euler(0, 0, 180), null);
        }
        else if (direction == "Right")
        {
            Instantiate(fruits[fruitIndex], transform.position + Vector3.right, Quaternion.Euler(0, 0, -90), null);
        }
        else if (direction == "Left")
        {
            Instantiate(fruits[fruitIndex], transform.position + Vector3.left, Quaternion.Euler(0, 0, 90), null);
        }      
    }

    public void SwitchWeapon(string name)
    {
        currentWeapon = name;
    }
}
