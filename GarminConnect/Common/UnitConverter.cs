namespace GarminConnect
{
    /// <summary>
    /// 单位转换器
    /// </summary>
    public class UnitConverter
    {
        #region 液体单位
        /// <summary>
        /// 毫升转换为盎司
        /// </summary>
        /// <param name="valueInML">毫升/param>
        /// <returns>盎司</returns>
        public static double ConvertMLToOunces(double valueInML)
        {
            const double conversionFactor = 0.033814;
            double valueInOunces = valueInML * conversionFactor;
            return valueInOunces;
        }

        /// <summary>
        /// 盎司转换为毫升
        /// </summary>
        /// <param name="ounces">盎司</param>
        /// <returns>毫升</returns>
        public static double ConvertOuncesToML(double ounces)
        {
            const double ouncesToMillilitersConversionFactor = 29.5735;
            double milliliters = ounces * ouncesToMillilitersConversionFactor;
            return milliliters;
        }
        #endregion

        #region 重量单位
        /// <summary>
        /// 克转换为磅
        /// </summary>
        /// <param name="weightInGrams">克</param>
        /// <returns>磅</returns>
        public static double GramsToPounds(double weightInGrams)
        {
            const double gramsPerPound = 453.592;
            return weightInGrams / gramsPerPound;
        }
        #endregion


    }
}
