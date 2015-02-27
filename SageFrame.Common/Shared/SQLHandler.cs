/*
SageFrame® - http://www.sageframe.com
Copyright (c) 2009-2012 by SageFrame
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.VisualBasic;
using SageFrame.Web;
using System.Data;

namespace SageFrame.Web.Utilities
{
    public class SQLHandler
    {
        #region "Private Members"

        private string _objectQualifier = SystemSetting.ObjectQualifer;
        private string _databaseOwner = SystemSetting.DataBaseOwner;
        private string _connectionString = SystemSetting.SageFrameConnectionString;

        #endregion

        #region "Constructors"



        #endregion

        #region "Properties"

        public string objectQualifier
        {
            get { return _objectQualifier; }
            set { _objectQualifier = value; }
        }

        public string databaseOwner
        {
            get { return _databaseOwner; }
            set { _databaseOwner = value; }
        }

        public string connectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        #endregion

        #region "Transaction Methods"

        public void CommitTransaction(DbTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            finally
            {
                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Connection.Close();
                }
            }
        }

        public DbTransaction GetTransaction()
        {
            SqlConnection Conn = new SqlConnection(this.connectionString);
            Conn.Open();
            SqlTransaction transaction = Conn.BeginTransaction();
            return transaction;
        }

        public void RollbackTransaction(DbTransaction transaction)
        {
            try
            {
                transaction.Rollback();
            }
            finally
            {
                if (transaction != null && transaction.Connection != null)
                {
                    transaction.Connection.Close();
                }
            }
        }

        #region Using Transaction Method
        public static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //if the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            //associate the connection with the command
            command.Connection = connection;
            command.Transaction = transaction;
            command.CommandType = commandType;
            command.CommandText = commandText;
            return;
        }

        public int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, List<KeyValuePair<string, object>> ParaMeterCollection, string outParamName)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText);

            for (int i = 0; i < ParaMeterCollection.Count(); i++)
            {
                SqlParameter sqlParaMeter = new SqlParameter();
                sqlParaMeter.IsNullable = true;
                sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                sqlParaMeter.Value = ParaMeterCollection[i].Value;
                cmd.Parameters.Add(sqlParaMeter);
            }
            cmd.Parameters.Add(new SqlParameter(outParamName, SqlDbType.Int));
            cmd.Parameters[outParamName].Direction = ParameterDirection.Output;

            //finally, execute the command.
            cmd.ExecuteNonQuery();
            int id = (int)cmd.Parameters[outParamName].Value;

            // detach the OracleParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return id;
        }

        public void ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            //create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText);

            for (int i = 0; i < ParaMeterCollection.Count(); i++)
            {
                SqlParameter sqlParaMeter = new SqlParameter();
                sqlParaMeter.IsNullable = true;
                sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                sqlParaMeter.Value = ParaMeterCollection[i].Value;
                cmd.Parameters.Add(sqlParaMeter);
            }

            //finally, execute the command.
            cmd.ExecuteNonQuery();

            // detach the OracleParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();

        }
        #endregion

        #endregion

        #region "SQL Execute Methods"

        private void ExecuteADOScript(SqlTransaction trans, string SQL)
        {
            SqlConnection connection = trans.Connection;
            //Create a new command (with no timeout)
            SqlCommand command = new SqlCommand(SQL, trans.Connection);
            command.Transaction = trans;
            command.CommandTimeout = 0;
            command.ExecuteNonQuery();
        }

        private void ExecuteADOScript(string SQL)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            //Create a new command (with no timeout)
            SqlCommand command = new SqlCommand(SQL, connection);
            connection.Open();
            command.CommandTimeout = 0;
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void ExecuteADOScript(string SQL, string ConnectionString)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            //Create a new command (with no timeout)
            SqlCommand command = new SqlCommand(SQL, connection);
            connection.Open();
            command.CommandTimeout = 0;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public string ExecuteScript(string Script)
        {
            return ExecuteScript(Script, false);
        }

        public string ExecuteScript(string Script, DbTransaction transaction)
        {
            string SQL = string.Empty;
            string Exceptions = string.Empty;
            string Delimiter = "GO" + Environment.NewLine;

            string[] arrSQL = Microsoft.VisualBasic.Strings.Split(Script, Delimiter, -1, Microsoft.VisualBasic.CompareMethod.Text);
            bool IgnoreErrors;
            foreach (string SQLforeach in arrSQL)
            {
                if (!string.IsNullOrEmpty(SQLforeach))
                {
                    //script dynamic substitution
                    SQL = SQLforeach;
                    SQL = SQL.Replace("{databaseOwner}", this.databaseOwner);
                    SQL = SQL.Replace("{objectQualifier}", this.objectQualifier);

                    IgnoreErrors = false;

                    if (SQL.Trim().StartsWith("{IgnoreError}"))
                    {
                        IgnoreErrors = true;
                        SQL = SQL.Replace("{IgnoreError}", "");
                    }
                    try
                    {
                        ExecuteADOScript(transaction as SqlTransaction, SQL);
                    }
                    catch (Exception ex)
                    {
                        if (!IgnoreErrors)
                        {
                            Exceptions += ex.ToString() + Environment.NewLine + Environment.NewLine + SQL + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
            }
            return Exceptions;
        }

        public string ExecuteScript(string Script, bool UseTransactions)
        {
            string SQL = string.Empty;
            string Exceptions = string.Empty;

            if (UseTransactions)
            {
                DbTransaction transaction = GetTransaction();
                try
                {
                    Exceptions += ExecuteScript(Script, transaction);

                    if (Exceptions.Length == 0)
                    {
                        //No exceptions so go ahead and commit
                        CommitTransaction(transaction);
                    }
                    else
                    {
                        //Found exceptions, so rollback db
                        RollbackTransaction(transaction);
                        Exceptions += "SQL Execution failed.  Database was rolled back" + Environment.NewLine + Environment.NewLine + SQL + Environment.NewLine + Environment.NewLine;
                    }
                }
                finally
                {
                    if (transaction.Connection != null)
                    {

                        transaction.Connection.Close();
                    }
                }
            }
            else
            {
                string Delimiter = "GO" + Environment.NewLine;
                string[] arrSQL = Microsoft.VisualBasic.Strings.Split(Script, Delimiter, -1, CompareMethod.Text);
                foreach (string SQLforeach in arrSQL)
                {
                    if (!string.IsNullOrEmpty(SQLforeach))
                    {
                        SQL = SQLforeach;
                        SQL = SQL.Replace("{databaseOwner}", this.databaseOwner);
                        SQL = SQL.Replace("{objectQualifier}", this.objectQualifier);
                        try
                        {
                            ExecuteADOScript(SQL);
                        }
                        catch (Exception ex)
                        {
                            Exceptions += ex.ToString() + Environment.NewLine + Environment.NewLine + SQL + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
            }

            return Exceptions;
        }

        public string ExecuteInstallScript(string Script, string ConnectionString)
        {
            string SQL = string.Empty;
            string Exceptions = string.Empty;

            string Delimiter = "GO" + Environment.NewLine;
            string[] arrSQL = Microsoft.VisualBasic.Strings.Split(Script, Delimiter, -1, CompareMethod.Text);
            foreach (string SQLforeach in arrSQL)
            {
                if (!string.IsNullOrEmpty(SQLforeach))
                {
                    SQL = SQLforeach;
                    SQL = SQL.Replace("{databaseOwner}", this.databaseOwner);
                    SQL = SQL.Replace("{objectQualifier}", this.objectQualifier);
                    try
                    {
                        ExecuteADOScript(SQL, ConnectionString);
                    }
                    catch (Exception ex)
                    {
                        Exceptions += ex.ToString() + Environment.NewLine + Environment.NewLine + SQL + Environment.NewLine + Environment.NewLine;
                    }
                }
            }
            return Exceptions;
        }


        #endregion



        public void ModulesRollBack(int ModuleID, int PortalID)
        {
            try
            {
                SqlConnection SQLConn = new SqlConnection(this._connectionString);
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = "dbo.sp_ModulesRollBack";
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLCmd.Parameters.Add(new SqlParameter("@ModuleID", ModuleID));
                SQLCmd.Parameters.Add(new SqlParameter("@PortalID", PortalID));
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                SQLConn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ExecuteNonQueryAsBool(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection, string OutPutParamerterName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {                
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Bit));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                bool ReturnValue = (bool)SQLCmd.Parameters[OutPutParamerterName].Value;
               
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public bool ExecuteNonQueryAsBool(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection, string OutPutParamerterName, object OutPutParamerterValue)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Bit));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
                SQLCmd.Parameters[OutPutParamerterName].Value = OutPutParamerterValue;

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                bool ReturnValue = (bool)SQLCmd.Parameters[OutPutParamerterName].Value;               
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }        

        public void ExecuteNonQuery(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public void ExecuteNonQuery(string StroredProcedureName, List<KeyValuePair<string, string>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SQLCmd.Parameters.Add(new SqlParameter(ParaMeterCollection[i].Key, ParaMeterCollection[i].Value));
                }
                //End of for loop

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
               
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public void ExecuteNonQuery(string StroredProcedureName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        /// <summary>
        /// Accept only int, Int16, long, DateTime, string (NVarcha of size  50),
        /// bool, decimal ( of size 16,2), float
        /// </summary>
        /// <typeparam name="T">Return the given type of object</typeparam>
        /// <param name="StroredProcedureName">Accet SQL procedure name in string</param>
        /// <param name="ParaMeterCollection">Accept Key Value Collection for parameters</param>
        /// <param name="OutPutParamerterName">Accept Output parameter for the stored procedures</param>
        /// <returns></returns>
        public T ExecuteNonQueryAsGivenType<T>(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection, string OutPutParamerterName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {                
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop                
                SQLCmd = AddOutPutParametrofGivenType<T>(SQLCmd, OutPutParamerterName);
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                return (T)SQLCmd.Parameters[OutPutParamerterName].Value;;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        /// <summary>
        /// Accept only int, Int16, long, DateTime, string (NVarcha of size  50),
        /// bool, decimal ( of size 16,2), float
        /// </summary>
        /// <typeparam name="T">Return the given type of object</typeparam>
        /// <param name="StroredProcedureName">Accet SQL procedure name in string</param>
        /// <param name="ParaMeterCollection">Accept Key Value Collection for parameters</param>
        /// <param name="OutPutParamerterName">Accept Output parameter for the stored procedures</param>
        /// <returns></returns>
        public T ExecuteNonQueryAsGivenType<T>(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection, string OutPutParamerterName, object OutPutParamerterValue)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop                
                SQLCmd = AddOutPutParametrofGivenType<T>(SQLCmd, OutPutParamerterName, OutPutParamerterValue);
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                return (T)SQLCmd.Parameters[OutPutParamerterName].Value; ;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public SqlCommand AddOutPutParametrofGivenType<T>(SqlCommand SQLCmd, string OutPutParamerterName)
        {            
            if(typeof(T) == typeof(int))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(Int16))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }            
            if (typeof(T) == typeof(long))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.BigInt));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(DateTime))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.DateTime));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }            
            if (typeof(T) == typeof(string))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.NVarChar,50));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(bool))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Bit));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(decimal))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Decimal));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
                SQLCmd.Parameters[OutPutParamerterName].Precision = 16;
                SQLCmd.Parameters[OutPutParamerterName].Scale = 2;
            }
            if (typeof(T) == typeof(float))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Float));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }            
            return SQLCmd;
        }

        public SqlCommand AddOutPutParametrofGivenType<T>(SqlCommand SQLCmd, string OutPutParamerterName, object OutPutParamerterValue)
        {
            if (typeof(T) == typeof(int))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(Int16))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(long))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.BigInt));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(DateTime))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.DateTime));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(string))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.NVarChar, 50));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(bool))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Bit));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            if (typeof(T) == typeof(decimal))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Decimal));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
                SQLCmd.Parameters[OutPutParamerterName].Precision = 16;
                SQLCmd.Parameters[OutPutParamerterName].Scale = 2;
            }
            if (typeof(T) == typeof(float))
            {
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Float));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
            }
            SQLCmd.Parameters[OutPutParamerterName].Value = OutPutParamerterValue;
            return SQLCmd;
        }

        public int ExecuteNonQuery(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection, string OutPutParamerterName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                int ReturnValue = (int)SQLCmd.Parameters[OutPutParamerterName].Value;
                SQLConn.Close();
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }
        public int ExecuteNonQuery(string StroredProcedureName, List<KeyValuePair<string, string>> ParaMeterCollection, string OutPutParamerterName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SQLCmd.Parameters.Add(new SqlParameter(ParaMeterCollection[i].Key, ParaMeterCollection[i].Value));
                }
                //End of for loop
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                int ReturnValue = (int)SQLCmd.Parameters[OutPutParamerterName].Value;
                SQLConn.Close();
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }
        public int ExecuteNonQuery(string StroredProcedureName, List<KeyValuePair<string, string>> ParaMeterCollection, string OutPutParamerterName, object OutPutParamerterValue)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SQLCmd.Parameters.Add(new SqlParameter(ParaMeterCollection[i].Key, ParaMeterCollection[i].Value));
                }
                //End of for loop
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
                SQLCmd.Parameters[OutPutParamerterName].Value = OutPutParamerterValue;

                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                int ReturnValue = (int)SQLCmd.Parameters[OutPutParamerterName].Value;
                SQLConn.Close();
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public int ExecuteNonQuery(string StroredProcedureName, string OutPutParamerterName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                int ReturnValue = (int)SQLCmd.Parameters[OutPutParamerterName].Value;
                SQLConn.Close();
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public int ExecuteNonQuery(string StroredProcedureName, string OutPutParamerterName, object OutPutParamerterValue)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLCmd.Parameters.Add(new SqlParameter(OutPutParamerterName, SqlDbType.Int));
                SQLCmd.Parameters[OutPutParamerterName].Direction = ParameterDirection.Output;
                SQLCmd.Parameters[OutPutParamerterName].Value = OutPutParamerterValue;
                SQLConn.Open();
                SQLCmd.ExecuteNonQuery();
                int ReturnValue = (int)SQLCmd.Parameters[OutPutParamerterName].Value;
                SQLConn.Close();
                return ReturnValue;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public DataSet ExecuteAsDataSet(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlCommand SQLCmd = new SqlCommand();
                SqlDataAdapter SQLAdapter = new SqlDataAdapter();
                DataSet SQLds = new DataSet();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;

                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop

                SQLAdapter.SelectCommand = SQLCmd;
                SQLConn.Open();
                SQLAdapter.Fill(SQLds);
                SQLConn.Close();
                return SQLds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public DataSet ExecuteAsDataSet(string StroredProcedureName, List<KeyValuePair<string, string>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                
                SqlCommand SQLCmd = new SqlCommand();
                SqlDataAdapter SQLAdapter = new SqlDataAdapter();
                DataSet SQLds = new DataSet();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;

                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SQLCmd.Parameters.Add(new SqlParameter(ParaMeterCollection[i].Key, ParaMeterCollection[i].Value));
                }
                //End of for loop

                SQLAdapter.SelectCommand = SQLCmd;
                SQLConn.Open();
                SQLAdapter.Fill(SQLds);
                SQLConn.Close();
                return SQLds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }
        public SqlDataReader ExecuteAsDataReader(string StroredProcedureName)
        {
            try
            {
                SqlConnection SQLConn = new SqlConnection(this._connectionString);
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection); 

                return SQLReader;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public SqlDataReader ExecuteAsDataReader(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            try
            {
                SqlConnection SQLConn = new SqlConnection(this._connectionString);
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection); 
                return SQLReader;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlDataReader ExecuteAsDataReader(string StroredProcedureName, List<KeyValuePair<string, string>> ParaMeterCollection)
        {
            try
            {
                SqlConnection SQLConn = new SqlConnection(this._connectionString);
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SQLCmd.Parameters.Add(new SqlParameter(ParaMeterCollection[i].Key, ParaMeterCollection[i].Value));
                }
                //End of for loop
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return SQLReader;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public T ExecuteAsObject<T>(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Parameters
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection);
                ArrayList arrColl = DataSourceHelper.FillCollection(SQLReader, typeof(T));
                SQLConn.Close();
                if (SQLReader != null)
                {
                    SQLReader.Close();
                }
                if (arrColl != null && arrColl.Count > 0)
                {
                    return (T)arrColl[0];
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public T ExecuteAsObject<T>(string StroredProcedureName, List<KeyValuePair<string,string>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SQLCmd.Parameters.Add(new SqlParameter(ParaMeterCollection[i].Key, ParaMeterCollection[i].Value));                    
                }
                //End of for loop
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader();
                ArrayList arrColl = DataSourceHelper.FillCollection(SQLReader, typeof(T));
                SQLConn.Close();
                if (SQLReader != null)
                {
                    SQLReader.Close();
                }
                if (arrColl != null && arrColl.Count > 0)
                {                   
                    return (T)arrColl[0];
                }
                else
                {                    
                    return default(T);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public T ExecuteAsObject<T>(string StroredProcedureName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader();
                ArrayList arrColl = DataSourceHelper.FillCollection(SQLReader, typeof(T));
                SQLConn.Close();
                if (SQLReader != null)
                {
                    SQLReader.Close();
                }
                if (arrColl != null && arrColl.Count > 0)
                {
                    return (T)arrColl[0];
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public DataSet ExecuteAsDataSet(string StroredProcedureName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                
                SqlCommand SQLCmd = new SqlCommand();
                SqlDataAdapter SQLAdapter = new SqlDataAdapter();
                DataSet SQLds = new DataSet();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLAdapter.SelectCommand = SQLCmd;
                SQLConn.Open();
                SQLAdapter.Fill(SQLds);
                SQLConn.Close();
                return SQLds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public DataTable ExecuteSQL(string SQL)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SQL = SQL.Replace("{databaseOwner}", this.databaseOwner);
                SQL = SQL.Replace("{objectQualifier}", this.objectQualifier);

                
                SqlCommand SQLCmd = new SqlCommand();
                SqlDataAdapter SQLAdapter = new SqlDataAdapter();
                DataSet SQLds = new DataSet();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = SQL;
                SQLCmd.CommandType = CommandType.Text;
                SQLAdapter.SelectCommand = SQLCmd;
                SQLConn.Open();
                SQLAdapter.Fill(SQLds);
                SQLConn.Close();
                DataTable dt = null;// = new DataTable();
                if (SQLds != null && SQLds.Tables != null && SQLds.Tables[0] != null)
                {
                    dt = SQLds.Tables[0];
                }
                return dt;
            }
            catch
            {
                DataTable dt = null;
                return dt;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public List<T> ExecuteAsList<T>(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);                   
                    
                }
                //End of for loop
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection); //datareader automatically closes the SQL connection
                List<T> mList = new List<T>();
                mList = DataSourceHelper.FillCollection<T>(SQLReader);
                if (SQLReader != null)
                {
                    SQLReader.Close();
                }
                SQLConn.Close();
                return mList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public List<T> ExecuteAsList<T>(string StroredProcedureName, List<KeyValuePair<string, string>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection); //datareader automatically closes the SQL connection
                List<T> mList = new List<T>();
                mList = DataSourceHelper.FillCollection<T>(SQLReader);
                if (SQLReader != null)
                {
                    SQLReader.Close();
                }
                SQLConn.Close();
                return mList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public List<T> ExecuteAsList<T>(string StroredProcedureName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
               
                SqlDataReader SQLReader;
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;

                SQLConn.Open();
                SQLReader = SQLCmd.ExecuteReader(CommandBehavior.CloseConnection); //datareader automatically closes the SQL connection
                List<T> mList = new List<T>();
                mList = DataSourceHelper.FillCollection<T>(SQLReader);
                if (SQLReader != null)
                {
                    SQLReader.Close();
                }
                SQLConn.Close();
                return mList;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public T ExecuteAsScalar<T>(string StroredProcedureName, List<KeyValuePair<string, object>> ParaMeterCollection)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {

                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                //Loop for Paramets
                for (int i = 0; i < ParaMeterCollection.Count; i++)
                {
                    SqlParameter sqlParaMeter = new SqlParameter();
                    sqlParaMeter.IsNullable = true;
                    sqlParaMeter.ParameterName = ParaMeterCollection[i].Key;
                    sqlParaMeter.Value = ParaMeterCollection[i].Value;
                    SQLCmd.Parameters.Add(sqlParaMeter);
                }
                //End of for loop
                SQLConn.Open();
                return (T)SQLCmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }

        public T ExecuteAsScalar<T>(string StroredProcedureName)
        {
            SqlConnection SQLConn = new SqlConnection(this._connectionString);
            try
            {
                SqlCommand SQLCmd = new SqlCommand();
                SQLCmd.Connection = SQLConn;
                SQLCmd.CommandText = StroredProcedureName;
                SQLCmd.CommandType = CommandType.StoredProcedure;
                SQLConn.Open();
                return (T)SQLCmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SQLConn.Close();
            }
        }
    }
}
