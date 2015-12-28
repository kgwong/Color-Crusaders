using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    public static Color[] COLOR_DEFINIIONS = new[] 
    {
        new Color(1f, 0.128f, 0f), //RED
        new Color(1f, 1f, 1f), //WHITE
        new Color(0, 0.297f, 1f) //BLUE
    };

    public enum ShipColor{
        RED = 0,
        NEUTRAL = 1,
        BLUE = 2
    }

    public ShipController controller;
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public float minSpeed;
    public float currSpeed;
    public float maxSpeed;

    public float rotationSpeed;

    [SerializeField]
    private ShipColor color;

    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().color);
        SetColor(color);
    }

    void Update()
    {
        if (controller) controller.ControllerUpdate(this);
        Move();
    }

    public void SetColor(ShipColor color)
    {
        this.color = color;
        GetComponent<SpriteRenderer>().color = COLOR_DEFINIIONS[(int)color];
        primaryWeapon.SetColor(color);
        secondaryWeapon.SetColor(color);
    }

    public ShipColor GetColor()
    {
        return color;
    }

    public void Move()
    {
        transform.Translate(Vector3.up * currSpeed * Time.deltaTime);
    }

    public void Rotate(float rotation)
    {
        transform.Rotate(Vector3.forward * rotation * rotationSpeed);
    }

    public void Accelerate()
    {
        currSpeed += .1f;
        ClampSpeed();

        //physics based acceleration
        /*if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.up * 10f);
        }*/
    }

    public void Decelerate()
    {
        currSpeed -= .1f;
        ClampSpeed();

        //physics based slow down
        //rigid.velocity = new Vector2(rigid.velocity.x * 0.98f, rigid.velocity.y * 0.98f);
    }

    private void ClampSpeed()
    {
        currSpeed = Mathf.Clamp(currSpeed, minSpeed, maxSpeed);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
