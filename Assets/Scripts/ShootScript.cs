using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public Transform Gun;

    Vector2 direction;

    public GameObject Bullet;
    public float BulletSpeed;
    public Transform FirePoint;
    private float fireRate;
    float readyForNextShoot;

    public Rigidbody2D rb;
    private float thrust;
    public Joystick joystick;
    private float hor;
    private float ver;

    public Button shootButton;
    
    void Start()
    {
        
            

        if (GameObject.FindGameObjectWithTag("CanvasAndroid") != null)
        {
            joystick = GameObject.FindGameObjectWithTag("fixedJoystick").GetComponent<Joystick>();
            shootButton = GameObject.FindGameObjectWithTag("shootButton").GetComponent<Button>();
        }
            
    }

    // Update is called once per frame
    void Update()
    {

        if(joystick != null) {
            hor = joystick.Horizontal;
            ver = joystick.Vertical;
        }

        if (shootButton != null)
        {
            if (shootButton.interactable == true)
                shootButton.onClick.AddListener(gunFireRate);
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Gun != null)
        {
            direction = mousePosition - (Vector2)Gun.position;
            FaceMouse();
        }
            
        
        if(Input.GetMouseButton(1))
        {
            gunFireRate();
            
        }

        
        
    }
    public void gunFireRate()
    {
        if (Time.time > readyForNextShoot)
        {
            if (Gun.CompareTag("Vandal")) fireRate = 12;
            else if (Gun.CompareTag("Shotgun")) fireRate = 3;
            else fireRate = 4;

            readyForNextShoot = Time.time + 1 / fireRate;
            shoot();
        }
    }

    void FaceMouse()
    {
        if(hor != 0 || ver !=0)
            Gun.transform.right = new Vector2(hor, ver);
        else 
            Gun.transform.right = direction;
    }
    void shoot()
    {
        if(Gun.CompareTag("Shotgun"))
            rb.AddForce((rb.gameObject.transform.position - Gun.position) * 2500);

        else rb.AddForce((rb.gameObject.transform.position - Gun.position) * 100);
        GameObject BulletIns = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        SoundScript.playSound("gun shot sound");

        Destroy(BulletIns, 3);
    }
}
