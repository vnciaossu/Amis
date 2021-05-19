using System;

namespace MISA.AMIS.Core.AttributeCustom
{
    // Dùng để check bắt buộc nhập
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public string UserMsg = string.Empty;

        public Required(string userMsg = "")
        {
            UserMsg = userMsg;
        }
    }

    // Dùng để check trùng dữ liệu
    [AttributeUsage(AttributeTargets.Property)]
    public class IsDuplicate : Attribute
    {
    }

    //Kiểm tra định dạng Email
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotEmail : Attribute
    {
    }

    // Lấy tên bảng
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string Name { get; set; }

        public DisplayName(string name = null)
        {
            this.Name = name;
        }
    }

    // Lấy độ dài Property
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        #region DECLARE

        public int Length = 0;
        public string UserMsg = string.Empty;

        #endregion DECLARE

        public MaxLength(int maxLength = 0, string userMsg = "")
        {
            Length = maxLength;
            UserMsg = userMsg;
        }

        public string ErrorMaxLength
        {
            get
            {
                if (Length != 0)
                {
                    return UserMsg;
                }
                return null;
            }
        }
    }

    
}