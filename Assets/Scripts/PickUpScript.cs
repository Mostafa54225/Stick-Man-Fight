using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickUpScript : MonoBehaviour
{
    public Transform grabDetect;
    public Transform gunHolder;
    public float rayDistance;
    ShootScript shootScript;

    RaycastHit2D grabCheck;

    public Button shootButton;
    public Button pickDropButton;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("CanvasAndroid") != null) {
            pickDropButton = GameObject.FindGameObjectWithTag("pickUpButton").GetComponent<Button>();
            shootButton = GameObject.FindGameObjectWithTag("shootButton").GetComponent<Button>();
            pickDropButton.GetComponentInChildren<Text>().text = "PICK";
            shootButton.interactable = false;
        }
        
        shootScript = GetComponent<ShootScript>();
        disableShootScript();
    }

    private void disableShootScript() {
        shootScript.enabled = false;
    }
    void Update()
    {
        // For Android
        if (pickDropButton != null)
        {
            if (pickDropButton.GetComponentInChildren<Text>().text == "PICK")
            {
                pickDropButton.onClick.AddListener(pickUpGun);
            }
                
            else pickDropButton.onClick.AddListener(dropGun);
        }
        

        // for PC
        grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);

        
        if (Input.GetKey(KeyCode.E) && grabDetect != null)
        {
            if(grabCheck.collider != null && (grabCheck.collider.tag == "Vandal" || grabCheck.collider.tag == "Gun" || grabCheck.collider.tag == "Shotgun"))
            {
                shootScript.enabled = true;
                shootScript.Gun = grabCheck.collider.gameObject.transform;
                shootScript.FirePoint = grabCheck.collider.gameObject.transform;
                //grabCheck.collider.gameObject.transform.parent = gunHolder;
                //grabCheck.collider.gameObject.transform.position = gunHolder.position;
                shootScript.Gun.parent = gunHolder;
                shootScript.Gun.position = gunHolder.position;
                //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        if (Input.GetKey(KeyCode.F) && shootScript.Gun != null)
        {
            shootScript.Gun.parent = null;
            shootScript.enabled = false;
            //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }

    }

    

    public void pickUpGun()
    {
        if(grabCheck.collider != null && (grabCheck.collider.tag == "Vandal" || grabCheck.collider.tag == "Gun" || grabCheck.collider.tag == "Shotgun"))
        {
            if(grabDetect != null)
            {
                shootButton.interactable = true;
                shootScript.enabled = true;
                shootScript.Gun = grabCheck.collider.gameObject.transform;
                shootScript.FirePoint = grabCheck.collider.gameObject.transform;
                shootScript.Gun.parent = gunHolder;
                shootScript.Gun.position = gunHolder.position;
                pickDropButton.GetComponentInChildren<Text>().text = "DROP";
            }
            
        }
    }

    public void dropGun()
    {
        if (shootScript.Gun != null)
        {
            shootButton.interactable = false;
            shootScript.Gun.parent = null;
            shootScript.enabled = false;
            pickDropButton.GetComponentInChildren<Text>().text = "PICK";
        }
    }

    

}
