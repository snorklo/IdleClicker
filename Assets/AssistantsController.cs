using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Assistant
{
    private string id;
    private double initialPrice;


    public string Id
    {
        get => id;
        internal set => id = value;
    }
   

    private double initialMoneyPerSecond;

    private double moneyPerSecondFromOne;

    private double price;

    private double moneyPerSecond;

    private double amountToBuy;

    private double assistantsOwned;
    
    

 
}

/// <summary>
/// Manages data about all assistans.
/// </summary>
public class AssistantsController
{
    private List<Assistant> assistants = new List<Assistant>();
    Assistant a1 = new Assistant();

    private void Initialize()
    {
        a1.Id
    }
    
}
