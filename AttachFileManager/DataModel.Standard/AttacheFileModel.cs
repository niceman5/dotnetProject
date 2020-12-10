using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Standard
{
    /// <summary>
    /// AttacheFiled테이블과 1:1로 매핑되는 모델 클래스 
    /// </summary>
    public class AttacheFileModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BoardId { get; set; }
        public int ArticleId { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int DownCount { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
