using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour {

    [SerializeField]
    private GameObject _destroyPrefab;



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Basketball")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                Vector3 vel = rb.velocity;
                GameObject destroyInstance = Instantiate(_destroyPrefab, rb.transform);
                Rigidbody destroyRb = destroyInstance.AddComponent<Rigidbody>();
                destroyRb.velocity = vel;
                destroyRb.transform.position = other.gameObject.transform.position;

                Vector3 scale = destroyRb.transform.localScale;
                destroyRb.transform.localScale *= 0.02f;

                

                StartCoroutine(Explode(other.gameObject, destroyInstance));
            }
            /*
            GameObject spawn = GameObject.Find("SpawnPoint");
            if (spawn != null)
            {
                other.gameObject.transform.position = spawn.transform.position;
            }
            */
            //other.gameObject.transform.position = new Vector3(0, 1);
        }
    }


    IEnumerator Explode(GameObject ball, GameObject explosion)
    {
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        ps.Play();
        yield return new WaitForSeconds(0.5f);
        GameObject spawn = GameObject.Find("SpawnPoint");
        if (spawn != null)
        {
            ball.transform.position = spawn.transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        yield return new WaitForSeconds(1f);
        ps.Stop();
    }
}
