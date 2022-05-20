using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
	float rotationSpeed = 0.2f;
	float rotationAmount = 0f;
	public float autoRotationSpeed = 0;

	public bool isDragging = false;
 

    void Update(){
        if(Input.GetMouseButtonDown(0)){
			isDragging = true;
        }

		if(Input.GetMouseButtonUp(0)){
			isDragging = false;
		}

		if(isDragging){
			rotationAmount = Input.GetAxis("Mouse X")*rotationSpeed;
			if(rotationAmount < 0f)
				autoRotationSpeed = -0;
			else if(rotationAmount > 0f){
				autoRotationSpeed = 0;
			}
			//float YaxisRotation = Input.GetAxis("Mouse Y")*rotationSpeed;
			// select the axis by which you want to rotate the GameObject
			//this.transform.RotateAround (Vector3.right, YaxisRotation);
		}

		if(rotationAmount != 0f){
			rotationAmount = Mathf.Lerp(rotationAmount, 0f, 0.1f);
			this.transform.RotateAround (Vector3.down, rotationAmount);
		}

		this.transform.RotateAround (Vector3.down, autoRotationSpeed);
    }

	public void ResetValue(){
		isDragging = false;
		rotationAmount = 0f;
		autoRotationSpeed = 0.003f;
	}
}
