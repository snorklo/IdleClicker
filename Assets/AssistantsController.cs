namespace IdleClicker
{
    using System.Collections;
    using System.Collections.Generic;

    using UnityEngine;

    using System.Collections;
    using System.Collections.Generic;

    using UnityEngine;

    /// <summary>
    /// Manages data about all assistants.
    /// </summary>
    public class AssistantsController
    {
        private int assistantsAmount = 5;

        private List<AssistantsGroup> assistants = new List<AssistantsGroup>();

        private List<string> ids = new List<string>
        {
            "windowClerk", "expeditionWorker", "postman", "motorVehicleOperator", "shiftSupervisor"
        };

        private bool isInitialized;

        private void Initialize()
        {
            if (isInitialized) return;


        }

    }
}