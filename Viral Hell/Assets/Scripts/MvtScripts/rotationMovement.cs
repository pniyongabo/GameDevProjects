using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationMovement : MonoBehaviour
{

    public float rotationSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {
        //rotationSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Macrophage")
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
            if ((gameObject.transform.rotation.z > 0.5f) || (gameObject.transform.rotation.z < -0.5f))
            {
                rotationSpeed *= -1f;
            }
        }
        else if (gameObject.tag == "MacrophageInner")
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * -rotationSpeed);
            if ((gameObject.transform.rotation.z > 0.5f) || (gameObject.transform.rotation.z < -0.5f))
            {
                rotationSpeed *= -1f;
            }
        }
        else if (gameObject.tag == "Dendritic")
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        else if (gameObject.tag == "DendriticFire")
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 15f);
            if ((gameObject.transform.rotation.z > 0.5f) || (gameObject.transform.rotation.z < -0.5f))
            {
                rotationSpeed *= -1f;
            }
        }


        }

    }

