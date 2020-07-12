using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject [] bulletPrefab;
    [SerializeField] private Transform bulletSpawnLocation;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ballClick;
    
    private float _gunAngle;
    private float _rotationSpeed = 5f;
    private float _timeBetweenTwoBullets = 200f;
    private float _nextBulletShootTime;

    public bool changeRotation;

    private void Start()
    {
        changeRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeRotation)
        {
            ChangeRotation();
        }
    }

    private void ChangeRotation()
    {
        // Distance between gun and mouse
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

        // Calculates gun's angle with arctan function multiplied by radiant to degree conversion
        _gunAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (_gunAngle >-60 && _gunAngle < 60 )
        {
            Quaternion rotation = Quaternion.AngleAxis(_gunAngle, Vector3.forward);

            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
        
       
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > _nextBulletShootTime)
            {
                _nextBulletShootTime = Time.time + _timeBetweenTwoBullets / 1000;
                ShootBullet();
            }
        }
    }

    // Ana menüde ayarlanan PlayerPref sayesinde oyun sesini açıp kapattım
    // Ancak bunu her ses efekti için kodda tek tek yapmış oldum
    // Daha büyük projelerde sorun çıkaracağı için daha verimli bir yol bulmam gerekiyor
    private void ShootBullet()
    {
        if (PlayerPrefs.GetInt("SoundMute") == 1)
        {
            audioSource.PlayOneShot(ballClick);
        }
        
        GameObject bullet = Instantiate(bulletPrefab[Random.Range(0,bulletPrefab.Length)], bulletSpawnLocation.position, bulletSpawnLocation.rotation) as GameObject;
    }
}