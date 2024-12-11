using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance; // 单例模式，确保全局唯一

    [Header("Audio Clips")]
    public AudioClip backgroundMusic; // 背景音乐
    public AudioClip clickSound; // 点击音效

    private AudioSource musicSource; // 背景音乐的 AudioSource
    private AudioSource effectSource; // 音效的 AudioSource

    private float soundCooldown = 0.1f;
    private float lastPlayTime = 0;

    void Awake()
    {
        // 单例模式初始化
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保持跨场景存在
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // 初始化 AudioSource 组件
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true; // 背景音乐循环播放
        musicSource.playOnAwake = false;

        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.playOnAwake = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // 自动播放背景音乐
        PlayBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        // 检测任意键按下
        if (Input.anyKeyDown)
        {
            PlayClickSound();
        }

        if (Input.anyKeyDown && Time.time > lastPlayTime + soundCooldown)
        {
            PlayClickSound();
            lastPlayTime = Time.time;
        }

    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music not assigned!");
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            effectSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("Click sound not assigned!");
        }
    }

}
