using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AracAks                             //Ön ve arka tekerler için aks değişkeni
{
    arac_on,
    arac_arka,
}
[Serializable]                                  //Scripti ekledikten sonra Unity ekranında bu değerleri değiştirebiliyoruz.
public struct Wheel
{

    public GameObject Car_1;                    //model
    public WheelCollider collider;              //Tekerlerin collideri
    public AracAks Aks;
}


public class Car : MonoBehaviour
{
    //public Transform Terrain1, Terrain2;
    //public float Health;
    //float maxHealth = 100;


    public Slider healthSlider;

    public GameObject Camera;
    

    [SerializeField]                            //unity ınspectorde değerleri görüp değiştirebiliyorum
    private float Max_hiz = 20.0f;          //Arabanın ulaşabileceği max hız
    [SerializeField]
    private float Donme_hassasiyeti = 1.0f; //Tekerlerin dönme hassasiyeti-hızı ok tuşları ile
    [SerializeField]
    private float Max_aci = 45.0f;          //Tekerler max kaç derece dönecek
                                            //[SerializeField]
                                            //private Vector3 Kutle_merkezi;          //Arabanın daha az savrulması için kütle merkezini değiştirmeliyiz
    [SerializeField]
    private List<Wheel> wheels = new List<Wheel>();             //Tekerleri tuttuğumuz bir liste değeri var


    public float inputX, inputY;            //x ve y koordinatları için klavye tuşları için X ve Y değeri tanımladık
    private Rigidbody Rigid_b;



    private void Start()
    {
        Rigid_b = GetComponent<Rigidbody>();
        //Rigid_b.centerOfMass = Kutle_merkezi;//Kütleye center ekliyoruz ve merkeze atıyoruz.

    }


    public void Update()
    {

        AnimateWheels();                    //Animasyon başladığında yani girişte tekerleri hareket ettireceğiz
        GetInputs();                        //Giriş değerlerini alacağız
    }
    private void LateUpdate()
    {
        Move();                             //Hareket ettirme olayını kontrol edecek
        Turn();                             //Döndürme olaylarını kontrol edecek
    }
    private void GetInputs()                //Ok tuşları ile kontrol sağlama
    {
        inputX = Input.GetAxis("Horizontal");   //Yatayda kontrol sağlama
        inputY = Input.GetAxis("Vertical");     //Dikeyde kontrol sağlama
    }
    private void Move()                         //Arabanın tekerini döndürüyoruz
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * Max_hiz * 250 * Time.deltaTime;
        }   //motortorque hazır fonksiyondur.
    }
    private void Turn()                     //Tekerlerin dönmesi olayı
    {
        foreach (var wheel in wheels)
        {
            if (wheel.Aks == AracAks.arac_on)//ön tekerler dönsün
            {

                var _steerAngel = inputX * Donme_hassasiyeti * Max_aci;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngel, 0.3f);   //0.05f tekerlerin dönme hızı
            }

        }
    }
    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.Car_1.transform.position = _pos;
            wheel.Car_1.transform.rotation = _rot;
        }
    }
    private void OnTriggerEnter(Collider contact)
        
    {
        if (contact.gameObject.tag == "Coin")
        {
            CoinT.coAmount += 1;
            Destroy(contact.gameObject);

        }

    }
    //public void OnParticleTrigger(Collider obje)
    //{
    //    if(obje.gameObject.tag == "Terrain1")
    //    {
    //        Terrain1.position = new Vector3(Terrain1.position.x, Terrain1.position.y, Terrain1.position.z + 106.0f);
    //    }
    //    if (obje.gameObject.tag == "Terraine2")
    //    {
    //        Terrain2.position = new Vector3(Terrain2.position.x, Terrain2.position.y, Terrain2.position.z + 106.0f);
    //    }
    //}

}
