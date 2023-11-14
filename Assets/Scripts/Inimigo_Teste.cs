using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo_Teste : MonoBehaviour
{

    public Animator animator;
    [SerializeField] public int vidas = 10;




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Ataque", true);
            StartCoroutine(ResetAtaqueAfterDelay(0.1f));
            //vidas = vidas - 5;
        }

        if (vidas <= 0)
        {
         Destroy(this.gameObject);
        }

        if (other.tag == "Inimigo")
        {
            animator.SetBool("Ataque", true);
            StartCoroutine(ResetAtaqueAfterDelay(0.1f));
        }
    }

    private IEnumerator ResetAtaqueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("Ataque", false);
    }
}