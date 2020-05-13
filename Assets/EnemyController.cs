using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int ammo;
    public float healthpoint;

    public GameObject[] body;
    [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    IEnumerator ReloadAmmo()
    {
        while (true)
        {
            ammo++;
            yield return new WaitForSeconds(2);
        }
    }
    void Start()
    {
        healthpoint = 5;
        for (int i = 0; i < body.Length; i++)
        {
          //  body[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        ammo = 5;
        StartCoroutine(ReloadAmmo());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        if (healthpoint > 0)
        {
            healthpoint -= damage;
        }
        else
        {
            for (int i = 0; i < body.Length; i++)
            {
                body[i].GetComponent<Rigidbody>().isKinematic = false;
                body[i].GetComponent<Rigidbody>().useGravity = true;
            }
            Debug.Log("Dead!");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var targetRotation = Quaternion.LookRotation(other.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
            
            
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, transform.forward,out _hit, 100, mask) && ammo > 0)
            {
                Debug.Log("Object: " + _hit.collider.name);
               // _hit.collider.gameObject.GetComponent<EnemyController>().TakeDamage(1);
               ammo--;
               Debug.Log(ammo);
               other.gameObject.GetComponent<PlayerController>().hp -= 0.5F;
            }
        }
    }
}
