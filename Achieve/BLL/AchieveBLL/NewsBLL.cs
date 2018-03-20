﻿using AchieveCommon;
using AchieveDALFactory;
using AchieveEntity;
using AchieveInterfaceDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AchieveBLL
{
    public class RequestionBLL
    {
        IRequestionDAL dal = DALFactory.GetRequestionDAL();
        public RequestionBLL()
        { }

        #region  Method

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columns">要取的列名（逗号分开）</param>
        /// <param name="order">排序</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="where">查询条件</param>
        /// <param name="totalCount">总记录数</param>
        public string GetPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            return JsonHelper.ToJson(dt);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(RequestionEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(RequestionEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RequestionEntity GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RequestionEntity> GetModelList(string strWhere)
        {
            DataTable dt = dal.GetList(strWhere);
            return DataTableToList(dt);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<RequestionEntity> DataTableToList(DataTable dt)
        {
            List<RequestionEntity> modelList = new List<RequestionEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                RequestionEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new RequestionEntity();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["ftypeid"].ToString() != "")
                    {
                        model.ftypeid = int.Parse(dt.Rows[n]["ftypeid"].ToString());
                    }
                    model.ftitle = dt.Rows[n]["ftitle"].ToString();
                    model.fcontent = dt.Rows[n]["fcontent"].ToString();
                    model.CreateBy = dt.Rows[n]["CreateBy"].ToString();
                   
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    model.UpdateBy = dt.Rows[n]["UpdateBy"].ToString();
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetAllList()
        {
            return GetList("");
        }
        #endregion
    }
}
