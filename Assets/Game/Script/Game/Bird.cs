using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Action onAddPoint;
    
    #region Variables
    [SerializeField]
    private MenuManager _menuManager;

    [SerializeField]
    private float _jumpForce;

    private Rigidbody2D _rb;
    #endregion

    #region Main
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 120;
    }
    public void Jump()
    {
        _rb.velocity = Vector3.zero;
        _rb.AddForce(transform.up * (_jumpForce + 1), ForceMode2D.Impulse);
    }
    #endregion

    #region Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountManager.AddToCount(Count.SCORE, 1);

        onAddPoint?.Invoke();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Lose Screen");
            _menuManager.ShowInterface("Lose Screen");
        }

        
    }
    #endregion
}
