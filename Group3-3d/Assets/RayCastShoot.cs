using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastShoot : MonoBehaviour
{

    [Header("Gun Characteristics")]
    public string weaponType;
    public int gunDamage; //1;
    public float fireRate;//.25f;
    public float range; //50f
    public float hitForce;//100f
    public Transform gunEnd;
    public GameObject gunBarrel;
    [Header("Gun Sounds && Effects")]
    public AudioClip GunShot;
    public AudioClip EmptyGun;
    public AudioClip reloadGun;
    public WaitForSeconds reloadTime;
  

    [Header("Ammo items")]
    public int ammoInMagStart;
    public int totalAmmoStart;
    private GameObject AmmoInMagText;
    private GameObject AmmoTotalText;
    private string ammoInMagString = "ammoInMag";
    private string ammoTotalString = "ammoTotal";
    private int AmmoInMagNum;
    private int AmmoTotalNum;
    private int countShots;

    
    private GameObject ReloadingAmie;
    private Animator reloadEffect;

    //private fields
    private WaitForSeconds shotDuration = new WaitForSeconds(.02f);
    private AudioSource gunAudio;
    private LineRenderer bulletLine;
    private float nextFire;
    private string fireButton = "Fire1";
    private string reloadButton = "Fire2";
    private string weaponNameString = "weaponName";
    private GameObject weaponName;
    private bool playerIsAlive;
    private playerHealth playerStatus;

    private void Awake()
    {
        ReloadingAmie = GameObject.FindGameObjectWithTag("animeLocation");
        reloadEffect = ReloadingAmie.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerIsAlive = true;
        reloadTime = new WaitForSeconds(reloadGun.length);

        bulletLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();

        bulletLine.startWidth = 0.05f;
        bulletLine.endWidth = 0.05f;

        weaponName = GameObject.FindGameObjectWithTag(weaponNameString);
        weaponName.GetComponent<Text>().text=weaponType;

        AmmoInMagText = GameObject.FindGameObjectWithTag(ammoInMagString);
        AmmoTotalText = GameObject.FindGameObjectWithTag(ammoTotalString);
        AmmoInMagText.GetComponent<Text>().text = ammoInMagStart.ToString();
        AmmoTotalText.GetComponent<Text>().text = totalAmmoStart.ToString();
        AmmoInMagNum = ammoInMagStart;
        AmmoTotalNum = totalAmmoStart;

        playerStatus = GetComponentInParent<playerHealth>();
        //AmmoInMagNum = int.Parse(AmmoInMagText.text);
        //AmmoTotalNum = int.Parse(AmmoTotalText.text);
    }

    // Update is called once per frame
    void Update()
    {

        weaponName.GetComponent<Text>().text = weaponType;
        AmmoInMagText = GameObject.FindGameObjectWithTag(ammoInMagString);
        AmmoTotalText = GameObject.FindGameObjectWithTag(ammoTotalString);

        AmmoInMagText.GetComponent<Text>().text = AmmoInMagNum.ToString();
        AmmoTotalText.GetComponent<Text>().text = AmmoTotalNum.ToString();
        playerIsAlive = playerStatus.getPlayerIsAlive();
        if (playerIsAlive == false)
            return;

        if (Input.GetAxis(fireButton)>0 && Time.time>nextFire && AmmoInMagNum>0)
        {
            //Debug.Log("Firing");
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = gunBarrel.transform.position;
            RaycastHit hit;

            bulletLine.SetPosition(0,rayOrigin);
            Vector3 fwd = gunBarrel.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(gunBarrel.transform.TransformDirection(Vector3.forward), fwd, Color.red);
            if (Physics.Raycast(gunBarrel.transform.position,fwd,out hit,range))
            {
               bulletLine.SetPosition(1,hit.point);
                Debug.Log("What i hit :" + hit.collider.gameObject.name);

                enemyAI enemyHealth = hit.collider.GetComponent<enemyAI>();
                if (enemyHealth!=null)
                {
                    Debug.Log("i hit an enemy");
                    enemyHealth.subtractHealth(gunDamage);
                    enemyHealth.knockback(10f);
                }

                if (hit.rigidbody !=null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
               }

            }
            else
            {
                bulletLine.SetPosition(1, rayOrigin + gunBarrel.transform.forward * range);
            }


        }
        else if(Input.GetAxis(fireButton) > 0 && Time.time > nextFire && AmmoInMagNum <= 0)
        {
           // Debug.Log("empty");
            nextFire = Time.time + fireRate;
            StartCoroutine(clickingEffect());


        }

        //Dont wanna reload if there is no need
        if (Input.GetAxis(reloadButton)>0 && AmmoInMagNum != ammoInMagStart)
        {
            //Debug.Log("Starting reloading");
            //reload();
            nextFire = Time.time + reloadGun.length;
            
            StartCoroutine(reloadingEffect());

        }




    }


    private IEnumerator ShotEffect()
    {
        gunAudio.clip = GunShot;
        gunAudio.Play();
        bulletLine.enabled = true;
        subtractAmmoInMag();
        countShots++;
        yield return shotDuration;
        bulletLine.enabled = false;

    }



    private IEnumerator clickingEffect()
    {
        Debug.Log("Playing:");
        gunAudio.clip = EmptyGun;
        gunAudio.Play();
        Debug.Log("Playing:"+ gunAudio.clip.name);
        yield return shotDuration;

    }

    private IEnumerator reloadingEffect()
    {
        reloadEffect.SetInteger("condition", 3);
        gunAudio.clip = reloadGun;
        gunAudio.Play();
        reload(); 
        yield return reloadTime;
    }

    void subtractAmmoInMag()
    {
       // Debug.Log("Ammo in Mag before shot:"+AmmoInMagNum);
        //int subRound = int.Parse(AmmoInMagText.GetComponent<Text>().text)-1;
        AmmoInMagNum --;
       // Debug.Log("Ammo in Mag after sub"+AmmoInMagNum);
       // AmmoInMagText.GetComponent<Text>().text = AmmoInMagNum.ToString();
    }

    void reload()
    {
        //check Total ammout in Mag
        if (AmmoTotalNum != 0)
        {
            
            if (AmmoTotalNum >= ammoInMagStart)
            {

                Debug.Log("Reload");
                //int tempAmout = countShots;
                AmmoTotalNum = AmmoTotalNum - countShots;
                AmmoInMagNum += countShots;
                countShots = 0;
            }
            else
            {
                Debug.Log("Reloading remaining amount of ammo");
                int tempAmount = AmmoTotalNum;
                AmmoTotalNum = 0;
                AmmoInMagNum = tempAmount;
                countShots = 0;
            }
        }
        
        
    }

    public void increaseTotalAmmo(int ammoPickedUp)
    {
        Debug.Log("This gun has:"+AmmoTotalNum);
            AmmoTotalNum += ammoPickedUp;
        Debug.Log("After increase:"+AmmoTotalNum);
    }

    public void stopShooting(bool playerIsDead)
    {
        playerIsAlive = playerIsDead;
    }
}




