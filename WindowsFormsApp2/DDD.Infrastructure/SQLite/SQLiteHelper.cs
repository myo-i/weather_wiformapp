using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite
{
    internal class SQLiteHelper
    {
        internal const string ConnectionString = @"Data Source=C:\Users\PC_User\Desktop\DDD5.db;Version=3;";

        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }


        // stringでSQｌを投げたら実行する
        // IReadOnlyList<T>は戻り値のこと
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity)
        {
            var result = new List<T>();
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(createEntity(reader));
                    }
                }
            }

            return result;
        }

        internal static T QuerySingle<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            return QuerySingle<T>(sql, null, createEntity, nullEntity)
        }


        // Tは戻り値のこと
        internal static T QuerySingle<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                if(parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return createEntity(reader);
                    }
                }
            }

            return nullEntity;
        }
    }
}
