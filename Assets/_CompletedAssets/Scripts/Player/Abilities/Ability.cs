using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{

    public abstract class Ability : MonoBehaviour
    {
        public int ManaCost;

        public float AbilityPower
        {
            get
            {
                return playerMain.abilitypower;
            }

            set
            {
                playerMain.abilitypower = value;
            }
        }

        public int RequiedLevel;
        public string KeyBind;
        public int Cooldown;
        public Text CDText;

        public GameObject AbilityGameObj;

        public RawImage AbilityIcon;

        public Texture ActiveImage;
        public Texture InactiveImage;

        float camRayLength = 100f;
        int floorMask;


        Vector3 hitpoint;

        protected float timer;

        protected PlayerMain playerMain
        {
            get
            {
                return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMain>();
            }
        }

        protected Vector3 CursorPoint
        {
            get
            {
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit floorHit;

                floorMask = LayerMask.GetMask("Floor");

                Physics.Raycast(camRay, out floorHit, camRayLength, floorMask);
                
                return floorHit.point;
            }
        }

        void Awake()
        {
            timer = 0;
        }

        void Update()
        {
            Manage();
        }

        void Manage()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0 && playerMain.CurrentLevel >= RequiedLevel)
            {
                timer = 0;
                if (Input.GetKeyDown(KeyBind))
                {
                    if (playerMain.SpendMana(ManaCost))
                    {
                        Activate();
                        timer = Cooldown;
                    }
                }
            }

            RefreshUI();
        }

        public abstract void Activate();

        void RefreshUI()
        {
            CDText.text = Mathf.RoundToInt(timer).ToString();
            if(timer <= 0)
            {
                CDText.enabled = false;
            }
            else
            {
                CDText.enabled = true;
            }

            if(RequiedLevel > playerMain.CurrentLevel || ManaCost > playerMain.CurrentMana)
            {
                AbilityIcon.texture = InactiveImage;
            }
            else
            {
                AbilityIcon.texture = ActiveImage;
            }
        }

    }
}