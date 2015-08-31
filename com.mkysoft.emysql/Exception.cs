using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mkysoft.emysql
{
    public sealed class DBException : System.Data.Common.DbException
    {
        internal DBException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        internal DBException(string msg, int errNo, Exception inner)
            : this(msg, inner)
        {
            _ErrNo = errNo;
            Data.Add("ErrNo", errNo);
        }

        internal DBException(string msg, int errNo)
            : this(msg, errNo, null)
        {
        }

        private int _ErrNo;

        public int ErrNo
        {
            get { return _ErrNo; }
        }

        public override string Message
        {
            get
            {
                return base.Message + " ErrNo: " + base.Data["ErrNo"];
            }
        }
    }
}
