using UnityEngine;
using System.Collections;

public class MarkScript : MonoBehaviour
{
  Animator anim;
  private Rigidbody2D rb2d;
  [SerializeField] private float jumpForce = 400f;
  int jumpHash = Animator.StringToHash("Jump");
  int beastHash = Animator.StringToHash("Beast_Jump");
  int extremelyHash = Animator.StringToHash("Extremely_Jump");
    bool jump2 = false, jump3 = false;
    int countJump = 0;
    Renderer carga1, carga2, carga3, carga4;
    public GameObject go1, go2, go3, go4;

  
  void Start()
  {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
    carga1 = go1.GetComponent<Renderer>();
    carga2 = go2.GetComponent<Renderer>();
    carga3 = go3.GetComponent<Renderer>();
    carga4 = go4.GetComponent<Renderer>();

        carga1.enabled = false;
        carga2.enabled = false;
        carga3.enabled = false;
        carga4.enabled = false;
    }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      anim.SetTrigger (jumpHash);
      rb2d.AddForce(new Vector2(0f, jumpForce));
            anim.Play("Jump");
    }
    if (Input.GetKeyDown(KeyCode.Z))
    {
      anim.SetTrigger (beastHash);
      rb2d.AddForce(new Vector2(0f, jumpForce));
            anim.Play("Beast_Jump");
            jump2 = true;
    }
    if (Input.GetKeyDown(KeyCode.X))
    {
      anim.SetTrigger(extremelyHash);
      rb2d.AddForce(new Vector2(0f, jumpForce));
            anim.Play("Extremely_Jump");
            jump3 = true;
    }

        IniciarBarraManobra();
  }

  void FixedUpdate()
  {
    anim.SetFloat("vSpeed", rb2d.velocity.y);
    anim.ResetTrigger(jumpHash);
    anim.ResetTrigger(beastHash);
    anim.ResetTrigger(extremelyHash);
        jump2 = false;
        jump3 = false;
    }

    void IniciarBarraManobra()
    {
        //adiciona mais um sempre que é detectado um "super pulo"
        if(jump2 || jump3)
        {
            countJump++;

        }

        if(countJump == 5)
        {
            carga1.enabled = true;
            Debug.Log("Carga 1 Ativada");
        }

        if(countJump == 10)
        {
            carga2.enabled = true;
            Debug.Log("Carga 2 Ativada");
        }
        if(countJump == 15)
        {
            carga3.enabled = true;
            Debug.Log("Carga 3 Ativada");
        }
        if(countJump == 20)
        {
            carga4.enabled = true;
            Debug.Log("Carga 4 Ativada");
        }

        if(countJump > 20)
        {
            countJump = 0;
        }
    }
    /*public bool CountingJumps()
    {
        bool jump5;
        jump5 = false;
        if(jump2 || jump2)
        {
            this.countJump++;
        }

        if(this.countJump == 5)
        {
            jump5 = true;
            this.countJump = 0;
        }
        Debug.Log(jump5);
        return jump5;

    }*/
}
