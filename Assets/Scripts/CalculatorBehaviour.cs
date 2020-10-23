using UnityEngine;
using UnityEngine.UI;
using MathLib;

public class CalculatorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Dropdown MathematicOperationSelector;

    [SerializeField]
    private InputField FirstFactor;
    
    [SerializeField]
    private InputField SecondFactor;

    [SerializeField]
    private Text ResultText;

    public void Compute()
    {
        string _finalResult = string.Empty;
        if (!string.IsNullOrEmpty(FirstFactor.text) && !string.IsNullOrEmpty(SecondFactor.text))
        {
            var _a = float.Parse(FirstFactor.text);
            var _b = float.Parse(SecondFactor.text);

            _finalResult = MathOps(_finalResult, _a, _b);
        }

        else
        {
            _finalResult = "Please fulfill all inputfields in the form";
        }

        ResultText.text = _finalResult;
    }

    private string MathOps(string finalResult, float a, float b)
    {
        switch (MathematicOperationSelector.value)
        {
            case 0:
                finalResult = MathClass.Addition(a, b).ToString();
                break;

            case 1:
                finalResult = MathClass.Subtraction(a, b).ToString();
                break;

            case 2:
                finalResult = MathClass.Multiplication(a, b).ToString();
                break;

            case 3:
                finalResult = VerifyingInfinte(MathClass.Division(a, b));
                break;

            default:
                break;
        }

        return finalResult;
    }

    private string VerifyingInfinte(float operationResult)
    {
        if (float.IsInfinity(operationResult))
        {
            return "Can't divide by zero";
            
        }

        else
        {
            return operationResult.ToString();
        }
    }
    
}
