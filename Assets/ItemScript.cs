using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    private Animator animator;
   private AudioSource audioSource;

    private void DestroySelf()
    {

        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //DestroySelf();
        //Debug.Log("Enter");
        animator.SetTrigger("Get");
        audioSource.Play();

    }

    private void OnTriggerStay(Collider other)
    {

        Debug.Log("Stay");

    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("Exit");

    }
}
