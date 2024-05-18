using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MicroserviceUdemy.Controller {

 
    public class CalculatorController : BaseApiController {

        private readonly ILogger<CalculatorController> _logger;
        private string? firstNumber;

        public CalculatorController(ILogger<CalculatorController> logger) {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber) { 
        
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber)) {

                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber) {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {

                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Operation");
        }


        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult(string firstNumber, string secondNumber) {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {

                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Operation");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Getdiv(string firstNumber, string secondNumber) {
          

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) ) {

                var second = ConvertToDecimal(secondNumber);

                if (second < 1) {
                    return BadRequest("Any Number can not be divided by 0");
                }

                var div = ConvertToDecimal(firstNumber) / second;

                return Ok(div.ToString());
            }

            return BadRequest("Invalid Operation");
        }

        [HttpGet("med")]
        public IActionResult GetMed([FromQuery]string itens) {

            var itemList =  itens.Split(',');

            decimal sum = 0; 

            foreach(var item in itemList) {

                if (!IsNumeric(itens)){

                    return BadRequest($" Invalid Operation: one of the itens dat was sent was not a number item:{item}");
                }

                 sum = sum + ConvertToDecimal(item);

            }

            var med = sum / itemList.Count();

            return Ok(med.ToString());

        }


        [HttpGet("raiz/{firstNumber}")]
        public IActionResult GetRaiz(string firstNumber) {


            if (IsNumeric(firstNumber)) {

                var second = ConvertToDecimal(firstNumber);

                var raiz = Math.Sqrt(ConvertToDuble(firstNumber));
               

                return Ok(raiz.ToString());
            }

            return BadRequest("Invalid Operation");
        }

        private double ConvertToDuble(string strNumber) {
            
            double doublelValue;

            if (double.TryParse(strNumber, out doublelValue)) {

                return doublelValue;

            }
            return 0;
        }

        private bool IsNumeric(string strNumber) {

            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber) {

            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue)) {

                return decimalValue;

            }
            return 0;
        }

       
    }
}
