using System.Data;
using System.Data.SQLite;
using WindowsFormsApp2.Common;

namespace WindowsFormsApp2.Data
{
    public static class WeatherSQLite
    {
        public static DataTable GetLatest(int areaId)
        {
            string sql = @"
select DateData, 
       Condition,
       Temperature
from Weather
where AreaId = @AreaId
order by DateData desc
LIMIT 1
";

            DataTable dt = new DataTable();
            using (var connection = new SQLiteConnection(CommonConst.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }


    }
}
