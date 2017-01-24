using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
			if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
				m_Jump = true;
            }
        }


        private void FixedUpdate()
        {
            // Pass all parameters to the character control script.
            m_Character.Move(1, false, m_Jump);
            m_Jump = false;
        }
    }
}
