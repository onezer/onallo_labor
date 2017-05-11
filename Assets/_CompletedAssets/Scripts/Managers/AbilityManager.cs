using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CompleteProject
{
    public class AbilityManager : MonoBehaviour
    {

        public int RemainingPoints;

        public Button PQ;
        public Button PW;
        public Button PE;
        //public Button PR;

        List<Button> buttons;

        void Start()
        {
            buttons = new List<Button>();
            buttons.Add(PQ);
            buttons.Add(PW);
            buttons.Add(PE);
            //buttons.Add(PR);

        }

        
        void Update()
        {
            if(RemainingPoints > 0)
            {
                foreach(Button b in buttons)
                {
                    b.enabled = true;
                }
            }
            else
            {
                foreach(Button b in buttons)
                {
                    b.enabled = false;
                }
            }
        }
    }
}