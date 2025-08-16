using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public Ray CastRayFromClick() 
    { 
        return Camera.main.ScreenPointToRay(Input.mousePosition); 
    }
    
}
