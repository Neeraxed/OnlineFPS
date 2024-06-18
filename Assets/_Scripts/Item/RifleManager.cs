using UnityEngine;

public class RifleManager : MonoBehaviour
{
    public GameObject bulletPref;
    public Transform shootPoint;
    //public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    //float T = 0;
    //float reloadTime = 1f;
    [Space]
    [SerializeField] private float shootSpeed;
    [SerializeField] private float gravityForce;
    [SerializeField] private float bulletLifeTime;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        Shoot();
    //    }
    //}
    //void Update()
    //{
    //    T += Time.deltaTime;
    //    if (Input.GetKeyDown(KeyCode.Mouse0) && T >= reloadTime)
    //    {
    //        T = 0;
    //        Shoot();
    //    }
    //    if (Input.GetKey(KeyCode.Mouse1))
    //    {
    //        gunAnim.SetBool("isZoomed", true);
    //        firstPersonController.m_MouseLook.XSensitivity = 0.3f;
    //        firstPersonController.m_MouseLook.YSensitivity = 0.3f;
    //    }
    //    else
    //    {
    //        gunAnim.speed = 1f;
    //        gunAnim.SetBool("isZoomed", false);
    //        firstPersonController.m_MouseLook.XSensitivity = 2f;
    //        firstPersonController.m_MouseLook.YSensitivity = 2f;
    //    }
    //    if (Input.GetKey(KeyCode.LeftControl))
    //    {
    //        Time.timeScale = Mathf.Lerp(Time.timeScale, 0.3f, 0.1f);
    //        if (gunAnim.GetCurrentAnimatorStateInfo(0).IsName("ZoomedIddle") && Input.GetKey(KeyCode.Mouse1))
    //        {
    //            gunAnim.speed = Mathf.Lerp(gunAnim.speed, 0.01f, Time.deltaTime * 8f);
    //        }
    //    }
    //    else
    //    {
    //        Time.timeScale = Mathf.Lerp(Time.timeScale, 1, 1f);
    //        gunAnim.speed = 1f;
    //    }
    //}


    void Shoot()
    {
        //shootAnim.SetTrigger("Shoot");
    }
}