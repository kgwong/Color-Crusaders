using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    public static Color RED = new Color(1.0f, 0.128f, 0f);

    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public float minSpeed;
    public float currSpeed;
    public float maxSpeed;

    public float rotationSpeed;

    public int currHealth;
    public int maxHealth;

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        primaryWeapon.SetColor(color);
        secondaryWeapon.SetColor(color);
    }

    public Color GetColor()
    {
        return GetComponent<SpriteRenderer>().color;
    }

    protected void ClampSpeed()
    {
        currSpeed = Mathf.Clamp(currSpeed, minSpeed, maxSpeed);
    }

    protected void Accelerate()
    {
        currSpeed += .1f;
        ClampSpeed();

        //physics based acceleration
        /*if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(transform.up * 10f);
        }*/
    }

    protected void Decelerate()
    {
        currSpeed -= .1f;
        ClampSpeed();

        //physics based slow down
        //rigid.velocity = new Vector2(rigid.velocity.x * 0.98f, rigid.velocity.y * 0.98f);
    }

    protected void TakeDamage(int damage)
    {

    }
}
