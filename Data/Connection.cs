using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connection : DataConnection
    {
        public Connection() : base("StoreServer") { }
        public ITable<Product> _Product { get { return this.GetTable<Product>(); } }
    }
}
