using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DeleteCharacters
    {
        public static string TwoCharacters(string str)
        {
            return string.IsNullOrEmpty(str) ? "" : str.Remove(str.Length - 2, 2);
        }
        public static string FourCharacters(string str)
        {
          return   string.IsNullOrEmpty(str) ? "" : str.Remove(str.Length - 4, 3);
        }
        /// <summary>
        /// xóa kí tự cuối cùng
        /// </summary>
        /// <param name="str">chuỗi cần xóa</param>
        /// <param name="quantity"> số lượng ký tự</param>
        /// <returns>một chuỗi đã xóa ký tự</returns>
        public static string LastCharacters(string str,int quantity)
        {
            if(!string.IsNullOrEmpty(str))
            {
            return str.Remove(str.Length - quantity, quantity);
            }
            return "";
        }
        public static string firstCharacters(string str, int quantity)
        {
            return str.Remove(0, quantity);
        }

    }
}
