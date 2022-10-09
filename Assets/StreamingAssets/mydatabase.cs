using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

static class mydatabase
{
    private const string fileName = "mtsbase.db";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
}