using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movements
    Rigidbody2D rb;
    Vector2 direction; 
    public int moveSpeed;

    //gameplay
    GameObject wallPrefab;
    Vector2 lastPos;
    Collider2D lastWallCol;
    public GameObject explosion;

    bool canBoost = true;

    //base functions
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.up;

        wallPrefab = Resources.Load("Wall" + gameObject.tag) as GameObject;
    }

    void Update()
    {
        HandleKeys();
        SetLastWallSize(lastWallCol, lastPos, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != lastWallCol)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    //custom functions
    void HandleKeys()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            if(direction != Vector2.down)
            {
                direction = Vector2.up;
                CreateWall();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (direction != Vector2.up)
            {
                direction = Vector2.down;
                CreateWall();
            } 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (direction != Vector2.left)
            {
                direction = Vector2.right;
                CreateWall();
            }  
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            if (direction != Vector2.right)
            {
                direction = Vector2.left;
                CreateWall();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canBoost)
                StartCoroutine("ActivateBoost");
        }

            rb.velocity = direction * moveSpeed;
    }

    IEnumerator ActivateBoost()
    {
        canBoost = false;
        moveSpeed += 4;
        yield return new WaitForSeconds(3);
        moveSpeed -= 4;
    }

    void CreateWall()
    {
        lastPos = transform.position;
        GameObject wallGo = Instantiate(wallPrefab, transform.position, Quaternion.identity);
        lastWallCol = wallGo.GetComponent<Collider2D>();
    }

    private void SetLastWallSize(Collider2D col, Vector2 posStart, Vector2 posEnd)
    {
        if (col)
        {
            col.transform.position = posStart + (posEnd - posStart) / 2;
            float wallSize = Vector2.Distance(posStart, posEnd);

            if (posStart.x != posEnd.x)
            {
                col.transform.localScale = new Vector2(wallSize+1, 1);
            }
            else
            {
                col.transform.localScale = new Vector2(1, wallSize+1);
            }
        }
    }
}
