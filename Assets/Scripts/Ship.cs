using UnityEngine;
using System.Collections;

public enum ClockDirecton
{
    NONE = 0,
    CLOCKWISE = -1,
    COUNTER_CLOCKWISE = 1
}

public class Ship : MonoBehaviour {

    public static Color[] COLOR_DEFINITIONS = new[] 
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

    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public float minSpeed;
    public float currSpeed;
    public float maxSpeed;

    public float rotationSpeed;

    [SerializeField]
    private ShipColor color;

    private ShipController controller;

    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().color);
        SetColor(color);

        controller = gameObject.AddComponent<BasicAIController>();
    }

    void Update()
    {
        Move();
    }

    public void SetColor(ShipColor color)
    {
        this.color = color;
        GetComponent<SpriteRenderer>().color = COLOR_DEFINITIONS[(int)color];
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

    public void Rotate(ClockDirecton clockDirection)
    {
        Rotate((int)clockDirection);
    }

    //Should be between -1 and 1. rotationSpeed handles the speed. 
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

    public void ChangeController<T>() 
       where T : ShipController
    {
        Destroy(controller);
        controller = gameObject.AddComponent<T>();
    }
}
