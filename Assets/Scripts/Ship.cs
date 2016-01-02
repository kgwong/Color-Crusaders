using UnityEngine;
using System.Collections;

public enum ClockDirecton
{
    NONE = 0,
    CLOCKWISE = -1,
    COUNTER_CLOCKWISE = 1
}

public class Ship : MonoBehaviour {

    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public float minSpeed;
    public float currSpeed;
    public float maxSpeed;

    public float rotationSpeed;

    [SerializeField]
    private Faction.Color color;

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

    public void SetColor(Faction.Color color)
    {
        this.color = color;
        GetComponent<SpriteRenderer>().color = Faction.ToRGB(color);
    }

    public Faction.Color GetColor()
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
        transform.Rotate(Vector3.forward * Mathf.Clamp(rotation, -1, 1) * rotationSpeed);
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
