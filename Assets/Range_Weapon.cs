using UnityEngine;

public class Range_weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera fpsCam;
    public float range = 100f;
    public float damage = 10f;
    public float impactForce = 200f;

    public ParticleSystem hitParticles;
    void Update()
    {
        if(Input.GetButtonDown("Fire1!")){
            Shoot();
        }
    }

    void Shoot(){

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){

            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce);
                Instantiate(hitParticles, hit.point,Quaternion.LookRotation(hit.normal));
            }


        }
    }
}