using GarminConnect;
using GarminConnect.Garmin;
using System.IO.Compression;

namespace UnitTestGarminSync
{
    public class Tests
    {
        /// <summary>
        /// 用户凭证：此处请替换为您的实际用户名和密码
        /// </summary>
        private readonly GCCredentials _credentials = new()
        {
            Username = "xxxxxxxxxxxxxxxxx@qq.com",
            Password = "xxxxxxxxxxxxxxxxxxxx"
        };

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        /// <summary>
        /// 测试连接佳明国区
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestConnectCN()
        {
            GarminDomain domain = GarminDomain.GarminCN;
            var clientCN = new GarminConnectClient(_credentials, domain);
            await clientCN.LoginAsync();

            Assert.Pass();
        }

        /// <summary>
        /// 测试连接佳明国际区
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestConnectCOM()
        {
            GarminDomain domain = GarminDomain.GarminCom;
            var clientCN = new GarminConnectClient(_credentials, domain);
            await clientCN.LoginAsync();

            Assert.Pass();
        }

        /// <summary>
        /// 测试同步国区数据到国际区
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestSyncCycleData()
        {
            // 获取当前运行目录
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            // 目标文件夹路径
            string folderPath = Path.Combine(currentDir, "Download");

            // 如果文件夹不存在，创建它
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 目标文件完整路径
            string filePath = Path.Combine(folderPath, "Download");

            var clientCN = new GarminConnectClient(_credentials, GarminDomain.GarminCN);
            await clientCN.LoginAsync();

            var clientCom = new GarminConnectClient(_credentials, GarminDomain.GarminCom);
            await clientCom.LoginAsync();

            var activitiesCN = await clientCN.GetActivitiesAsync(0, 10);

            var activitiesCom = await clientCom.GetActivitiesAsync(0, 10);

            var difference = activitiesCN.Where(t => !activitiesCom.Any(x => x.StartTimeLocal == t.StartTimeLocal && x.StartTimeGMT == t.StartTimeGMT)).ToList();

            foreach (var item in difference)
            {
                var itemPath = $"{filePath}_{item.ActivityName}{item.ActivityId}.zip";

                await clientCN.DownloadOriginalActivityDataAsync(item.ActivityId, itemPath);

                //解压数据
                var fitFilePath = UnZipGarminActivity(itemPath);

                var result = await clientCom.UploadActivityAsync(fitFilePath);
                if (result == null)
                {
                    throw new Exception("上传活动失败");
                }
            }

            Assert.Pass();
        }

        /// <summary>
        /// 解压佳明活动数据
        /// </summary>
        /// <param name="zipFilePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string UnZipGarminActivity(string zipFilePath)
        {
            // 解压目录，这里用同一个目录
            string extractDir = Path.GetDirectoryName(zipFilePath);

            // 解压 zip 文件
            ZipFile.ExtractToDirectory(zipFilePath, extractDir, overwriteFiles: true);

            // 获取解压后的第一个文件路径
            string[] extractedFiles = Directory.GetFiles(extractDir);

            if (extractedFiles.Length == 0)
            {
                throw new Exception("解压后没有找到文件");
            }

            string unzippedFilePath = extractedFiles[0];

            Console.WriteLine("DownloadGarminActivity - path: " + unzippedFilePath);

            return unzippedFilePath;
        }
    }
}
