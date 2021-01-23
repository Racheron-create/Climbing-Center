using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;

namespace Databse_Example
{
    class Database_Example
    {
        static void Main(string[] args)
        {
            string conString = "Provider=SQLOLEDB;Data Source=DESKTOP-MRJEJE6\\SQLEXPRESS;Initial Catalog=ConnectionDb;Integrated Security=SSPI";
            DataRow CurrentRow;

            DataTable _tblCustomer = new DataTable();
            string Customer = "SELECT * FROM Customer";
            OleDbDataAdapter _daTblCustomers = new OleDbDataAdapter(Customer, conString);
            _tblCustomer.Clear();
            _daTblCustomers.Fill(_tblCustomer);
            //OleDbCommandBuilder _cbC = new OleDbCommandBuilder(_daTblCustomers);

            CurrentRow = _tblCustomer.Rows[0];

            Console.WriteLine((string)CurrentRow["CustomerName"]);

        }
    }
}
