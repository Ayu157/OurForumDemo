using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
using Log;
namespace BLL
{
    public class Bll
    {
        DAL.Dal dal = new Dal();
        
        public List<AllInfo> GetInvitation()
        {
            return dal.GetInvitation();
        }
    }
}
