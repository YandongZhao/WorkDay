using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class SqlHelper
    {
        public SqlTransaction MyTran;
        public SqlConnection Cn;
        
        public SqlHelper(string connStr)
        {
            Cn = new SqlConnection(connStr);
        }
        #region ExecuteNonQuery 增删改方法

        /// <summary>
        /// 执行SQL语句的增删改方法
        /// </summary>
        /// <param name="sqlObject">SQL语句</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>受影响行数</returns>
        public bool ExecuteNonQuery(string sqlObject, params SqlParameter[] paramerts)
        {
            if (Cn.State != ConnectionState.Open)
            {
                Cn.Open();
            }
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            int rows;
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                Cn.Close();
                cmd.Dispose();
            }
            return rows > 0;
        }

        /// <summary>
        /// 执行存储过程的增删改方法
        /// </summary>
        /// <param name="sqlObject">存储过程名称</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>存储过程的返回值</returns>
        public int ExecuteNonQueryProc(string sqlObject, params SqlParameter[] paramerts)
        {
            Cn.Open();
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            cmd.CommandType = CommandType.StoredProcedure;
            int rows;
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Cn.Close();
            }
            return rows;
        }

        /// <summary>
        /// 使用事务执行SQL语句的增删改方法
        /// </summary>
        /// <param name="SQLObject">SQL语句</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>事务是否执行成功</returns>
        public bool ExecuteNonQueryTrans(string[] SQLObject, params SqlParameter[][] paramerts)
        {
            Cn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction ta = Cn.BeginTransaction();
            cmd.Transaction = ta;
            try
            {
                for (int i = 0; i < SQLObject.Length; i++)
                {
                    cmd = InitCommand(SQLObject[i], paramerts[i]);
                    cmd.ExecuteNonQuery();
                }
                ta.Commit();
            }
            catch
            {
                ta.Rollback();
            }
            finally
            {
                Cn.Close();
            }
            return true;
        }

        #endregion

        #region ExecuteScalar 获取标量值

        /// <summary>
        /// 执行SQL语句获取标量值方法
        /// </summary>
        /// <param name="sqlObject">SQL语句</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>标量值</returns>
        public object ExecuteScalar(string sqlObject, params SqlParameter[] paramerts)
        {
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            Cn.Open();
            object o;
            try
            {
                o = cmd.ExecuteScalar();
            }
            catch
            {
                return null;
            }
            finally
            {
                Cn.Close();
            }
            return o;
        }

        /// <summary>
        /// 执行存储过程获取标量值方法
        /// </summary>
        /// <param name="sqlObject">存储过名称程</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>标量值</returns>
        public object ExecuteScalarProc(string sqlObject, params SqlParameter[] paramerts)
        {
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            cmd.CommandType = CommandType.StoredProcedure;
            Cn.Open();
            object o;
            try
            {
                o = cmd.ExecuteScalar();
            }
            catch
            {
                return null;
            }
            finally
            {
                Cn.Close();
            }
            return o;
        }

        #endregion

        #region ExecuteDataSet 获取数据集

        /// <summary>
        /// 执行SQL语句获取数据集的方法
        /// </summary>
        /// <param name="sqlObject"></param>
        /// <param name="paramerts"></param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteDataTable(string sqlObject, params SqlParameter[] paramerts)
        {
            DataTable ds = new DataTable();
            SqlCommand cmd  = InitCommand(sqlObject, paramerts);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 执行SQL语句获取数据集的方法
        /// </summary>
        /// <param name="sqlObject"></param>
        /// <param name="paramerts"></param>		
        /// <returns>返回DataSet</returns>
        public DataSet ExecuteDataSet(string sqlObject, params SqlParameter[] paramerts)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }



        /// <summary>
        /// 执行存储过程获取数据集的方法
        /// </summary>
        /// <param name="sqlObject">存储过程名称</param>
        /// <param name="paramerts"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSetProc(string sqlObject, params SqlParameter[] paramerts)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 执行视图获取数据集的方法
        /// </summary>
        /// <param name="sqlObject">视图或者表的名称</param>
        /// <param name="paramerts"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSetView(string sqlObject, SqlParameter[] paramerts)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = InitCommand(sqlObject, paramerts);
            cmd.CommandType = CommandType.TableDirect;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
        #endregion

        #region ExecuteDataReader 获取流水游标

        /// <summary>
        /// 执行SQL语句获取流水游标的方法
        /// </summary>
        /// <param name="sqlObject">SQL语句</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>指向查询结果的流水游标</returns>		
        public SqlDataReader ExecuteDataReader(string sqlObject, params SqlParameter[] paramerts)
        {
            try
            {
                SqlCommand cmd = InitCommand(sqlObject, paramerts);
                Cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                Cn.Close();
                return null;
            }
        }
        /// <summary>
        ///执行存储过程获取流水游标的方法
        /// </summary>
        /// <param name="sqlObject">存储过程名称</param>
        /// <param name="paramerts">参数数组</param>
        /// <returns>指向查询结果的流水游标</returns>		
        public SqlDataReader ExecuteDataReaderProc(string sqlObject, params SqlParameter[] paramerts)
        {
            try
            {
                SqlCommand cmd = InitCommand(sqlObject, paramerts);
                cmd.CommandType = CommandType.StoredProcedure;
                Cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                Cn.Close();
                return null;
            }
        }
        #endregion

        #region InitCommand 设置命令集参数
        /// <summary>
        /// //扩展QuerryCMD
        /// </summary>
        /// <param name="sqlObject"></param>
        /// <param name="paramerts"></param>
        /// <returns></returns>
        private SqlCommand InitCommand(string sqlObject, params SqlParameter[] paramerts)
        {
            SqlCommand cmd = new SqlCommand(sqlObject, Cn);
            if (paramerts != null)
            {
                foreach (SqlParameter pt in paramerts)//往Command里添加参数
                {
                    cmd.Parameters.Add(pt);
                }
            }
           
            return cmd;
        }
        private SqlCommand InitCommandProc(string sqlObject, IEnumerable<SqlParameter> paramerts)
        {
            SqlCommand cmd = new SqlCommand(sqlObject, Cn);
            foreach (SqlParameter pt in paramerts)//往Command里添加参数
            {
                cmd.Parameters.Add(pt);
            }
            SqlParameter pa = new SqlParameter("ReturnValue", SqlDbType.Int, 6, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null);//添加参数映射返回值
            cmd.Parameters.Add(pa);
            return cmd;
        }

        #endregion

        #region SqlParameter 含NULL类型实例
        /// <summary>
        /// 设置含NULL类型Int参数
        /// </summary>
        /// <param name="pName">Sql参数名</param>
        /// <param name="str">参数值</param>
        /// <returns></returns>
        public static SqlParameter SetIntSqlParameter(string pName, string str)
        {
            if (str.Trim() == "")
            {
                return new SqlParameter(pName, DBNull.Value);
            }
            return new SqlParameter(pName, int.Parse(str));
        }

        /// <summary>
        /// 设置含NULL类型String参数
        /// </summary>
        /// <param name="pName">Sql参数名</param>
        /// <param name="str">参数值</param>
        /// <returns></returns>
        public static SqlParameter SetStrSqlParameter(string pName, string str)
        {
            if (str.Trim() == "")
            {
                return new SqlParameter(pName, DBNull.Value);
            }
            return new SqlParameter(pName, str.Trim());
        }

        /// <summary>
        /// 设置含NULL类型Float参数
        /// </summary>
        /// <param name="pName">Sql参数名</param>
        /// <param name="str">参数值</param>
        /// <returns></returns>
        public static SqlParameter SetFloatSqlParameter(string pName, string str)
        {
            if (str.Trim() == "")
            {
                return new SqlParameter(pName, DBNull.Value);
            }
            return new SqlParameter(pName, float.Parse(str));
        }

        /// <summary>
        /// 设置含NULL类型Float参数
        /// </summary>
        /// <param name="pName">Sql参数名</param>
        /// <param name="str">参数值</param>
        /// <returns></returns>
        public static SqlParameter SetDoubleSqlParameter(string pName, string str)
        {
            if (str.Trim() == "")
            {
                return new SqlParameter(pName, DBNull.Value);
            }
            return new SqlParameter(pName, double.Parse(str));
        }

        /// <summary>
        /// 设置含NULL类型Float参数
        /// </summary>
        /// <param name="pName">Sql参数名</param>
        /// <param name="str">参数值</param>
        /// <returns></returns>
        public static SqlParameter SetDecimalSqlParameter(string pName, string str)
        {
            if (str.Trim() == "")
            {
                return new SqlParameter(pName, DBNull.Value);
            }
            return new SqlParameter(pName, decimal.Parse(str));
        }

        /// <summary>
        /// 设置含NULL类型DateTime参数
        /// </summary>
        /// <param name="pName">Sql参数名</param>
        /// <param name="str">参数值</param>
        /// <returns></returns>
        public static SqlParameter SetDateTimeSqlParameter(string pName, string str)
        {
            if (str.Trim() == "")
            {
                return new SqlParameter(pName, DBNull.Value);
            }
            return new SqlParameter(pName, str);
        }

        #endregion

        /// MD532大加密
        /// 
        public string Encrypt(string s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = bytes.Aggregate("", (current, t) => current + Convert.ToString(t, 16).PadLeft(2, '0'));

            return ret.PadLeft(32, '0');
        }
        private static StreamWriter _streamWriter; //写文件  

        public static void WriteError(string message)
        {
            try
            {
                //DateTime dt = new DateTime();
                string directPath = AppDomain.CurrentDomain.BaseDirectory + "\\errorfile";    //获得文件夹路径
                if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                {
                    Directory.CreateDirectory(directPath);
                }
                directPath += string.Format(@"\{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
                if (_streamWriter == null)
                {
                    _streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                }
                _streamWriter.WriteLine("***********************************************************************");
                _streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                _streamWriter.WriteLine("输出信息：错误信息");
                if (message != null)
                {
                    _streamWriter.WriteLine("异常信息：\r\n" + message);
                }
            }
            finally
            {
                if (_streamWriter != null)
                {
                    _streamWriter.Flush();
                    _streamWriter.Dispose();
                    _streamWriter = null;
                }
            }
        }

    }
}
