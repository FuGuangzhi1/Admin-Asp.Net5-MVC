namespace StudyMVCFu.Model
{
    public class AjaxResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; } = "操作失败";
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}