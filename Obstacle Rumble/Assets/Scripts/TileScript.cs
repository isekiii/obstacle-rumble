using System.Collections;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public float AnimSpeed = 0.5f;
    public float fallTimer = 2f;
    public Animation anim;
    Rigidbody rb;

    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim["TileWiggle"].speed = AnimSpeed;
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag != "PlayerBody" || other.gameObject.tag != "Enemy") return;
        
        anim.Play();
        StartCoroutine(FallDown());

    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallTimer);
        anim.Stop();
        rb.constraints = RigidbodyConstraints.None;
    }
}
