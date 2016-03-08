namespace Service.Utilities.PhotoAlbum
{
    //PrimitiveTypeWrapper to keep references alive
    public class PrimitiveTypeWrapper<T> where T : struct
    {
        public static implicit operator T(PrimitiveTypeWrapper<T> w)
        {
            return w.Value;
        }

        public PrimitiveTypeWrapper()
        {
            _t = default(T);
        } 

        public PrimitiveTypeWrapper(T t)
        {
            _t = t;
        }

        public T Value
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }
        public override string ToString()
        {
            return _t.ToString();
        }
        private T _t;
    }
}