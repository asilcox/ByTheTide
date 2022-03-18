using UnityEngine;

public class stormSys : MonoBehaviour
{
    [SerializeField] GameObject[] lightningParticle;
    [SerializeField] int lightningInd;

    [SerializeField] float currentLightningDelay;
    [SerializeField] float maxLightningDelay;
    // Start is called before the first frame update
    void Start()
    {

        setParticle();
    }

    // Update is called once per frame
    void Update()
    {
        var currentParticle = lightningParticle[lightningInd].GetComponent<ParticleSystem>();
        if (currentParticle.isEmitting == false)
        {
            timerStart();
        }
    }

    void setParticle()
    {
        lightningInd = Random.Range(0, lightningParticle.Length);
        lightningParticle[lightningInd].SetActive(true);
    }

    void timerStart()
    {
        currentLightningDelay = currentLightningDelay - 1 * Time.deltaTime;
        if(currentLightningDelay <= 0)
        {
            lightningParticle[lightningInd].SetActive(false);
            setParticle();
            currentLightningDelay = maxLightningDelay;
        }
    }
}
