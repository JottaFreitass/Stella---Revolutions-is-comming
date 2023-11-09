using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo_Teste : MonoBehaviour
{

    public Animator animator;
    public int vida = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Morte();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Ataque", true);
            StartCoroutine(ResetAtaqueAfterDelay(0.1f));
        }
        if (other.tag == "Inimigo")
        {
            animator.SetBool("Ataque", true);
            StartCoroutine(ResetAtaqueAfterDelay(0.1f));
        }
        if (other.tag == "Player")
        {
            vida = vida - 5;
        }
    }

    private IEnumerator ResetAtaqueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("Ataque", false);
    }

    private void Morte()
    {
        if (vida == 0)
        {
            Destroy(this.gameObject);
        }

    }

}

