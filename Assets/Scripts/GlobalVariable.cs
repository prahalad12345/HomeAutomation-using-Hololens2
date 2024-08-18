using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    // This is a static variable that can be accessed globally
    public static string message;

    void Start()
    {
        // Initialize the variable
        message="";
    }
}
