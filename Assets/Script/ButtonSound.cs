using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

  void Start()
  {
    // Get the Button component and add a listener to the onClick event
    Button button = GetComponent<Button>();
    button.onClick.AddListener(PlaySound);
  }

  public void PlaySound()
  {
    // Play the sound effect
    audioSource.Play();
  }
}
