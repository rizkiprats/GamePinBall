using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Controller : MonoBehaviour
{
    public Material OnMaterial;
    public Material OffMaterial;

    private bool LightIsOn;
    public Renderer renderer;

    public Collider Bola;

    private enum SwitchLight
    {
        Off,
        On,
        Blink

    }

    private SwitchLight switchLight;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(StartBlinkLoop(5));
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == Bola)
        {
            Toggle();
        }
    }

    private void Set(bool value)
    {
        LightIsOn = value;
        
        if(LightIsOn == true)
        {
            switchLight = SwitchLight.On;
            renderer.material = OnMaterial;
            StopAllCoroutines();

        }
        else
        {
            switchLight = SwitchLight.Off;
            renderer.material = OffMaterial;
            StartCoroutine(StartBlinkLoop(5));
        }
    }

    private IEnumerator StartBlinkLoop(float Time)
    {
        yield return new WaitForSeconds(Time);
        StartCoroutine(BlinkLoop(2));
    }

    private IEnumerator BlinkLoop(int Timer)
    {
        switchLight = SwitchLight.Blink;

        int times = Timer;

        for(int i = 0; i < times; i++)
        {
            renderer.material = OnMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = OffMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        switchLight = SwitchLight.Off;

        StartCoroutine(StartBlinkLoop(5));
    }

    private void Toggle()
    {
        if (switchLight == SwitchLight.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

}
