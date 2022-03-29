using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace bookApp
{
    public class publisherClass
    {
        bookDB.bookDBClass objBookDB = new bookDB.bookDBClass();

        public DataTable getPublisherInfo()
        {
            string strComm;
            strComm = "Select 出版社编号,出版社名称,ISBN,出版社简称,出版社地址 " +
                        "From 出版社";
            return objBookDB.getDataBySQL(strComm);
        }
    }

    public bool publisherInfoAdd(string publisherName,string ISBN,string shortName,string publisherAddress)
    {
        string strInsertComm;
        strInsertComm = "Insert Into 出版社(出版社名称,ISBN,出版社简称,出版社地址)"+
                        "Values('"+ publisherName+"'+'"+ISBN+"','"+shortName+"','"+publisherAddress+"')";
        return objBookDB.updateDataTable(strInsertComm);
    }
}
