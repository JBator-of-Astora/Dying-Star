using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DamageTypes;
using static HealthbarAligner;

public class Player : Damageable
{

    public Animator animator;

    [SerializeField] protected float m1CooldownTime;
    [SerializeField] protected float m2CooldownTime;
    [SerializeField] protected float shiftCooldownTime;
    [SerializeField] protected float eCooldownTime;
    [SerializeField] protected float rCooldownTime;

    protected float m1Cooldown;
    protected float m2Cooldown;
    protected float shiftCooldown;
    protected float eCooldown;
    protected float rCooldown;

    public Transform skillPanel;

    Image m1CooldownGraphic;
    Image m2CooldownGraphic;
    Image shiftCooldownGraphic;
    Image eCooldownGraphic;
    Image rCooldownGraphic;

    private int experience;
    private bool inputLock = false;

    public void Start()
    {   
        
        baseHealth = 100;
        baseArmor = 10;
        experience = 0;

        healthbarNumbers = true;
        base.Start();

        
        healthbar.configuration(true, baseHealth);

        m1CooldownGraphic = skillPanel.Find("M1").GetChild(0).gameObject.GetComponent<Image>();
        m2CooldownGraphic = skillPanel.Find("M2").GetChild(0).gameObject.GetComponent<Image>();
        shiftCooldownGraphic = skillPanel.Find("Shift").GetChild(0).gameObject.GetComponent<Image>();
        eCooldownGraphic = skillPanel.Find("E").GetChild(0).gameObject.GetComponent<Image>();
        rCooldownGraphic = skillPanel.Find("R").GetChild(0).gameObject.GetComponent<Image>();
        

        UIHotkeys.lockPlayerControl += input_lock;
    }

    private void input_lock(bool locked) {

        inputLock = locked;
    }

    public void Update() {
        
        if (!inputLock) {

            if (Input.GetKeyDown(KeyCode.Mouse0)) {

                MouseOne();
                
            } else if (Input.GetKeyDown(KeyCode.Mouse1)) {

                MouseTwo();
            } else if(Input.GetKeyDown(KeyCode.LeftShift)) {

                Shift();
            } else if (Input.GetKeyDown(KeyCode.E)) {

                E();
            } else if (Input.GetKeyDown(KeyCode.R)) {

                R();
            }
        }

        UpdateCooldowns();
    }

    private void UpdateCooldowns() {
        
        m1Cooldown = ClampCooldownUpdate(m1Cooldown);
        m2Cooldown = ClampCooldownUpdate(m2Cooldown);
        shiftCooldown = ClampCooldownUpdate(shiftCooldown);
        eCooldown = ClampCooldownUpdate(eCooldown);
        rCooldown = ClampCooldownUpdate(rCooldown);

        m1CooldownGraphic.fillAmount = m1Cooldown / m1CooldownTime;
        m2CooldownGraphic.fillAmount = m2Cooldown / m2CooldownTime;
        shiftCooldownGraphic.fillAmount = shiftCooldown / shiftCooldownTime;
        eCooldownGraphic.fillAmount = eCooldown / eCooldownTime;
        rCooldownGraphic.fillAmount = rCooldown / rCooldownTime;
        
    }

    private float ClampCooldownUpdate(float time) {

        time -= Time.deltaTime;
        
        if (time < 0) {
            time = 0;
        }

        return time;
    }

    protected virtual void MouseOne() {

        animator.SetBool("M1", true);
        Debug.Log("M1");
        m1Cooldown = m1CooldownTime;
    }

    protected virtual void MouseTwo() {
        Debug.Log("M2");
        m2Cooldown = m2CooldownTime;
    }

    protected virtual void Shift() {
        Debug.Log("Shift");
        shiftCooldown = shiftCooldownTime;
    }

    protected virtual void E() {
        Debug.Log("E");
        eCooldown = eCooldownTime;
    }

    protected virtual void R() {
        Debug.Log("R");
        rCooldown = rCooldownTime;
    }
}
