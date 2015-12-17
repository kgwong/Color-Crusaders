using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    private Rigidbody2D rigid;

    public float rotationSpeed;

	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetMouseButton(0))
        {
            primaryWeapon.Fire(gameObject);
        }
        if (Input.GetMouseButton(1))
        {
            secondaryWeapon.Fire(gameObject);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(rigid.velocity.x * 0.98f, rigid.velocity.y * 0.98f);            
        }
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * -rotation * rotationSpeed);
        
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.up * 10f);
        }
    }
}
