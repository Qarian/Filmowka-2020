using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private new Transform camera;
    
    [Space]
    [SerializeField] private float distance = 10f;
    [SerializeField] private float duration = 0.7f;
    [SerializeField] private float jumpPower = 10f;
    private bool isGrounded;

    private Vector2 moveCamera;
    private Rigidbody rb;
    private new Transform transform;

    private void Awake()
    {
        transform = ((Component) this).transform;
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity += Vector3.up * jumpPower;
            isGrounded = false;
        }
        
        if (Input.GetKeyDown(KeyCode.W))
            TryMove(transform.forward);
        else if (Input.GetKeyDown(KeyCode.A))
            TryMove(-transform.right);
        else if (Input.GetKeyDown(KeyCode.S))
            TryMove(-transform.forward);
        else if (Input.GetKeyDown(KeyCode.D))
            TryMove(transform.right);
            
        
        moveCamera += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y") );
        moveCamera.y = Mathf.Clamp(moveCamera.y, -60f, 60f);
        
        
        camera.localEulerAngles = new Vector3(-moveCamera.y,moveCamera.x,0);
    }

    void TryMove(Vector3 direction)
    {
        if (!Beat.TryBeat())
            return;
        
        Vector3 target = transform.position + direction * distance;
        transform.DOMoveX(target.x, duration);
        transform.DOMoveZ(target.z, duration);
    }

    void Explosion()
    {
        transform.GetComponent<PlayerController>().enabled = false;
        var sequnenceLost = DOTween.Sequence();
        sequnenceLost.AppendInterval(1f);
        sequnenceLost.OnComplete(() =>
        { 
            transform.GetComponent<PlayerController>().enabled = true;
        });
    }

    public void ShootShake()
    {
        camera.DOShakePosition(0.1f, 0.6f , 0, 0);
    }
    
    void ScreenShake(float distance)
    {
        float maxRadius = 30f;
        var str = maxRadius / distance;
        str = Mathf.Clamp(str, 0.5f, 2);

        camera.DOShakePosition(0.2f, 1f * str, 30, 10);
    }
}