using System.Text.Json;
using System.IO;
using MySql.Data.MySqlClient;

namespace chaoxing_question_bank_handler
{
    // TODO: 封装 MySQL 操作（单例模式）
    public class MysqlHelper
    {
        private static readonly string _configFilePath = "config.json";
        private string _connStr;
        public static MysqlHelper Instance { get; } = new MysqlHelper();
        private MysqlHelper()
        {
            _connStr = GetConnectionString();
        }

        /// <summary>
        /// 读取配置文件获取数据库连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        /// <exception cref="FileNotFoundException">未找到配置文件</exception>
        /// <exception cref="FileNotFoundException">无法获取配置文件中的数据库连接字符串</exception>
        private static string GetConnectionString()
        {
            if (File.Exists(_configFilePath))
            {
                string jsonStr = File.ReadAllText(_configFilePath);
                using JsonDocument json = JsonDocument.Parse(jsonStr);
                JsonElement root = json.RootElement;
                string? connStr = root.GetProperty("Database").GetProperty("ConnectionString").GetString();
                if (string.IsNullOrWhiteSpace(connStr))
                {
                    throw new ArgumentException("配置文件中数据库连接字符串为空！");
                }
                return connStr;
            }
            else
            {
                throw new FileNotFoundException("配置文件不存在！", _configFilePath);
            }
        }

        /// <summary>
        /// SQL语句字典
        /// </summary>
        public static Dictionary<string, string> SqlSentence { get; } = new()
        {
            {"",""}
        };
    }
}