using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Character player;

    //DEBUG ONLY
    public Vector2 direction;
    public Vector3 mousePosition;
    public Vector3 lookDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        player.Move(direction);

        mousePosition = Input.mousePosition;
        mousePosition.z = 10;

        lookDirection = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        player.Look(lookDirection);

        if(Input.GetMouseButtonDown(0))
        {
            player.currentWeapon.Shoot();
        }
        
    }

    private void FixedUpdate()
    {
        //ADD FORCE HERE   ???
    }
}