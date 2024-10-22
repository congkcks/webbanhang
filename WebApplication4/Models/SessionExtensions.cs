using Newtonsoft.Json;

namespace WebApplication4.Models
{
    public static class SessionExtensions
    {
        private const string CartSessionKey = "Cart";

        public static void SetCart(this ISession session, List<CartItem> cart)
        {
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
        }

        public static List<CartItem> GetCart(this ISession session)
        {
            var cartJson = session.GetString(CartSessionKey);
            return cartJson == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        }
    }
}

