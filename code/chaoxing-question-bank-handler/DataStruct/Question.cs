namespace chaoxing_question_bank_handler.DataStruct
{
    public abstract class Question
    {
        public string? Content { get; set; }
        public override int GetHashCode()
        {
            if (Content is not null)
                return Content.GetHashCode();
            else return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            // 如果 obj 为 null 或不是 Question 或类型不匹配，直接返回 false
            if (obj is null || obj is not Question anoQue || obj.GetType() != GetType())
                return false;
            else if (anoQue.Content == Content) return true;
            else return false;
        }
    }

    /// <summary>
    /// 单选题
    /// </summary>
    public class SingleAnsQuestion : Question
    {
        /// <summary>
        /// 选项
        /// </summary>
        public string[]? Options { get; set; }

        /// <summary>
        /// 正确答案索引
        /// </summary>
        public int AnsIndex { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public string? Answear
        {
            get
            {
                if (Options is not null) return Options[AnsIndex];
                else return null;
            }
        }
    }

    /// <summary>
    /// 多选题
    /// </summary>
    public class MultiAnsQustion : Question
    {
        /// <summary>
        /// 选项
        /// </summary>
        public string[]? Options { get; set; }

        /// <summary>
        /// 正确答案索引
        /// </summary>
        public int[]? AnsIndex { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public string[]? Answear
        {
            get
            {
                if (Options is not null && AnsIndex is not null)
                {
                    return AnsIndex.Select(i => Options[i]).ToArray();
                }
                else return null;
            }
        }
    }

    /// <summary>
    /// 判断题
    /// </summary>
    public class TrueFalseQuestion : Question
    {
        /// <summary>
        /// 正确答案
        /// </summary>
        public bool Answer { get; set; }
    }
}
