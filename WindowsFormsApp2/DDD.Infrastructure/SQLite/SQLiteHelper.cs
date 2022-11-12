using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Security.Cryptography;

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
            return QuerySingle<T>(sql, null, createEntity, nullEntity);
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

        internal static void Execute(
            string insert,
            string update,
            SQLiteParameter[] parameters)
        {
            using (var connection =
            new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(update, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                // 実行対象の件数が1件より少ない場合（対象のデータがない場合insertを実行）
                if (command.ExecuteNonQuery() < 1)
                {
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void Execute(
            string sql,
            SQLiteParameter[] parameters)
        {
            using (var connection =
            new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
