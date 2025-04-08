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

    // TODO: 实现各类题目类型
    /// <summary>
    /// 单选题
    /// </summary>
    public class SingleAnsQuestion
    {

    }

    /// <summary>
    /// 多选题
    /// </summary>
    public class MultiAnsQustion
    {

    }

    /// <summary>
    /// 判断题
    /// </summary>
    public class TrueFalseQuestion
    {

    }
}
