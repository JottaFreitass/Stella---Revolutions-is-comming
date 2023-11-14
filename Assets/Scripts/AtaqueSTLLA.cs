using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueSTLLA : MonoBehaviour
{

    [SerializeField]  
    private Transform pontoAtaque;

    [SerializeField] 
    float raioAtaque;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Atacar();
        }
    }
    
    
    private void OnDrawGizmos()
    {
        if (this.pontoAtaque != null)
        {
        Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
        }
    }

/*    private void Atacar()
    {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(this.pontoAtaque.position, this.raioAtaque);
        if (colliderInimigo != null)
        {
            // causar dano no inimigo
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo_Teste>();
            if (inimigo != null)
            {
                inimigo.Dano();
            }
        }
    } */

}