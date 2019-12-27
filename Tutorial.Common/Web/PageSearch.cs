namespace Tutorial.Common.Web
{
    public class PageSearch
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public dynamic searchModel { get; set; }

    }

    #region 泛型请求实体 建议不要使用上面的dynamic 使用dynamic不利于在编译期发现错误

    /// <summary>
    /// 查询请求实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageSearch<T>
    {
        private int pageIndex = 1;
        /// <summary>
        /// 查询页码 默认第一页
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set
            {
                pageIndex = value;
            }
        }

        private int pageSize = 10;
        /// <summary>
        ///一页多少条 默认查询10条
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }

            set { pageSize = value; }
        }

        /// <summary>
        /// 主体请求参数
        /// </summary>
        public T SearchModel { get; set; }
    }
    #endregion
}
