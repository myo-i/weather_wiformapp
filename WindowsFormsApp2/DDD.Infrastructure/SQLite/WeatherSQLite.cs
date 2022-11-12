using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {

        public WeatherEntity GetLatest(int areaId)
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

            return SQLiteHelper.QuerySingle(
                sql, 
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaID", areaId)
                }.ToArray(),                
                reader => 
                {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DateData"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                }, 
                null);

            //using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            //using (var command = new SQLiteCommand(sql, connection))
            //{
            //    connection.Open();

            //    command.Parameters.AddWithValue("@AreaId", areaId);
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            return new WeatherEntity(
            //                areaId,
            //                Convert.ToDateTime(reader["DateData"]),
            //                Convert.ToInt32(reader["Condition"]),
            //                Convert.ToSingle(reader["Temperature"]));
            //        }
            //    }
            //}
            //return null;
        }

        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
select A.AreaId,
         ifnull(B.AreaName,'') as AreaName,
         A.DateData,
         A.Condition,
         A.Temperature
from Weather A
left outer join Areas B
on A.AreaId = B.AreaId
";

            return SQLiteHelper.Query(
                sql,
                reader =>
                {
                    return new WeatherEntity(
                            // クラス上部のエンティティではareaIdを入力するためareaIdとしているが、
                            // 今回はSQLから値を取るので下記のように記述する
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"]),
                            Convert.ToDateTime(reader["DateData"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                });
        }

        public void Save(WeatherEntity weather)
        {
            string insert = @"
insert into Weather
(AreaId,DateData,Condition,Temperature)
values
(@AreaId,@DateData,@Condition,@Temperature)
";

            string update = @"
update Weather
set Condition = @Condition,
    Temperature = @Temperature
where AreaId = @AreaId
and DateData = @DateData
";

            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@AreaId", weather.AreaId.Value),
                new SQLiteParameter("@DateData", weather.DateData),
                new SQLiteParameter("@Condition", weather.Condition.Value),
                new SQLiteParameter("@Temperature", weather.Temperature.Value)
            };

            // Execute内のAddRangeがリストではなく配列が必要なので配列に変換する必要がある
            SQLiteHelper.Execute(insert, update, args.ToArray());
        }
    }
}
