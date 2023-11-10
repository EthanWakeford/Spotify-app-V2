namespace v2_spotify_app
{
    using System;
    using System.IO;

    public class Config
    {

        public readonly string clientId;
        public readonly string clientSecret;

        public Config()
        {
            // loading dotenv file in ENV
            var root = Directory.GetCurrentDirectory();
            var dotenv = Path.Combine(root, ".env");
            Load(dotenv);

            clientId = Environment.GetEnvironmentVariable("CLIENT_ID") ?? throw new Exception("client id is null");
            clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET") ?? throw new Exception("client secret is null");
        }

        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}
