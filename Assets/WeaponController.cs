using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MW());
    }

    // Update is called once per frame
    void Update()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y") * -1;
        if (yRot > 0)
        {
            transform.Translate(new Vector3(-0.03f,0,0) * Time.deltaTime);
        }       
        else if (yRot < 0)
        {
            transform.Translate(new Vector3(0.03f,0,0) * Time.deltaTime);
        }
        if (xRot > 0)
        {
            transform.Translate(new Vector3(0,-0.03f,0) * Time.deltaTime);
        }       
        else if (xRot < 0)
        {
            transform.Translate(new Vector3(0,0.03f,0) * Time.deltaTime);
        }

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.8f,transform.position.y,transform.position.z), 2000);
        
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");
        if (yMov > 0 || yMov < 0)
        {
            WeaponStress();
        }
    }
    
    IEnumerator MW()
    {
        while (true)
        {
            up = true;
            yield return new WaitForSeconds(0.8F);
            up = false;
            yield return new WaitForSeconds(0.8F);
        }
    }
    public void WeaponStress()
    {
        if(up)
        {
            transform.Translate(new Vector3(0,0.008f,0) * Time.deltaTime);
        }
        else if(!up)
        {
            transform.Translate(new Vector3(0,-0.008f,0) * Time.deltaTime);
        }
    }
}
