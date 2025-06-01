using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Attachment;

[RequireComponent(typeof(AudioSource))]
public class VRGunController : XRGrabInteractable
{
    [Header("Weapon Settings")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 35f;
    public float fireRate = 0.2f;
    public int maxAmmo = 30;
    public int clipSize = 10;
    public float reloadTime = 2f;

    [Header("VR Effects")]
    public float recoilAmount = 0.1f;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip emptySound;
    //public ParticleSystem muzzleFlash;

    [Header("Ammo UI")]
    public TextMeshProUGUI ammoDisplay;

    private InputDevice _currentController;
    private AudioSource _audioSource;
    private int _currentAmmo;
    private int _ammoInClip;
    private bool _isReloading;
    private float _nextFireTime;
    private bool _wasTriggerPressed;
    private Vector3 _originalLocalPosition;
    private Quaternion _originalLocalRotation;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        InitializeWeapon();

        // Сохраняем оригинальную локальную трансформацию
        _originalLocalPosition = transform.localPosition;
        _originalLocalRotation = transform.localRotation;
    }

    private void InitializeWeapon()
    {
        _currentAmmo = maxAmmo;
        _ammoInClip = clipSize;
        UpdateAmmoDisplay();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        SetupController(args.interactorObject);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ResetController();
    }

    private void SetupController(IXRSelectInteractor interactor)
    {
        Debug.Log(interactor.transform.name + " ЖОЛПААААААААААА" );
        // Получаем XRController из interactor
        var xrController = interactor.transform.GetComponent<InteractionAttachController>();
        if (xrController != null)
        {
            // Определяем тип контроллера по тегу
            if (interactor.transform.CompareTag("Left Hand"))
            {
                _currentController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            }
            else if (interactor.transform.CompareTag("Right Hand"))
            {
                _currentController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            }
        }

        // Присоединяем оружие к контроллеру
        //transform.SetParent(interactor.transform);
        //transform.localPosition = Vector3.zero;
        //transform.localRotation = Quaternion.identity;
    }

    private void ResetController()
    {
        _currentController = default;

        // Возвращаем оружие в исходное положение
        //transform.SetParent(null);
        //transform.localPosition = _originalLocalPosition;
        //transform.localRotation = _originalLocalRotation;
    }

    private void Update()
    {
        if (!_currentController.isValid || _isReloading)
            return;

        HandleShootingInput();
        //HandleReloadInput();
    }

    private void HandleShootingInput()
    {
        if (_currentController.TryGetFeatureValue(CommonUsages.triggerButton, out bool isGripPressed))
        {
            if (isGripPressed && !_wasTriggerPressed && Time.time >= _nextFireTime)
            {
                if (_ammoInClip > 0)
                {
                    Shoot();
                }
                else if (_currentAmmo > 0)
                {
                    StartReload();
                }
                else
                {
                    PlayEmptySound();
                }
            }
            _wasTriggerPressed = isGripPressed;
        }
    }

    private void HandleReloadInput()
    {
        if (_currentController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isReloadPressed) && isReloadPressed)
        {
            if (!_isReloading && _ammoInClip < clipSize && _currentAmmo > 0)
            {
                StartReload();
            }
        }
    }

    [System.Obsolete]
    private void Shoot()
    {
        InstantiateBullet();
        PlayShootEffects();
        ApplyRecoil();
        UpdateAmmoAfterShot();
    }

    [System.Obsolete]
    private void InstantiateBullet()
    {
            // Дополнительный поворот на 90 градусов вокруг оси Y (если нужно)
            Quaternion correction = Quaternion.Euler(0, -90, 0);
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * correction);
            bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
    }

    private void PlayShootEffects()
    {
        //muzzleFlash?.Play();
        _audioSource.PlayOneShot(shootSound);
        SendHapticImpulse(0.5f, 0.1f);
    }

    private void UpdateAmmoAfterShot()
    {
        _ammoInClip--;
        UpdateAmmoDisplay();
        _nextFireTime = Time.time + fireRate;
    }

    private void StartReload()
    {
        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        _isReloading = true;
        PlayReloadEffects();

        yield return new WaitForSeconds(reloadTime);

        PerformReload();
        _isReloading = false;
    }

    private void PlayReloadEffects()
    {
        _audioSource.PlayOneShot(reloadSound);
        SendHapticImpulse(0.3f, 0.3f);
    }

    private void PerformReload()
    {
        int bulletsNeeded = clipSize - _ammoInClip;
        int bulletsToLoad = Mathf.Min(bulletsNeeded, _currentAmmo);

        _ammoInClip += bulletsToLoad;
        _currentAmmo -= bulletsToLoad;

        UpdateAmmoDisplay();
        SendHapticImpulse(0.2f, 0.2f);
    }

    private void ApplyRecoil()
    {
        transform.localPosition -= transform.forward * recoilAmount;
        CancelInvoke(nameof(ResetRecoil));
        Invoke(nameof(ResetRecoil), 0.1f);
    }

    private void ResetRecoil()
    {
        transform.localPosition += transform.forward * recoilAmount;
    }

    private void PlayEmptySound()
    {
        _audioSource.PlayOneShot(emptySound);
        SendHapticImpulse(0.3f, 0.2f);
    }

    private void SendHapticImpulse(float amplitude, float duration)
    {
        if (_currentController.isValid)
        {
            _currentController.SendHapticImpulse(0, amplitude, duration);
        }
    }

    public void AddAmmo(int amount)
    {
        _currentAmmo = Mathf.Min(_currentAmmo + amount, maxAmmo);
        UpdateAmmoDisplay();
    }

    private void UpdateAmmoDisplay()
    {
        ammoDisplay.text = ($"{_ammoInClip}/{_currentAmmo}");
    }
}