using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float _bulletSpeed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject != null)
        {
            Destroy(this.gameObject, 3f);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * _bulletSpeed));
    }
}
