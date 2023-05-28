using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteProjectile : MonoBehaviour
{
    
    public GameObject projectile;


    // Update is called once per frame
    void Update()
    {
        Destroy(projectile, 2f);
    }
}
