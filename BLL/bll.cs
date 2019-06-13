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
        public string GetXZInvitation(string IguId)
        {
            return dal.GetXZInvitation(IguId);
        }
        public string GetComment(string guId)
        {
            return dal.GetComment(guId);
        }
    }
}
