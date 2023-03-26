using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;




public class SliceObject : MonoBehaviour
{

    protected GameManager _gameManager;
    protected Rigidbody rbPlayer;
    public PlayerMovement playerMovementScript;
    
    public Material sliceMat;



    float time = 0.5f;
    float timer = 0;
    public bool moveBool;




    private void Start()
    {
        rbPlayer = GetComponentInParent<Rigidbody>();
        playerMovementScript = GetComponentInParent<PlayerMovement>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        moveBool = false;

    }

    private void Update()
    {
        if (moveBool)
        {
            time -= Time.deltaTime;
            if(time <= timer)
            {
                moveBool = false;
                time = 0.5f;
            }
        }


        
    }


    private void FixedUpdate()
    {
        




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanSlice"))
        {
            SlicedHull sliceobj = SliceObj(other.gameObject, sliceMat);

            GameObject SlicedObjTop = sliceobj.CreateUpperHull(other.gameObject, sliceMat);
            SlicedObjTop.transform.parent = other.gameObject.transform.parent;
            SlicedObjTop.AddComponent<Rigidbody>();
            SlicedObjTop.AddComponent<BoxCollider>();
            SlicedObjTop.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20);
            SlicedObjTop.GetComponent<BoxCollider>().isTrigger = false;
            

            GameObject SliceObjDown = sliceobj.CreateLowerHull(other.gameObject, sliceMat);
            SliceObjDown.transform.parent = other.gameObject.transform.parent;
            SliceObjDown.AddComponent<Rigidbody>();
            SliceObjDown.AddComponent<BoxCollider>();
            SliceObjDown.GetComponent<Rigidbody>().AddForce(Vector3.back * 20);
            SliceObjDown.GetComponent<BoxCollider>().isTrigger = false;
            _gameManager.score += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            if (!moveBool)
            {
                
                rbPlayer.isKinematic = true;
                

            }
            
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            GameManager.gameState = GameState.Fail;
        }

        if (other.gameObject.CompareTag("Final"))
        {
            GameManager.gameState = GameState.Win;
            rbPlayer.isKinematic = true;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {

            if (!moveBool)
            {

                rbPlayer.isKinematic = true;
                

            }

        }
    }

    public SlicedHull SliceObj(GameObject obj, Material mat)
    {
        
        return obj.Slice(transform.position, transform.up, mat);
    }





}
