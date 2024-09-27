using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private Animator _anim;
    [SerializeField]
    private RuntimeAnimatorController[] animatorControllers;

    private static readonly int GroundedKey = Animator.StringToHash("Grounded");
    private static readonly int JumpKey = Animator.StringToHash("Jump");

    [SerializeField] private SpriteRenderer _sprite;
    private IPlayerController _player;
    private bool _grounded;
    private void Awake(){
            _player = GetComponentInParent<IPlayerController>();
    }
    private void OnEnable(){
        _player.Jumped += OnJumped;
         _player.GroundedChanged += OnGroundedChanged;
    }
    private void OnDisable()
    {
        _player.Jumped -= OnJumped;
         _player.GroundedChanged -= OnGroundedChanged;
    }
    void Start()
    {
        if (transform.parent.GetComponent<PlayerController>().isGhost)
        {
            //use ghost anim controller
            _anim.runtimeAnimatorController = animatorControllers[1];
        }
        else
        {
            //use player anim controller
            _anim.runtimeAnimatorController = animatorControllers[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
         if (_player == null) return;
    }
    private void OnJumped(){
        _anim.SetTrigger(JumpKey);
         _anim.ResetTrigger(GroundedKey);


        if (_grounded) {}
    }
    private void OnGroundedChanged(bool grounded, float impact){
        _grounded = grounded;
        
        if (grounded)
        {
            _anim.SetTrigger(GroundedKey);
        }

    }

}
