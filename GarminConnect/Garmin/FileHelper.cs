namespace GarminConnect
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 判断给定路径是否存在且是一个目录
        /// </summary>
        /// <param name="path">要检查的路径。</param>
        /// <returns>如果路径存在且为目录，则返回 true；否则返回 false。</returns>
        public static bool CheckIsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 如果目录不存在的话，创建目录
        /// </summary>
        /// <param name="path">目录</param>
        public static void CreateDirectory(string path)
        {
            if (!CheckIsDirectory(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 同步写入数据到指定文件路径
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="data">要写入的数据，可以是字符串或字节数组</param>
        public static void WriteToFile(string filePath, object data)
        {
            try
            {
                if (data is string strData)
                {
                    File.WriteAllText(filePath, strData);
                }
                else if (data is byte[] byteData)
                {
                    File.WriteAllBytes(filePath, byteData);
                }
                else
                {
                    throw new ArgumentException("Unsupported data type. Only string or byte[] are supported.");
                }
            }
            catch (Exception ex)
            {
                // 你可以根据需要处理异常，比如记录日志或重新抛出
                throw new IOException($"写入文件失败: {filePath}", ex);
            }
        }
    }
}



