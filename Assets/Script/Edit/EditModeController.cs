using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditModeController : MonoBehaviour
{
    [SerializeField, Tooltip("EditModeController�̃I�u�W�F�N�g")] GameObject EditModeObj;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Edit Mode�N��");
            EditModeObj.SetActive(true);
        }
    }
}
