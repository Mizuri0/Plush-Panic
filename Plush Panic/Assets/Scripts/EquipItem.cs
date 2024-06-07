using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Baseball_Bat;
    public Camera Camera;
    public float range = 10f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Baseball_Bat.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            UnequipObject();
            Shoot();
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                EquipObject();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();
        Baseball_Bat.transform.eulerAngles = new Vector3(Baseball_Bat.transform.eulerAngles.x, Baseball_Bat.transform.eulerAngles.y, Baseball_Bat.transform.eulerAngles.z - 45);
        Baseball_Bat.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Baseball_Bat.GetComponent<Rigidbody>().isKinematic = true;
        Baseball_Bat.transform.position = PlayerTransform.transform.position;
        Baseball_Bat.transform.rotation = PlayerTransform.transform.rotation;
        Baseball_Bat.transform.SetParent(PlayerTransform);
    }
}