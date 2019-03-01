using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        [HttpGet("1")]
        public string Vjezba(int num1, int num2)
        {
            if (num1 >= num2) return "Wrong relation.";
            return "Right relation.";
        }

        [HttpGet("2")]
        public string Vjezba1(int num1, int num2)
        {
            if (num1 + num1 == num1 * num2) return "Good";
            return "bad";
        }

        [HttpGet("3")]
        public string Vjezba2(int num1, int num2)
        {int
             sum = num1 + num2;
            return $"Sum is {sum}";
        }

        [HttpGet("4")]
        public bool VjezbaBool(string string1, string string2)
        {
            if (string1 != string2) { return false; };
            return true;
        }

        int number = 10;

        [HttpGet("5")]
        public string UslovnaKlauza()
        {
            switch(number)
            {
                case 5: return "Wrong number.";
                case 10: return "Good number 2";
            }

            return "Wrong"; 
            
        }

        [HttpGet("6")]
        public string Switch(string name) 
        {
            switch(name)
            {
                case "sestra": return "je moja sestra";
                case "kuca": return "Bad Request";
                case "Maja": goto case "sestra";
            }

            return "Greska";
        }

        public string Maja { get; set; }
        public string Mia { get; set; }

        [HttpGet("7")]
        public string IfStatment(string name)
        {
           string sister1 = Maja;
           string sister2 = Mia;

            return (name != sister1 || name != sister2) ? $"{name} is my sister" : $"{name} is not my sister";
        }
         
        [HttpGet("8")]
        public StringBuilder NewString()
        {
            StringBuilder sb = new StringBuilder("Hello ", 50);
            sb.Append("World");
            sb.AppendLine("!");
            sb.Append("NewLine");
            //sb.AppendFormat("{0:C}, 25");
            //sb.Insert(6, "ooo");
            //sb.Remove(1, 1);
            //sb.Replace("ell", "HohO");

            return sb;

        }

        [HttpGet("9")]
        public IActionResult Array()
        {
            string[] array = new string[5]{"Maja", "Megi", "Mia", "Mina", "Milja"};
            return Ok(array);
        }

        [HttpGet("10")]
        public int ArrayInt()
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;

            return array[2];
        
        }
         

        


    }
}