using UnityEngine;

public class DemoFree : MonoBehaviour
{

    private readonly string[] m_animations = { "Pickup", "Wave" };
    private Animator[] m_animators = null;
    [SerializeField] private FreeCameraLogic m_cameraLogic = null;

    private void Start()
    {
        m_animators = FindObjectsOfType<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_cameraLogic.PreviousTarget();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_cameraLogic.NextTarget();
        }
    }


}
