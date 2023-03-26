using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    private Camera mainCam;
    private Vector3 offset;
    private Transform target;
    public float smoothTime = 0.3f;
    [SerializeField] private Vector3 jumpForce;
    [SerializeField] private Vector3 spinForce;
    private Vector3 velocity = Vector3.zero;
    public SliceObject sliceObj;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        target = transform;
        offset = mainCam.transform.position - target.position;
    }

    void Update()
    {
        if(GameManager.gameState == GameState.Pause)
        {
            rb.isKinematic = true;
        }

        else if(GameManager.gameState == GameState.Playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                spin();
                jump();
                sliceObj.moveBool = true;
            }
        }
        

    }


    private void FixedUpdate()
    {
        rb.inertiaTensorRotation = Quaternion.identity;
        
    }


    private void LateUpdate()
    {
        mainCam.transform.position =  Vector3.SmoothDamp(mainCam.transform.position, new Vector3(offset.x + target.position.x, mainCam.transform.position.y,
            offset.z + target.position.z), ref velocity, smoothTime);

    }

    internal void spin()
    {

        rb.isKinematic = false;
        rb.angularVelocity = Vector3.zero;
        rb.AddTorque( spinForce, ForceMode.Acceleration);
    }

    internal void jump()
    {
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.AddForce( jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    



    

    
}
