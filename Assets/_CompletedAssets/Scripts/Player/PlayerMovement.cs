using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour, Stunnable, Slowable
    {
        public float stoppingDistance;
        public GameObject crosshair;
        GameObject prevenemy;
        bool isMoving;
        Vector3 hitpoint;
        public GameObject Target;
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
        UnityEngine.AI.NavMeshAgent nav;
        PlayerShooting shooting;
        public float prevX;
        public float prevZ;
        int shootableMask;
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
        GameObject hitEnemy;

        void Awake ()
        {
            //nav.enabled = false;
            floorMask = LayerMask.GetMask("Floor");
            shooting = GetComponentInChildren<PlayerShooting>();
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody> ();
            nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            prevX = transform.position.x;
            prevZ = transform.position.z;
            shootableMask = LayerMask.GetMask("Shootable");
        }

        public void Slow(float percent, float duration)
        {

        }

        public void Stun(float Duration)
        {

        }

        public Vector3 GetMovement()
        {
            return new Vector3(0f, 0f, 0f);
        }

        void Update ()
        {

            float h = transform.position.x - prevX;
            float v = transform.position.z - prevZ;

            isMoving = (h != 0f || v != 0f);

           
            if (Input.GetButton("Fire2"))
            {
                Move();
            }

            if(Vector3.Distance(transform.position,hitpoint) <= stoppingDistance)
            {
                nav.enabled = false;
            }

            Turning();

            Highlight();

            Animating ();

            if (Target != null)
            {
                if (Target.GetComponent<EnemyHealth>().currentHealth <= 0)
                {
                    Target = null;
                }
            }

            prevX = transform.position.x;
            prevZ = transform.position.z;
        }

        void Turning()
        {
            if (nav.enabled == false)
            {
                if (Target == null)
                {
                    shooting.target = false;
                }

                else
                {
                    Vector3 PlayerToTarget = Target.transform.position - transform.position;
                    PlayerToTarget.y = 0f;
                    
                    Quaternion NewRotation = Quaternion.LookRotation(PlayerToTarget);
                    playerRigidbody.MoveRotation(NewRotation);
                }

            }
        }


        void Highlight()
        {
            if(Target != null)
            {
                crosshair.transform.position = Target.transform.position + new Vector3(0f,2f,-2f);
                crosshair.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                crosshair.GetComponent<MeshRenderer>().enabled = false;
            }

            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] enemyHit;


            enemyHit = Physics.RaycastAll(camRay, camRayLength);
            int hitLen = enemyHit.Length;

            GameObject[] allenemies = GameObject.FindGameObjectsWithTag("Enemy");

            int len = allenemies.Length;

            if (hitLen != 0)
            {
                for (int i = 0; i < hitLen; i++)
                {
                    if(enemyHit[i].collider.gameObject.tag == "Enemy")
                    {
                        hitEnemy = enemyHit[i].collider.gameObject;
                    }
                }


                for (int i = 0; i < len; i++)
                {
                    if (allenemies[i] == hitEnemy)
                    {
                        allenemies[i].GetComponentInChildren<Highlight>().HighLighted = true;
                    }
                    else
                    {
                        allenemies[i].GetComponentInChildren<Highlight>().HighLighted = false;
                    }
                } 

                if(hitEnemy != null)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Targeting(hitEnemy);
                    }
                }

                hitEnemy = null;
            }
        }

        bool isInvoked = false;

        void ShootTarget()
        {
            isInvoked = false;
            shooting.target = true;
        }

        void Targeting (GameObject target)
        {
            if(target != null)
            {
                if(target.tag == "Enemy")
                {
                    Target = target;

                    if (isInvoked == false)
                    {
                        isInvoked = true;
                        Invoke("ShootTarget", 0.3f);
                    }

                    nav.enabled = false;
                    
                }
                else
                {
                    Target = null;
                    shooting.target = false;
                }
            }
            else
            {
                Target = null;
                shooting.target = false;
            }
        }


        void Move ()
        {

            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer...
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                nav.enabled = true;
                nav.SetDestination(floorHit.point);
                hitpoint = floorHit.point;
                Target = null;
                shooting.target = false;
            }
        }


        void Animating ()
        {
            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", nav.enabled);
        }
    }
}