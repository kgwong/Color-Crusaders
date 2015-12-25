using UnityEngine;
using System.Collections;

public class PlayerController : Ship {

    private Rigidbody2D rigid;

	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        SetColor(Ship.RED);
    }
	
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            primaryWeapon.Fire();
        }
        if (Input.GetMouseButton(1))
        {
            secondaryWeapon.Fire();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            Decelerate();
        }
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * -rotation * rotationSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            Accelerate();
        }
        transform.Translate(Vector3.up * currSpeed * Time.deltaTime);
    }
}
