using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTrigger : MonoBehaviour {

    [SerializeField]
    private ParticleSystem _particle;

    private void Awake()
    {
        _particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basketball")
        {
            GameManager.Instance.AddPoints(1);
            StartCoroutine(PlayScoreRoutine());
        }
    }


    IEnumerator PlayScoreRoutine()
    {
        _particle.Play();
        yield return new WaitForSeconds(0.5f);
        _particle.Stop();
    }
    
}
