using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement movement;

    // Animator parametre hash'leri — string yerine int daha hızlı
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    private static readonly int VelocityYHash = Animator.StringToHash("VelocityY");
    private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");

    void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hız değerlerini Animator'a gönder
        anim.SetFloat(SpeedHash, Mathf.Abs(movement.PlayerVelocity.x));
        anim.SetFloat(VelocityYHash, movement.PlayerVelocity.y);
        anim.SetBool(IsGroundedHash, movement.IsGrounded);
    }
}
