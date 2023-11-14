using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    [SerializeField]  private Transform pontoAtaque;

    [SerializeField] float raioAtaque;

    void Start()
    {
        
    }



    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
    }

}
