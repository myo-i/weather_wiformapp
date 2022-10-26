using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            // 引数のobjをTemperatureに変換
            var vo = obj as T;

            // 変換に失敗
            if (vo == null)
            {
                return false;
            }

            // インスタンスで比較せず、値で比較している
            return EqualsCore(vo);
        }

        public static bool operator ==(ValueObject<T> vol1,
            ValueObject<T> vol2)
        {
            // 上記のEqualsで値の比較ができているのでそれを利用する
            return Equals(vol1, vol2);
        }
        public static bool operator !=(ValueObject<T> vol1,
            ValueObject<T> vol2)
        {
            return !Equals(vol1, vol2);
        }

        protected abstract bool EqualsCore(T other);

    }
}
