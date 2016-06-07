using UnityEngine;
using System.Collections;

public class SpikeBallSwing : MonoBehaviour {
        
        void Start()
        {
            m_centerPosition = transform.position;
        }
      
        void Update()
        {
            float deltaTime = Time.deltaTime;
           
            // Move center along z axis
           // m_centerPosition.z += deltaTime * m_speed;
           
            // Update degrees
            float degreesPerSecond = 360.0f / m_period;
            m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
            float radians = m_degrees * Mathf.Deg2Rad;
           
            // Offset by sin wave
		Vector3 offset = new Vector3(0.0f, Mathf.Abs(Mathf.Cos(radians)) * -1 , m_amplitude * Mathf.Sin(radians));
            transform.position = m_centerPosition + offset;
        }
       
        Vector3 m_centerPosition;
        float m_degrees;
       
       // [SerializeField]
        //float m_speed = 10.0f;
       
        [SerializeField]
        float m_amplitude = 10.0f;
       
        [SerializeField]
        float m_period = 5.0f;

        /*
        
	void Update () {
		float deltaTime = Time.deltaTime;
		float degreesPerSecond = 360.0f / m_period;
		m_degrees = Mathf.Repeat(m_degrees + (deltaTime * degreesPerSecond), 360.0f);
		float radians = m_degrees * Mathf.Deg2Rad;
		Vector3 offset = new Vector3 (Mathf.Sin (m_amplitude * deltaTime),0.0f, Mathf.Sin (m_speed * deltaTime) );
 
		transform.position = m_centerPosition + offset;


	}
	*/
   
}
     
