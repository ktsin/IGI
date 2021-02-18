using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace lab1_inform
{
    public static class StateSingleton
    {
        public enum Mode
        {
            View,
            Edit,
            Connection
        }

        public static Mode State { get; set; }

        public static string ConnectionString { get; set; } = "nil";

        public static DataContext Context { get; set; }
    }
}
