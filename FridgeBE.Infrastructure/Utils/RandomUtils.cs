namespace FridgeBE.Infrastructure.Utils
{
    public class RandomUtils
    {
        public static string RandomName()
        {
            char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string randomNums = new string(new Random().GetItems(nums, 7));
            return $"user{randomNums}";
        }
    }
}