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

  void Start()
  {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
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
    }
    if (Input.GetKeyDown(KeyCode.X))
    {
      anim.SetTrigger(extremelyHash);
      rb2d.AddForce(new Vector2(0f, jumpForce));
            anim.Play("Extremely_Jump");
    }
  }

  void FixedUpdate()
  {
    anim.SetFloat("vSpeed", rb2d.velocity.y);
    anim.ResetTrigger(jumpHash);
    anim.ResetTrigger(beastHash);
    anim.ResetTrigger(extremelyHash);
    }
}
