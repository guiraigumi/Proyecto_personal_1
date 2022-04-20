using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    Player _player;

    void Awake()
    {
        _player = GameObject.Find("rock").GetComponent<Player>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        _player.isGrounded = true;
        _player._animator.SetBool("Jump", false);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _player.isGrounded = false;
    }
}
