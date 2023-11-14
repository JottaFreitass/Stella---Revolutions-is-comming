using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class Andar_Stella : MonoBehaviour
{
    public float entradaHorizontal ;

    public float movimentoHorizontal;
    public float velocidade = 5.0f;
    public Animator animator;
    private Rigidbody2D playerRigidbody2D;
    public int vida = 100;
    public bool podeAndar;
    public string cenaAlvo = "Dialogo_Corredor";
    public string cenaAlvo2 = "Menu inicial";

    [SerializeField]  private Transform pontoAtaque;

    [SerializeField] float raioAtaque;

    
    
    void Start()
    {
        Debug.Log("Start de " + this.name);
        animator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimentoHorizontal = Input.GetAxis("Horizontal");
        podeAndar = true;
        if (podeAndar == true)
       {
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * movimentoHorizontal);
        Movimento();
       }
        Morte();
    }

    private void Movimento()
    {
        Vector2 moveDirection = new Vector2(movimentoHorizontal,0).normalized;
        Vector2 newPosition = playerRigidbody2D.position + moveDirection * velocidade * Time.deltaTime;

        playerRigidbody2D.MovePosition(newPosition);
        
        if (movimentoHorizontal < 0)
        {
            animator.SetBool("Esquerda", true);
        }
        else
        {
            animator.SetBool("Esquerda", false);
        }

       if (movimentoHorizontal > 0)
        {
            animator.SetBool("Direita", true);
        }
        else
        {
            animator.SetBool("Direita", false);
        }

/*        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Pulo", true);
            transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
        else
        {
            animator.SetBool("Pulo", false);
        }
    } */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);


        if (other.tag == "Inimigo")
        {
            vida = vida - 20;
            animator.SetBool("Ataque", true);
            StartCoroutine(ResetAtaqueAfterDelay(0.1f));
        } 

        if (other.tag == "Parede")
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }

        if (other.CompareTag("caixa"))
        {
        Debug.Log("Troca de cena!");
        SceneManager.LoadScene(cenaAlvo);
        }

        if (other.CompareTag("men"))
        {
        Debug.Log("Troca de cena!");
        SceneManager.LoadScene(cenaAlvo2);
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
            SceneManager.LoadScene("MORTE");
        }
    }


    /* private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
    } */
}