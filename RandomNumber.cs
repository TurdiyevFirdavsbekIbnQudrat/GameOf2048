using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOf2048
{
    public class RandomSon
    {
        public int randomSonIkkiniDarajasida() 
        {
            Random nums = new Random();
            return Convert.ToInt32(Math.Pow(2, nums.Next(2,5)));
        }
    }
}
