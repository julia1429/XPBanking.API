using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPBanking.Test
{
    public class IdValidator
    {
        public bool IsValidId(int id)
        {
            // Verifica se o ID é positivo e não é zero
            return id > 0;
        }
    }
}
