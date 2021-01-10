using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskClock : MonoBehaviour
{
    [SerializeField]
    private TaskGiver taskGiver;
    [SerializeField]
    private Image clockFill;
    // Start is called before the first frame update
    void Start()
    {
        taskGiver.OnTaskCooldown += UpdateClock;
    }

    // Update is called once per frame
    private void UpdateClock(float amount)
    {
        clockFill.fillAmount = amount;
    }
    private void OnDestroy() {
        taskGiver.OnTaskCooldown -= UpdateClock;
        
    }
}
