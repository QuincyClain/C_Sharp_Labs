using System;

namespace l7
{
    class RationalNumber : IEquatable<RationalNumber>
    {
        int _n;
        int _m;
        static string str;

        public RationalNumber(int n, int m)
        {
            _n = n;
            _m = m;
            if (_m == 0)
                throw new Exception("Denominator can't equals zero!");
        }
        void Sokr()
        {
            int i = 2;
            uint j = 2;
            for (; i <= Math.Abs(_n) && j <= _m;)
                if (Math.Abs(_n) % i == 0 && _m % i == 0)
                {
                    _n /= i;
                    _m /= (int)j;
                }
                else
                {
                    i++;
                    j++;
                }
        }
        public int N
        {
            get { return _n; }
            set { _n = value; }
        }

        public int M
        {
            get { return _m; }
            set
            {
                if (value == 0)
                    throw new Exception("Denominator can't equals zero!");

                _m = value;
            }
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            if (a._m == b._m)
            {
                RationalNumber r = new RationalNumber(a._n + b._n, a._m);
                r.Sokr();
                return r;
            }
            else
            {
                RationalNumber e = new RationalNumber(a._n * b._m + b._n * a._m, a._m * b._m);
                e.Sokr();
                return e;
            }
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            if (a._m == b._m)
            {
                RationalNumber o = new RationalNumber(a._n - b._n, a._m);
                o.Sokr();
                return o;
            }
            else
            {
                RationalNumber u = new RationalNumber(a._n * b._m - b._n * a._m, a._m * b._m);
                u.Sokr();
                return u;
            }
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            RationalNumber mul = new RationalNumber(a._n * b._n, a._m * b._m);
            mul.Sokr();
            return mul;
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            RationalNumber div = new RationalNumber(a._n * b._m, a._m * b._n);
            div.Sokr();
            return div;
        }
        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return (double)a._n / a._m > (double)b._n / b._m;
        }
        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return (double)a._n / a._m < (double)b._n / b._m;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", _n, _m);
        }

        public string StrFormat()
        {
            return string.Format("Numerator: {0}, Denominator: {1}", _n, _m);
        }

        public RationalNumber StrToObj(string str)
        {
            string strn = "";
            string strm = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '/')
                {
                    for (i++; i < str.Length; i++)
                    {
                        strm += str[i];
                    }
                }
                else strn += str[i];
            }
            RationalNumber ratnum1 = new RationalNumber(Convert.ToInt32(strn), Convert.ToInt32(strm));
            return ratnum1;
        }

        public bool Equals(RationalNumber other)
        {
            if (other == null)
                return false;
            if (((double)this._n) / ((double)this._m) == (((double)other._n) / ((double)other._m)))
                return true;
            else
                return false;
        }
        public bool Compare(RationalNumber other)
        {
            if (other == null)
                return false;
            if (this._n == other._n && this._m == other._m)
                return true;
            else
                return false;
        }

        public static implicit operator RationalNumber(double x)
        {
            string strint = "";
            string strfract = "";
            double counter = 0;
            int n;
            int m;

            str = x.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.' || str[i] == ',')
                {
                    for (i++; i < str.Length; i++)
                    {
                        strfract += str[i];
                        counter++;
                    }
                }
                else strint += str[i];
            }
            if (strfract.Length == 0)
                strfract = "0";
            m = (int)Math.Pow(10, counter);
            n = (Convert.ToInt32(strint) * m + Convert.ToInt32(strfract));
            return new RationalNumber(n, m);
        }

        public static implicit operator RationalNumber(int x)
        {
            return new RationalNumber(x, 1);
        }

        public static implicit operator double(RationalNumber ratnum)
        {
            return (((double)ratnum._n) / ((double)ratnum._m));
        }

        public static implicit operator int(RationalNumber ratnum)
        {
            return (ratnum._n / ratnum._m);
        }

        public static implicit operator string(RationalNumber ratnum)
        {
            return ratnum.ToString();
        }
    }
}
