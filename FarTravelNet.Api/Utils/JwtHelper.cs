using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace FarTravelNet.Api.Utils
{
    /// <summary> 
    /// 创建人：落
    /// 日 期：2019/6/14 21:16:23
    /// 版 本：1.0
    /// 描 述：JWT帮助类
    /// </summary>
    public class JwtHelper
    {
        #region 编码

        /// <summary>
        /// 编码
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="payload"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Encode<T>(T payload, string key)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, key);
        }

        #endregion

        #region 解码

        /// <summary>
        /// 解码
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Decode<T>(string token, string key)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                return decoder.DecodeToObject<T>(token, key, verify: true);
            }
            catch
            {
                return default(T);
            }
        }

        #endregion

    }
}
