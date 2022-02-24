
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{

    public float moveForwordSpeed;
    public float moveHorizontalSpeed;

    public FloatingJoystick userInput;


    private CharacterController controller;
    private Rigidbody myRigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = userInput.Horizontal;
        Vector3 movementDirection = new Vector3(horizontalInput * moveHorizontalSpeed, 0, 1f * moveForwordSpeed);
        controller.SimpleMove(movementDirection);
        
        //if (movementDirection != Vector3.zero)
        //{
        //    if (!animator)
        //        return;

        //    animator.SetBool("IsRun", true);
        //}
        //else
        //{
        //    if (!animator)
        //        return;

        //    animator.SetBool("IsRun", false);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            Time.timeScale = 0f;
            UIManager.instance.LevelFailed();
        }
    }
}
