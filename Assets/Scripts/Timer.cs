using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    public float time = 16f;
    int seconds;

    bool countDownTrigger = false;

    public GameObject cube;
    Renderer cubeRenderer;
    Rigidbody cubeRigidbody;
    AudioSource cubeAudioSource;

    bool audioTrigger = true;

    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();

        cubeRigidbody = cube.GetComponent<Rigidbody>();

        cubeAudioSource = cube.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countDownTrigger = true;
        }

        if(countDownTrigger)
        {
            time -= Time.deltaTime;
            seconds = (int)time;
            timerText.text = seconds.ToString();

            if (seconds == 12)
            {
                cubeRenderer.enabled = true;
            }

            if (seconds == 9 && audioTrigger == true)
            {
                cubeAudioSource.Play();
                audioTrigger = false;
            }

            if (seconds <= 6)
            {
                cube.transform.position += new Vector3(0, 0, 0.05f);
            }

            if (seconds == 3)
            {
                cubeRigidbody.useGravity = true;
            }

            if (seconds <= 0)
            {
                countDownTrigger = false;
            }
        }
    }
}