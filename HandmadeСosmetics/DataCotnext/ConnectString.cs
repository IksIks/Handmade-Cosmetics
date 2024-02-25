using Microsoft.Extensions.Configuration;
using System.IO;

namespace HandmadeСosmetics.Connection
{
    internal static class ConnectString
    {
        public static string GetConnectionString()
        {
            IConfiguration configaration;
            var builder = new ConfigurationBuilder();
            configaration = builder.SetBasePath(Directory.GetCurrentDirectory() + "\\DataCotnext").AddJsonFile("ConnectionString.json").Build();
            return configaration.GetConnectionString("PGSQL");
            //try
            //{
            //    configaration = builder.SetBasePath(Directory.GetCurrentDirectory() + "\\Connection").AddJsonFile("Connection.json").Build();
            //    returnableString = configaration.GetConnectionString("PGSQL");
            //    return returnableString;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Отсутсвует файл с настройками подключения к БД", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return returnableString = "";
            //}
            //finally
            //{
            //    if (String.IsNullOrEmpty(returnableString))
            //        Application.Current.Shutdown();
            //}
        }
    }
}