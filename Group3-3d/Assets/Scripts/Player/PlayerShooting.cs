using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public float instaKillTime = 5f;
    public Image damageImage;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public AudioClip rpgAudio;

    Animator anim;
    AudioSource gunAudio;
    AudioClip gunClip;
    GameObject gun;
    GameObject rpg;
    GameObject shotgun;
    LineRenderer gunLine;
    Light gunLight;
    ParticleSystem gunParticles;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    
    int modifier = 1;
    int shootableMask;
    int activeWeapon = 1;

    float timer;
    float effectsDisplayTime = 0.2f;
    float instaKillTimer = 100f;

    void Awake ()
    {
        anim = GetComponent<Animator>();
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunClip = gunAudio.clip;
        gunLight = GetComponent<Light> ();
        gun = gameObject.transform.parent.transform.GetChild(0).gameObject;
        rpg = gun.transform.GetChild(0).gameObject;
        shotgun = gun.transform.GetChild(1).gameObject;
    }


    void Update ()
    {
        timer += Time.deltaTime;
        instaKillTimer += Time.deltaTime;

        if (instaKillTimer >= instaKillTime)
        {
            modifier = 1;
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, 5f * Time.deltaTime);
        }
        else
        {
            damageImage.color = flashColour;
        }


        if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }

        if (activeWeapon == 1)
        {
            gun.GetComponent<SkinnedMeshRenderer>().enabled = true;
            rpg.SetActive(false);
            shotgun.SetActive(false);
            gunAudio.clip = gunClip;
            damagePerShot = 20;
            timeBetweenBullets = 0.15f;
        }

        else if (activeWeapon == 2)
        {
            gun.GetComponent<SkinnedMeshRenderer>().enabled = false;
            rpg.SetActive(true);
            shotgun.SetActive(false);
            gunAudio.clip = rpgAudio;
            damagePerShot = 200;
            timeBetweenBullets = 1.5f;
        }

        else if (activeWeapon == 3)
        {
            gun.GetComponent<SkinnedMeshRenderer>().enabled = false;
            rpg.SetActive(false);
            shotgun.SetActive(true);
            gunAudio.clip = gunClip;
            damagePerShot = 55;
            timeBetweenBullets = 0.8f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeapon = 2;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeWeapon = 3;
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot*modifier, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

    public void InstaKill()
    {
        instaKillTimer = 0f;
        modifier = 100;
        damageImage.color = flashColour;
    }
}
